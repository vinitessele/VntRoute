using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VntRoute
{
    [Table("destino", Schema = "public")]
    public class DtoDestino
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string documento { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string observacao { get; set; }
        public string status { get; set; }
        public int id_rota { get; set; }
        public string endereco { get; set; }
        public string transportadora { get; set; }
        public string bairro { get; set; }
        public double distancia { get; set; }
        public string duracao { get; set; }
    }
}