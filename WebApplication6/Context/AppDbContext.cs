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
        public DbSet<Gestores_db> gestores_bd { get; set; }
        public DbSet<Login_db> login { get; set; }
        public DbSet<Roles_db> roles { get; set; }
        public DbSet<LogUsuario_db> logusuarios { get; set; }
        public DbSet<CrearProducto_db> crearproducto { get; set; }
        public DbSet<EnviarCarrito_db> enviarcarrito { get; set; }
        public DbSet<CompraConfirmada_db> compraconfirmada { get; set; }
        public DbSet<Productos_db> productos_db { get; set; }
        public DbSet<Clientes_db> clientes_db { get; set; }
        public DbSet<Encabezado_db> encabezado_db { get; set; }
        public DbSet<Detalle_db> detalle_db { get; set; }
    }
}
