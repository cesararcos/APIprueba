using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiModel;
using WebApplication6.Models;

namespace WebApplication6.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Productos_db> productos_db { get; set; }
        public DbSet<Clientes_db> clientes_db { get; set; }
        public DbSet<Encabezado_db> encabezado_db { get; set; }
        public DbSet<Detalle_db> detalle_db { get; set; }
    }
}
