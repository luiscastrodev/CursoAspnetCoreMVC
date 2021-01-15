using DevIO.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevIO.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configuracao para quando esquecer de colocar ex: varchar valor evitando colocar nvarchar Max 
            /*foreach (var propety in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetProperties()
                     .Where(p => p.ClrType == typeof(string))))
                propety.Relational().ColumnType = "varchar(100)";*/

            //mapea as classes Mapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            //desabilitar metodo cascate deleted
            foreach (var realtionsship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) realtionsship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
