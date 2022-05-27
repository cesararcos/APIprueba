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
}
