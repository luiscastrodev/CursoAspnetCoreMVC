using DevIO.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    //Mapeamento de classes FluentAPI
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                  .IsRequired()
                  .HasColumnType("varchar(200)");

            builder.Property(prop => prop.Descricao)
              .IsRequired()
              .HasColumnType("varchar(1000)");

            builder.Property(prop => prop.Imagem)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Valor)
              .IsRequired()
              .HasPrecision(18,2)
              .HasColumnType("decimal");


            builder.ToTable("Produtos");

        }

    }
}
