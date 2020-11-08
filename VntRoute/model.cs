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

        public void DeleteMotorista(string id)
        {
            Context db = new Context();
            DtoMotorista e = db.motorista.FirstOrDefault(p => p.id == int.Parse(id));
            db.motorista.Remove(e);
            db.SaveChanges();
        }

        public List<DtoCliente> getAllClientes()
        {
            Context db = new Context();
            return db.cliente.ToList();
        }

        public List<DtoMotorista> getAllMotorista()
        {
            Context db = new Context();
            return db.motorista.ToList();
        }

        public void setLancamento(DtoLancamento lanc)
        {
            Context db = new Context();
            db.lancamento.Add(lanc);
            db.SaveChanges();
        }

        public void alterLancamento(DtoLancamento lanc)
        {
            throw new NotImplementedException();
        }

        public List<DtoDestino> getListaDestinos()
        {
            Context db = new Context();
            return db.destino.Where(p => p.status == "I").ToList();
        }

        public void DeleteCliente(string id)
        {
            Context db = new Context();
            DtoCliente e = db.cliente.FirstOrDefault(p => p.id == int.Parse(id));
            db.cliente.Remove(e);
            db.SaveChanges();
        }

        public void setCliente(DtoCliente c)
        {
            Context db = new Context();

            db.cliente.Add(c);
            db.SaveChanges();
        }

        public void AlteraCliente(DtoCliente cli)
        {
            Context db = new Context();
            DtoCliente c = db.cliente.FirstOrDefault(p => p.id == cli.id);

            c.nome = cli.nome;
            c.endereco = cli.endereco;
            c.telefone = cli.telefone;
            c.email = cli.email;
            c.cpfcnpj = cli.cpfcnpj;
            c.ierg = cli.ierg;
            c.id_cidade = cli.id_cidade;
            c.observacoes = cli.observacoes;
            c.complemento = cli.complemento;
            db.SaveChanges();
        }

        public void DeleteLancamento(string id)
        {
            Context db = new Context();
            DtoLancamento e = db.lancamento.FirstOrDefault(p => p.id == int.Parse(id));
            db.lancamento.Remove(e);
            db.SaveChanges();
        }

        public void setMotorista(DtoMotorista c)
        {
            Context db = new Context();

            db.motorista.Add(c);
            db.SaveChanges();
        }

        internal void AlteraMotorista(DtoMotorista m)
        {
            Context db = new Context();
            DtoMotorista c = db.motorista.FirstOrDefault(p => p.id == m.id);

            c.nome = m.nome;
            c.endereco = m.endereco;
            c.telefone = m.telefone;
            c.email = m.email;
            c.cpfcnpj = m.cpfcnpj;
            c.ierg = m.ierg;
            c.id_cidade = m.id_cidade;
            c.observacoes = m.observacoes;
            c.complemento = m.complemento;
            c.comissao = m.comissao;
            db.SaveChanges();
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

        internal List<DtoCidadeMap> getAllCidades()
        {
            Context db = new Context();

            var q = (from c in db.cidade
                     join e in db.estado
                     on c.id_estado equals e.id into estado
                     from e in estado.DefaultIfEmpty()
                     select new DtoCidadeMap()
                     {
                         id = c.id,
                         nome = c.nome + "/" + e.uf,
                         id_estado = c.id_estado
                     }).OrderBy(p => p.nome);

            return q.ToList();
        }

        internal void AlteraCidade(DtoCidade d)
        {
            try
            {
                Context db = new Context();
                DtoCidade e = db.cidade.FirstOrDefault(p => p.id == d.id);
                e.id = d.id;
                e.nome = d.nome;
                e.id_estado = d.id_estado;
                e.codigoibge = d.codigoibge;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void DeleteCidade(string id)
        {
            Context db = new Context();
            DtoCidade e = db.cidade.FirstOrDefault(p => p.id == int.Parse(id));
            db.cidade.Remove(e);
            db.SaveChanges();
        }

        public List<DtoEstado> getAllEstados()
        {
            Context db = new Context();
            var q = db.estado.ToList();
            return q.ToList();
        }

        public void setCidade(DtoCidade d)
        {
            try
            {
                Context db = new Context();
                db.cidade.Add(d);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void DeleteEstado(int id)
        {
            Context db = new Context();
            DtoEstado e = db.estado.FirstOrDefault(p => p.id == id);
            db.estado.Remove(e);
            db.SaveChanges();
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
            catch (Exception ex)
            {
                throw ex;
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


        public List<DtoDestino> getListaDestinosBairro(List<DtoBairro> listBairro)
        {
            Context db = new Context();
            List<DtoDestino> listdestinos = new List<DtoDestino>();
            foreach (var l in listBairro)
            {
                List<DtoDestino> listdestino = new List<DtoDestino>();
                listdestino = db.destino.Where(p => p.status == "I" && p.bairro == l.bairro).OrderBy(p=>p.distancia).ToList();
                listdestinos.AddRange(listdestino);
            }
            listdestinos= listdestinos.OrderBy(p => p.distancia).ToList();
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
                    if (i == 24 || i == (lista.Count - 1))
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
            Context db = new Context();
            string origin = string.Empty;
            try
            {
                origin = db.empresa.SingleOrDefault().endereco;
            }
            catch (Exception)
            {
                 origin = "Rua Carlos DallAgnolo 121,Toledo, PR";
            }
            string requestUriCordenadas = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address=" + text + "&key=AIzaSyAwjnJzF57fQddVy_dL8yTC01Zw7ufVuY8", Uri.EscapeDataString(text));
            string requestUriDistancia = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + text + "&key=AIzaSyCNiXQqjhm3GQ83i2FmXXo835XUOfylz6c";
            string duration;
            string distance;
            WebRequest requestCordenadas = WebRequest.Create(requestUriCordenadas);
            using (WebResponse response = (HttpWebResponse)requestCordenadas.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    DataSet dsResult = new DataSet();
                    dsResult.ReadXml(reader);
                    string lati = dsResult.Tables["location"].Rows[0]["lat"].ToString();
                    string longi = dsResult.Tables["location"].Rows[0]["lng"].ToString();

                    WebRequest requestDistancia = WebRequest.Create(requestUriDistancia);
                    using (WebResponse responseDistancia = (HttpWebResponse)requestDistancia.GetResponse())
                    {
                        using (StreamReader readerDistancia = new StreamReader(responseDistancia.GetResponseStream(), Encoding.UTF8))
                        {
                            DataSet dsResultDistancia = new DataSet();
                            dsResultDistancia.ReadXml(readerDistancia);
                            duration = dsResultDistancia.Tables["duration"].Rows[0]["text"].ToString() + " - " + dsResultDistancia.Tables["distance"].Rows[0]["text"].ToString(); ;
                            distance = dsResultDistancia.Tables["distance"].Rows[0]["value"].ToString();
                        }
                    }
                    DtoLatLong i = new DtoLatLong();
                    i.latitude = lati;
                    i.longitude = longi;
                    i.distancia = distance;
                    i.duracao = duration;
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
