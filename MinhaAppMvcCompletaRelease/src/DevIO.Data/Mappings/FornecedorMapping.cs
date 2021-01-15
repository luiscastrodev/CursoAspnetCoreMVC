using DevIO.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    //Mapeamento de classes FluentAPI
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                  .IsRequired()
                  .HasColumnType("varchar(200)");

            builder.Property(prop => prop.Documento)
              .IsRequired()
              .HasColumnType("varchar(14)");

            //1 para 1 Forncedor para endereco

            builder.HasOne(f => f.Endereco)
                   .WithOne(e => e.Fornecedor);

            //1 para N Fornecedor para Produto
            builder.HasMany(f => f.Produtos)
                    .WithOne(p => p.Fornecedor)
                    .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");

        }
    }
}
