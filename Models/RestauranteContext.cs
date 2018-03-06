using System;   
using System.Collections.Generic;   
using System.Linq;   
using System.Threading.Tasks;   
using Microsoft.EntityFrameworkCore;  

//estabelece conexão com banco de dados

namespace app_restaurante.Models
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }
        public RestauranteContext() { }
        public DbSet<Restaurante> Restaurante
        {
            get;
            set;
        }
    }
}
