using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VntRoute
{
    [Table("empresa", Schema = "public")]
    public class DtoEmpresa
    {
        [Key]
        public int id {get;set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
