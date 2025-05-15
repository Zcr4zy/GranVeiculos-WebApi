using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GranVeiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace GranVeiculos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cor> Cores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}