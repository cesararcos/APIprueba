using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiModel
{
    //PRODUCTOS
    public class Productos_db
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public int cantdisponible { get; set; }
    }

    //CLIENTES
    public class Clientes_db
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
    }

    //no pertenece a ninguna tabla entity
    public class Facturacion_db
    {
        [Key]
        public int id { get; set; }
        public int idproducto { get; set; }
        public int idcliente { get; set; }
        public int iddetalle { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public DateTime fecha { get; set; }
    }

    public class Encabezado_db
    {
        [Key]
        public int id { get; set; }
        public int idproducto { get; set; }
        public int idcliente { get; set; }
    }

    public class Detalle_db
    {
        
        public int id { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public DateTime fecha { get; set; }
    }

    public class Gestores_db
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public int lanzamiento { get; set; }
        public string desarrollador { get; set; }
    }

    public class Login_db
    {
        [Key]
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string rol { get; set; }
    }

    // Lista desplegable roles-login
    public class Roles_db
    {
        [Key]
        public int value { get; set; }
        public string label { get; set; }
    }

    // Guarda usuario logueado
    public class LogUsuario_db
    {
        [Key]
        public int id { get; set; }
        public string usuario { get; set; }
        public string rol { get; set; }
    }

    // Crear producto administrador
    public class CrearProducto_db
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
    }

    public class EnviarCarrito_db
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
    }

    public class CompraConfirmada_db
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }
    }
}
