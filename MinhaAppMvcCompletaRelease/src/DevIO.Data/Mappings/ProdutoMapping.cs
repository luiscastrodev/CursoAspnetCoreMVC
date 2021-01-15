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

            builder.ToTable("Produtos");

        }


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

                builder.ToTable("Enderecos");

            }
        }
    }
}
