using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Gestores_Bd> gestores_bd { get; set; }
        public DbSet<Login_Bd> login { get; set; }
        public DbSet<Roles_Bd> roles { get; set; }
        public DbSet<LogUsuario_Bd> logusuarios { get; set; }
        public DbSet<CrearProducto> crearproducto { get; set; }
        public DbSet<EnviarCarrito> enviarcarrito { get; set; }
        public DbSet<CompraConfirmada> compraconfirmada { get; set; }
    }
}
