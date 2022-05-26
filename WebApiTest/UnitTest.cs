using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
