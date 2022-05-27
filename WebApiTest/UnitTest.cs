using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApiModel;
using WebApplication6.Context;
using WebApplication6.Controllers;

namespace WebApiTest
{
    [TestClass]
    public class UnitTest
    {
        private readonly AppDbContext context;
        
        [TestMethod]
        public void TestMethod1()
        {
            GestorController gestor = new GestorController(context);
            var result = gestor.GetProductos();
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestMethodClient()
        {
            GestorController gestor = new GestorController(context);
            var result = gestor.GetClientes();
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestMethodCreateProd()
        {
            GestorController gestor = new GestorController(context);
            Productos_db productos = new Productos_db();
            productos.nombre = "producto prueba unitaria";
            productos.precio = 1;
            productos.cantdisponible = 1;
            var result = gestor.CreateProductos(productos);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestMethodCreateFact()
        {
            GestorController gestor = new GestorController(context);
            Facturacion_db productos = new Facturacion_db();
            productos.idproducto = 2;
            productos.idcliente = 1;
            productos.cantidad = 7;
            productos.precio = 18500;
            productos.fecha = DateTime.Now;
            var result = gestor.CreateEncabezado(productos);
            Assert.IsNotNull(result);

        }
    }
}
