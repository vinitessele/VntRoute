using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VntRoute
{
    [Table("estado", Schema = "public")]
    public class DtoEstado
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public int codigouf { get; set; }
    }
}