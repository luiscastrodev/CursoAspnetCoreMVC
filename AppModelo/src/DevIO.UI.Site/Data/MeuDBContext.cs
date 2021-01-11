using DevIO.UI.Site.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Data
{
    public class MeuDBContext : DbContext
    {
        //recebe configuracoes vindo startup por Inj Dep
        public MeuDBContext(DbContextOptions<MeuDBContext> options)
            : base(options)
        {

        }

        //configurando classes
        public DbSet<Aluno> Alunos { get; set; }
    }
}
