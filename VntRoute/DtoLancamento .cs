using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VntRoute
{
    [Table("lancamento", Schema = "public")]
    public class DtoLancamento
    {
        [Key]
        public int id { get; set; }
        public DateTime dt_lancamento { get; set; }
        public DateTime dt_record { get; set; }
        public int? id_motorista { get; set; }
        public int? id_cliente { get; set; }
        public int? nr_controle { get; set; }
        public float? valor { get; set; }
        public string observacao { get; set; }
    }
}