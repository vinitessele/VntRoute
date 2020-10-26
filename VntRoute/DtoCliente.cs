using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VntRoute
{
    [Table("cliente", Schema = "public")]
    public class DtoCliente
    {
        [Key]
        public int id { get; set; }
    }
}