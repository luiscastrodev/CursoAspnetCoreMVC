using DevIO.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    //Mapeamento de classes FluentAPI
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Logradouro)
                  .IsRequired()
                  .HasColumnType("varchar(200)");

            builder.Property(prop => prop.Numero)
                      .IsRequired()
                      .HasColumnType("varchar(50)");

            builder.Property(prop => prop.Cep)
                     .IsRequired()
                     .HasColumnType("varchar(8)");


            builder.Property(prop => prop.Complemento)
                     .IsRequired()
                     .HasColumnType("varchar(250)");


            builder.Property(prop => prop.Bairro)
                     .IsRequired()
                     .HasColumnType("varchar(100)");


            builder.Property(prop => prop.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Estado)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(f => f.Fornecedor)
                 .WithOne(e => e.Endereco)
                 .HasForeignKey<Fornecedor>(x=>x.Id)
                 ;


            builder.ToTable("Enderecos");

        }
    }
}
