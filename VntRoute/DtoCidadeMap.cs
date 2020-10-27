using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VntRoute
{
    public class DtoCidadeMap
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int id_estado { get; set; }
        public int codigoibge { get; set; }
    }
}