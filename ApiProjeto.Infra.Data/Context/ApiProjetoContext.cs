using ApiProjeto.Domain.Entities;
using ApiProjeto.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ApiProjeto.Infra.Data.Context
{
    public class ApiProjetoContext : DbContext
    {
        public ApiProjetoContext(DbContextOptions<ApiProjetoContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>(new PessoaMap().Configure);
        }

    }
}
