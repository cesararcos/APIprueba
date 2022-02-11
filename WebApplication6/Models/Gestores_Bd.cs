using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class Gestores_Bd
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int lanzamiento { get; set; }
        public string desarrollador { get; set; }
    }

    public class Login_Bd
    {
        [Key]
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
    }

    // Lista desplegable roles-login
    public class Roles_Bd
    {
        [Key]
        public int value { get; set; }
        public string label { get; set; }
    }

    // Guarda usuario logueado
    public class LogUsuario_Bd
    {
        [Key]
        public int id { get; set; }
        public string usuario { get; set; }
        public string rol { get; set; }
    }

    // Crear producto administrador
    public class CrearProducto
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
    }

    public class EnviarCarrito
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
    }

    public class CompraConfirmada
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
    }
}
