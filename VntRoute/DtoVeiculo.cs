using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VntRoute
{
    [Table("veiculo", Schema = "public")]
    public class DtoVeiculo
    {
        [Key]
        public int id { get; set; }
        public string marcamodelo { get; set; }
        public string placa { get; set; }
        public string anomodelo { get; set; }
        public int km_atual { get; set; }
    }
}