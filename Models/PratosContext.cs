using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//estabelece conexão com banco de dados

namespace app_restaurante.Models
{
    public class PratosContext : DbContext
    {
        public PratosContext(DbContextOptions<PratosContext> options) : base(options) { }
        public PratosContext() { }
        public DbSet<Pratos> Pratos
        {
            get;
            set;
        }
    }
}