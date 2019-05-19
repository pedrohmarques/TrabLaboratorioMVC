using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prova1.Models;

namespace Prova1.Models
{
    public class Prova1Context : DbContext
    {
        public Prova1Context (DbContextOptions<Prova1Context> options)
            : base(options)
        {
        }

        public DbSet<Prova1.Models.Compra> Compra { get; set; }

        public DbSet<Prova1.Models.Venda> Venda { get; set; }

        public DbSet<Prova1.Models.Info> Info { get; set; }

        public DbSet<Prova1.Models.Acao> Acao { get; set; }
    }
}
