using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.DTOs.Category.Request;
using POS.Application.Interfaces;
using POS.Utilities.Static;

namespace POS.Test.Category
{
    [TestClass]
    public class CategoryApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        // Pruebas de integración: Identifica que los diferentes componentes de una aplicación funcionen correctamente
        // Clase para inicializar todos los servicios y poder inyectarlos en los test. Valida si lo que esperamos es lo que obtenemos
        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new WebApplicationFactory<Program>();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingNullValuesOrEmpty_ValidationErrors()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

            // Arrange: Vamos a prepara una solictud
            var name = "";
            var description = "";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_VALIDATE;

            // Act: Ejecutar el método que se va a probar
            var result = await context!.RegisterCategory(new CategoryRequestDTO()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = result.Message;

            // Assert: Verificar que el resultado es el esperado
            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public async Task RegisterCategory_WhenSendingCorrectValues_RegisteredSuccessfully()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<ICategoryApplication>();

            // Arrange: Vamos a prepara una solictud
            var name = "Nuevo registro";
            var description = "Nueva descripción";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_SAVE;

            // Act: Ejecutar el método que se va a probar
            var result = await context!.RegisterCategory(new CategoryRequestDTO()
            {
                Name = name,
                Description = description,
                State = state
            });
            var current = result.Message;

            // Assert: Verificar que el resultado es el esperado
            Assert.AreEqual(expected, current);
        }

    }

}
