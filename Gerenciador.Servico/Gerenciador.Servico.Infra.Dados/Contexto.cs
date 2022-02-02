using Gerenciador.Servico.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Servico.Infra.Dados
{
    public class Contexto : DbContext
    {
        //public Contexto()
        //{
        //}
        //public Contexto(DbContextOptions<Contexto> options) : base(options)
        //{

        //}

        public DbSet<TiposServicos> TiposServicos { get; set; }
        public DbSet<Servicos> Servicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!string.IsNullOrWhiteSpace(Conexao.StringDados))
                optionBuilder.UseSqlServer(Conexao.StringDados);
            else
                optionBuilder.UseSqlServer(@"");
        }
    }
}
