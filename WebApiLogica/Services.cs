using System;
using System.Collections.Generic;
using System.Linq;
using WebApiModel;

namespace WebApiLogica
{
    public class Services
    {   
        public List<Encabezado_db> FiltroEncabezado(Facturacion_db facturacion_Db)
        {
            List<Encabezado_db> list = new List<Encabezado_db>();

            list.Add(new Encabezado_db()
            {
                idproducto = facturacion_Db.idproducto,
                idcliente = facturacion_Db.idcliente
            });

            return list;
        }

        public List<Detalle_db> FiltroDetalle(int idEncabezado, int cantidad, int precio, DateTime fecha)
        {
            List<Detalle_db> listDetalle = new List<Detalle_db>();

            listDetalle.Add(new Detalle_db()
            {
                id = idEncabezado,
                cantidad = cantidad,
                precio = precio,
                fecha = fecha
            });

            return listDetalle;
        }
    }
    
}
