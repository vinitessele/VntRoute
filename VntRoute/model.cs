﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace VntRoute
{
    public class model
    {
        public void set(DtoDestino destino)
        {
            try
            {
                Context db = new Context();
                if (destino.endereco != null)
                    db.destino.Add(destino);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DtoDestino> getListaDestinos()
        {
            Context db = new Context();
            return db.destino.Where(p => p.status == "I").ToList();
        }

        public List<DtoDestino> getListaDestinosLimit(List<DtoBairro> listBairro)
        {
            Context db = new Context();
            List<DtoDestino> listdestinos = new List<DtoDestino>();
            foreach (var l in listBairro)
            {
                List<DtoDestino> listdestino = new List<DtoDestino>();
                listdestino = db.destino.Where(p => p.status == "I" && p.bairro == l.bairro).OrderBy(p => p.endereco).Take(25).ToList();
                listdestinos.AddRange(listdestino);
            }
            return listdestinos;
        }

        internal void AlteraEstado(DtoEstado d)
        {
            try
            {
                Context db = new Context();
                DtoEstado e = db.estado.FirstOrDefault(p => p.id == d.id);
                e.id = d.id;
                e.nome = d.nome;
                e.uf = d.uf;
                e.codigouf = d.codigouf;
                db.SaveChanges();
            }
            catch () {
            }
        }

        internal void setEstado(DtoEstado d)
        {
            try
            {
                Context db = new Context();
                db.estado.Add(d);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlteraVeiculo(DtoVeiculo v)
        {
            Context db = new Context();
            DtoVeiculo e = db.veiculo.FirstOrDefault(p => p.id == v.id);
            e.marcamodelo = v.marcamodelo;
            e.km_atual = v.km_atual;
            e.placa = v.placa;
            e.anomodelo = v.anomodelo;
            db.SaveChanges();
        }

        public void DeleteVeiculo(int id)
        {
            Context db = new Context();
            DtoVeiculo e = db.veiculo.FirstOrDefault(p => p.id == id);
            db.veiculo.Remove(e);
            db.SaveChanges();
        }

        public void setVeiculo(DtoVeiculo v)
        {
            Context db = new Context();
            db.veiculo.Add(v);
            db.SaveChanges();
        }

        public List<DtoDestino> getRotaCoordenadas(List<DtoBairro> listBairro)
        {
            List<DtoDestino> lista = getListaDestinos(listBairro);

            return lista;
        }

        private List<DtoDestino> getListaDestinos(List<DtoBairro> listBairro)
        {
            Context db = new Context();
            List<DtoDestino> listdestinos = new List<DtoDestino>();
            foreach (var l in listBairro)
            {
                List<DtoDestino> listdestino = new List<DtoDestino>();
                listdestino = db.destino.Where(p => p.status == "I" && p.bairro == l.bairro).OrderBy(p => p.bairro).OrderBy(p => p.latitude).OrderBy(p => p.longitude).ToList();
                listdestinos.AddRange(listdestino);
            }
            return listdestinos;
        }

        public DtoDestino getDestinoDocumento(string valor)
        {
            Context db = new Context();

            string[] itens = valor.Split('-');
            int id = int.Parse(itens[0]);
            string documento = itens[1];

            return db.destino.Where(p => p.documento == documento && p.id == id).FirstOrDefault();
        }

        public DtoDestino getDestinoId(int id)
        {
            Context db = new Context();

            return db.destino.Where(p => p.id == id).FirstOrDefault();
        }

        public List<DtoBairro> getBairros()
        {
            Context db = new Context();
            var query = from p in db.destino
                        group p by p.bairro into g
                        select new DtoBairro()
                        {
                            bairro = g.Key,
                        };
            return query.OrderBy(p => p.bairro).ToList();
        }

        #region Google

        public List<DtoRota> getRotaGoogle(List<DtoBairro> listBairro)
        {
            string origem = getEndecoEmpresa();
            string destino = origem;

            List<DtoDestino> lista = getListaDestinosLimit(listBairro);

            string rota = string.Empty;
            List<DtoRota> RetornoGoogle = new List<DtoRota>();

            if (lista.Count > 25)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    rota += "|" + lista[i].endereco;
                    if (i == 24 || i == (lista.Count-1))
                    {
                        RetornoGoogle.AddRange(RouteGoogle(origem, destino, rota));
                        rota = string.Empty;
                    }
                }
            }
            else
            {
                foreach (var l in lista)
                {
                    // limite da google de 25 enderecos
                    rota += "|" + l.endereco;
                }
                RetornoGoogle.AddRange(RouteGoogle(origem, destino, rota));
            }
            return RetornoGoogle;
        }

        private List<DtoRota> RouteGoogle(string origem, string destino, string rota)
        {
            var requestUri = string.Format("https://maps.googleapis.com/maps/api/directions/xml?origin=" + origem + "&destination=" + destino + "&waypoints=optimize:true" + rota + "|&key=AIzaSyAwjnJzF57fQddVy_dL8yTC01Zw7ufVuY8", Uri.EscapeDataString(rota));

            WebRequest request = WebRequest.Create(requestUri);
            List<DtoRota> list = new List<DtoRota>();
            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);

                    for (int i = 0; i < dsResult.Tables["leg"].Rows.Count; i++)
                    {
                        DtoRota r = new DtoRota();
                        string startEndereco = dsResult.Tables["leg"].Rows[i]["start_address"].ToString();
                        string endEndereco = dsResult.Tables["leg"].Rows[i]["end_address"].ToString();
                        r.start_address = startEndereco;
                        r.end_address = endEndereco;
                        r.waypoint_order = i;
                        DtoLatLong latlongstart = GetLatLongGoogle(startEndereco);
                        //DtoLatLong latlongstart = GetLatLongBD(startEndereco);
                        try
                        {
                            r.start_latitude = latlongstart.latitude;
                            r.start_longitude = latlongstart.longitude;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        DtoLatLong latlongend = GetLatLongGoogle(endEndereco);
                        try
                        {
                            r.end_latitude = latlongend.latitude;
                            r.end_longitude = latlongend.longitude;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        list.Add(r);
                    }
                }
            }
            return list;
        }

        private DtoLatLong GetLatLongBD(string startEndereco)
        {
            Context db = new Context();
            var result = from i in db.destino
                         where i.endereco.Contains(startEndereco)
                         select new DtoLatLong()
                         {
                             longitude = i.longitude.ToString(),
                             latitude = i.latitude.ToString()
                         };
            return result.FirstOrDefault();
        }

        public DtoLatLong GetLatLongGoogle(string text)
        {
            var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address=" + text + "&key=AIzaSyAwjnJzF57fQddVy_dL8yTC01Zw7ufVuY8", Uri.EscapeDataString(text));

            WebRequest request = WebRequest.Create(requestUri);

            using (WebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    string lati = dsResult.Tables["location"].Rows[0]["lat"].ToString();
                    string longi = dsResult.Tables["location"].Rows[0]["lng"].ToString();
                    DtoLatLong i = new DtoLatLong();
                    i.latitude = lati;
                    i.longitude = longi;
                    return i;
                }
            }
        }
        #endregion
        
        public List<DtoDestino> getListDestino()
        {
            Context db = new Context();
            return db.destino.Where(p => p.id_rota == 0).ToList();
        }

        public DtoLatLong getLatLngEndereco(string text)
        {
            Context db = new Context();
            string[] itens = text.Split('-');
            string end = itens[2].ToString() + itens[3].ToString();

            var result = from i in db.destino
                         where i.endereco == end
                         select new DtoLatLong()
                         {
                             longitude = i.longitude.ToString(),
                             latitude = i.latitude.ToString()
                         };
            return result.FirstOrDefault();
        }

        public int getIdRota()
        {
            Context db = new Context();
            int intIdt = db.destino.Max(u => u.id_rota);
            return intIdt;
        }

        public void addRota(int id, int idRota, string status)
        {
            Context db = new Context();
            DtoDestino des = db.destino.FirstOrDefault(p => p.id == id);
            des.id_rota = idRota;
            des.status = status;
            db.SaveChanges();
        }

        public DtoLatLong getLatLngId(string texto)
        {
            Context db = new Context();
            string[] itens = texto.Split('-');
            int id = int.Parse(itens[0].ToString());

            var result = from i in db.destino
                         where i.id == id
                         select new DtoLatLong()
                         {
                             longitude = i.longitude.ToString(),
                             latitude = i.latitude.ToString()
                         };
            return result.FirstOrDefault();
        }

        public string getEndEmpresaID(int id)
        {
            Context db = new Context();
            return db.empresa.FirstOrDefault(p => p.id == id).endereco.ToString();
        }
        public string getEndecoEmpresa()
        {
            Context db = new Context();
            return db.empresa.FirstOrDefault().endereco.ToString();
        }

        public DtoEmpresa getEndEmpresa()
        {
            Context db = new Context();
            return db.empresa.FirstOrDefault();
        }

        public DtoLatLong getLatlgnEmpresaId(int id)
        {
            Context db = new Context();
            var result = from i in db.empresa
                         where i.id == id
                         select new DtoLatLong()
                         {
                             longitude = i.longitude.ToString(),
                             latitude = i.latitude.ToString()
                         };
            return result.FirstOrDefault();
        }

        public DtoLatLong getLatlgnEmpresa()
        {
            Context db = new Context();
            var result = from i in db.empresa
                         select new DtoLatLong()
                         {
                             longitude = i.longitude.ToString(),
                             latitude = i.latitude.ToString()
                         };
            return result.FirstOrDefault();
        }

        public void DeleteEmpresa(int id)
        {
            Context db = new Context();
            DtoEmpresa e = db.empresa.FirstOrDefault(p => p.id == id);
            db.empresa.Remove(e);
            db.SaveChanges();
        }

        public void AlteraEmpresa(DtoEmpresa d)
        {
            Context db = new Context();
            DtoEmpresa e = db.empresa.FirstOrDefault(p => p.id == d.id);
            e.nome = d.nome;
            e.endereco = d.endereco;
            e.latitude = d.latitude;
            e.longitude = d.longitude;
            db.SaveChanges();
        }

        public void setEmpresa(DtoEmpresa d)
        {
            Context db = new Context();
            db.empresa.Add(d);
            db.SaveChanges();
        }

        public void AlteraDestino(DtoDestino d)
        {
            Context db = new Context();
            DtoDestino des = db.destino.FirstOrDefault(p => p.documento == d.documento);
            des.nome = d.nome;
            des.documento = d.documento;
            des.endereco = d.endereco;
            des.latitude = d.latitude;
            des.longitude = d.longitude;
            des.bairro = d.bairro;
            des.transportadora = d.transportadora;
            db.SaveChanges();
        }

        public void setDestino(DtoDestino d)
        {
            Context db = new Context();
            DtoDestino des = new DtoDestino();
            des.nome = d.nome;
            des.documento = d.documento;
            des.endereco = d.endereco;
            des.latitude = d.latitude;
            des.longitude = d.longitude;
            des.bairro = d.bairro;
            des.transportadora = d.transportadora;
            db.destino.Add(des);
            db.SaveChanges();
        }

        public void DeleteDestino(string text)
        {
            Context db = new Context();
            DtoDestino des = db.destino.FirstOrDefault(p => p.documento == text);
            db.destino.Remove(des);
            db.SaveChanges();

        }

        public DtoLatLong getLatLngDocId(string itemText)
        {
            Context db = new Context();
            string[] itens = itemText.Split('-');
            int id = int.Parse(itens[0]);
            string documento = itens[1];

            var result = from i in db.destino
                         where i.documento == documento && i.id == id
                         select new DtoLatLong()
                         {
                             longitude = i.longitude.ToString(),
                             latitude = i.latitude.ToString()
                         };
            return result.FirstOrDefault();
        }

        public bool getDestinoDocumento(string documento, string transportadora)
        {
            Context db = new Context();
            var result = db.destino.FirstOrDefault(p => p.documento == documento && p.transportadora == transportadora);
            if (result != null)
                return true;
            else
                return false;
        }
    }
}
