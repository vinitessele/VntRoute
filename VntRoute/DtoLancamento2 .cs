using System;

namespace VntRoute
{
    public class DtoLancamento2
    {
        public int id { get; set; }
        public DateTime dt_lancamento { get; set; }
        public DateTime dt_record { get; set; }
        public int? id_motorista { get; set; }
        public string motorista { get; set; }
        public int? id_cliente { get; set; }
        public string cliente { get; set; }
        public int? nr_controle { get; set; }
        public double? comissao { get; set; }
        public double? valor { get; set; }
        public string observacao { get; set; }
    }
}