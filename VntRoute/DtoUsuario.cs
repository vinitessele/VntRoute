using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VntRoute
{
    [Table("usuario", Schema = "public")]
    public class DtoUsuario
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string logn { get; set; }
        public string senha { get; set; }
    }
}