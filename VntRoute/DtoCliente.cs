using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VntRoute
{
    [Table("cliente", Schema = "public")]
    public class DtoCliente
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public int? id_cidade { get; set; }
        public string cpfcnpj { get; set; }
        public string ierg { get; set; }
        public string complemento { get; set; }
        public string observacoes { get; set; }

    }
}