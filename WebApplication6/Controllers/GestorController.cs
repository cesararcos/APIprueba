using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiModel;
using WebApplication6.Context;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestorController : ControllerBase
    {
        private readonly AppDbContext context;
        public GestorController(AppDbContext context)
        {
            this.context = context;
        }

        //PRODUCTOS
        [Route("getProductos")]
        [HttpGet]
        public ActionResult GetProductos()
        {
            try
            {
                return Ok(context.productos_db.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "getGestorProductos")]
        public ActionResult GetGestorProductos(int id)
        {
            try
            {
                var gestor = context.productos_db.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("createProductos")]
        [HttpPost]
        public ActionResult CreateProductos([FromBody] Productos_db gestor)
        {
            try
            {
                context.productos_db.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("getGestorProductos", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //CLIENTES
        [Route("getClientes")]
        [HttpGet]
        public ActionResult GetClientes()
        {
            try
            {
                return Ok(context.clientes_db.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "getGestorClientes")]
        public ActionResult GetGestorClientess(int id)
        {
            try
            {
                var gestor = context.clientes_db.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("createClientes")]
        [HttpPost]
        public ActionResult CreateClientes([FromBody] Clientes_db gestor)
        {
            try
            {
                context.clientes_db.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("getGestorClientes", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //ENCABEZADO
        [Route("createEncabezado")]
        [HttpPost]
        public ActionResult CreateEncabezado([FromBody] Facturacion_db gestor)
        {
            try
            {   
                List<Encabezado_db> list = new List<Encabezado_db>();
                List<Detalle_db> listDetalle = new List<Detalle_db>();
                var filtroClientes = context.clientes_db.FirstOrDefault(g => g.id == gestor.idcliente);
                var filtroProductoss = context.productos_db.FirstOrDefault(g => g.id == gestor.idproducto);

                if (filtroClientes != null && filtroProductoss != null)
                {
                    list.Add(new Encabezado_db()
                    {
                        idproducto = gestor.idproducto,
                        idcliente = gestor.idcliente
                    });

                    //guarda encabezado
                    context.encabezado_db.Add(list[0]);
                    context.SaveChanges();

                    int idEncabezado = (from c in context.encabezado_db
                                             orderby c.id descending
                                             select c.id).FirstOrDefault();
                    listDetalle.Add(new Detalle_db()
                    {
                        id = idEncabezado,
                        cantidad = gestor.cantidad,
                        precio = gestor.precio,
                        fecha = gestor.fecha
                    });

                    //guarda detalle
                    context.detalle_db.Add(listDetalle[0]);
                    context.SaveChanges();

                    //return CreatedAtRoute("getGestorClientes", new { id = gestor.id }, gestor);
                    return Ok("ok");
                }
                else
                {
                    return BadRequest("no existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo para editar un producto administrador
        [Route("editProductt/{id}")]
        [HttpPut]
        public ActionResult EditProductt(int id, [FromBody] Productos_db edit)
        {
            try
            {
                //var filtroProductoss = context.productos_db.FirstOrDefault(g => g.id == edit.id);
                if (edit.id == id)
                {
                    context.Entry(edit).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("getGestorProductos", new { id = edit.id }, edit);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("deleteProductt/{id}")]
        [HttpDelete]
        public ActionResult DeleteProductt(int id)
        {
            try
            {
                var gestorEliminar = context.productos_db.FirstOrDefault(g => g.id == id);
                if (gestorEliminar != null)
                {
                    context.productos_db.Remove(gestorEliminar);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
