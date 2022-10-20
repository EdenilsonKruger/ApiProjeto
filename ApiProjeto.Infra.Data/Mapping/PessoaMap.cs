using ApiProjeto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProjeto.Infra.Data.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(prop => prop.Id);

            builder.Property(m => m.Id)
                .HasColumnName("Pessoa_Id");

            builder.Property(prop => prop.Nome_Fantasia)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Nome_Fantasia")
                .HasColumnType("varchar(255)");

            builder.Property(prop => prop.Cnpj_Cpf)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Cnpj_Cpf")
               .HasColumnType("varchar(20)");
        }
    }
}
