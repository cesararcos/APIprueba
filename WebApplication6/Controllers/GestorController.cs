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
                var gestor = context.gestores_bd.FirstOrDefault(g => g.id == id);
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

        [Route("getGestor")]
        [HttpGet]
        public ActionResult GetGestor()
        {
            try
            {
                return Ok(context.gestores_bd.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.gestores_bd.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuario}/{contrasena}", Name = "GetLogin")]
        public ActionResult GetLogin(string usuario, string contrasena)
        {
            try
            {
                var obtenerUsuario = context.login.FirstOrDefault(g => g.usuario == usuario && g.contrasena == contrasena);
                return Ok(obtenerUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("postLogin/{usuario}/{contrasena}")]
        [HttpPost]
        public ActionResult PostLogin(string usuario, string contrasena)
        {
            try
            {
                var obtenerUsuario = context.login.FirstOrDefault(g => g.usuario == usuario && g.contrasena == contrasena);
                return Ok(obtenerUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getRoles")]
        [HttpGet]
        public ActionResult GetRoles()
        {
            try
            {
                var obtenerRoles = context.roles.ToList();
                return Ok(obtenerRoles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("post")]
        [HttpPost]
        public ActionResult Post([FromBody] Gestores_db gestor)
        {
            try
            {
                context.gestores_bd.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Post para guardar el usuario logueado exitosamente
        [Route("saveUser")]
        [HttpPost]
        public ActionResult SaveUser([FromBody] LogUsuario_db logUsuario_Bd)
        {
            try
            {
                context.logusuarios.Add(logUsuario_Bd);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = logUsuario_Bd.id }, logUsuario_Bd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Get para retornar ultimo usuario logueado exitosamente
        [Route("getUsuarioLog")]
        [HttpGet]
        public ActionResult GetUsuarioLog()
        {
            try
            {
                //var obtenerUsuario = context.logusuarios.LastOrDefault();
                var LastRecord = (from c in context.logusuarios
                                  orderby c.id descending
                                  select c).First();
                return Ok(LastRecord);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Get para consultar todos los productos administrador
        [Route("getProdAll")]
        [HttpGet]
        public ActionResult GetProdAll()
        {
            try
            {
                var gestorProductAll = context.crearproducto.ToList();
                return Ok(gestorProductAll);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getProductId/{codigo}")]
        [HttpGet]
        public ActionResult GetProductId(int codigo)
        {
            try
            {
                var gestor = context.crearproducto.FirstOrDefault(g => g.codigo == codigo);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Get para consultar un producto administrador x codigo
        [Route("getProd")]
        [HttpGet("{codigo}", Name = "GetProd")]
        public ActionResult GetProd(int codigo)
        {
            try
            {
                var gestor = context.crearproducto.FirstOrDefault(g => g.codigo == codigo);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Post para crear un producto administrador
        [Route("createProd")]
        [HttpPost]
        public ActionResult CreateProd([FromBody] CrearProducto_db crearProducto)
        {
            try
            {
                context.crearproducto.Add(crearProducto);
                context.SaveChanges();
                return CreatedAtRoute("GetProd", new { codigo = crearProducto.codigo }, crearProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo para editar un producto administrador
        [Route("editProduct/{codigo}")]
        [HttpPut]
        public ActionResult EditProduct(int codigo, [FromBody] CrearProducto_db editarProducto)
        {
            try
            {
                if (editarProducto.codigo == codigo)
                {
                    context.Entry(editarProducto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProd", new { codigo = editarProducto.codigo }, editarProducto);
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

        // Metodo para eliminar un producto administrador
        [Route("deleteProduct/{codigo}")]
        [HttpDelete]
        public ActionResult DeleteProduct(int codigo)
        {
            try
            {
                var gestorEliminar = context.crearproducto.FirstOrDefault(g => g.codigo == codigo);
                if (gestorEliminar != null)
                {
                    context.crearproducto.Remove(gestorEliminar);
                    context.SaveChanges();
                    return Ok(codigo);
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

        // Metodo para enviar producto a carrito
        [Route("sendCar")]
        [HttpPost]
        public ActionResult SendCar([FromBody] EnviarCarrito_db enviarCarrito)
        {
            try
            {
                context.enviarcarrito.Add(enviarCarrito);
                context.SaveChanges();
                return CreatedAtRoute("GetProd", new { codigo = enviarCarrito.codigo }, enviarCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Get para consultar todos los productos administrador
        [Route("confirmPurchase")]
        [HttpPost]
        public ActionResult ConfirmPurchase()
        {
            try
            {
                List<EnviarCarrito_db> gestorProductAllCar = context.enviarcarrito.ToList(); //trae productos que estan en carrito
                List<CompraConfirmada_db> list = new List<CompraConfirmada_db>(); //almacena los productos del carrito para confirmarlos
                List<CompraConfirmada_db> comprasConfirmadas = context.compraconfirmada.ToList(); //trae productos ya comprados

                for (int i = 0; i < gestorProductAllCar.Count; i++)
                {
                    var filtroProductos = 
                        context.compraconfirmada.FirstOrDefault(g => g.codigo == gestorProductAllCar[i].codigo); //filtra y trae el producto repetidos ya comprados vs carrito
                    if (filtroProductos != null)
                    {
                        list.Add(new CompraConfirmada_db()
                        {
                            codigo = gestorProductAllCar[i].codigo,
                            nombre = gestorProductAllCar[i].nombre,
                            descripcion = gestorProductAllCar[i].descripcion,
                            precio = (gestorProductAllCar[i].precio * gestorProductAllCar[i].cantidad) + comprasConfirmadas[i].precio,
                            cantidad = gestorProductAllCar[i].cantidad + comprasConfirmadas[i].cantidad
                        });
                        context.compraconfirmada.Remove(filtroProductos);
                        context.SaveChanges();
                        context.compraconfirmada.Add(list[i]);
                        context.enviarcarrito.Remove(gestorProductAllCar[i]);
                    }
                    else
                    {
                        list.Add(new CompraConfirmada_db()
                        {
                            codigo = gestorProductAllCar[i].codigo,
                            nombre = gestorProductAllCar[i].nombre,
                            descripcion = gestorProductAllCar[i].descripcion,
                            precio = gestorProductAllCar[i].precio,
                            cantidad = gestorProductAllCar[i].cantidad,
                        });

                        context.compraconfirmada.Add(list[i]);
                        context.enviarcarrito.Remove(gestorProductAllCar[i]);
                    }
                    
                    context.SaveChanges();
                    
                    
                }

                return Ok(gestorProductAllCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Get para consultar todos los productos del carrito
        [Route("getProdCar")]
        [HttpGet]
        public ActionResult GetProdCar()
        {
            try
            {
                var gestorProdCar = context.enviarcarrito.ToList();
                return Ok(gestorProdCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Metodo Get para consultar todos los productos confirmados y comprados
        [Route("getConfirmProd")]
        [HttpGet]
        public ActionResult GetConfirmProd()
        {
            try
            {
                //var gestorConfirmProd = context.compraconfirmada.ToList();
                var gestorConfirmProd = (from c in context.compraconfirmada
                                  orderby c.cantidad descending
                                  select c).ToList();
                return Ok(gestorConfirmProd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gestores_db gestor)
        {
            try
            {
                if (gestor.id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
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

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.gestores_bd.FirstOrDefault(g => g.id == id);
                if (gestor != null)
                {
                    context.gestores_bd.Remove(gestor);
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
