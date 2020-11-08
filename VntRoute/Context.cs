using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VntRoute
{
    public class Context : DbContext
    {
        public Context() : base("MyDbConnection")
        {
        }
        public DbSet<DtoUsuario> usuario { get; set; }
        public DbSet<DtoRota> rota { get; set; }
        public DbSet<DtoDestino> destino { get; set; }
        public DbSet<DtoEmpresa> empresa { get; set; }
        public DbSet<DtoCliente> cliente { get; set; }
        public DbSet<DtoMotorista> motorista { get; set; }
        public DbSet<DtoCidade> cidade { get; set; }
        public DbSet<DtoEstado> estado { get; set; }
        public DbSet<DtoVeiculo> veiculo { get; set; }
        public DbSet<DtoLancamento> lancamento { get; set; }
    }
}
