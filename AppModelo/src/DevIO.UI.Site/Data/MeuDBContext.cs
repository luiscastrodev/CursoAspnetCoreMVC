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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("myrealconnectionstring");
        }
    }
}
