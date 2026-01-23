using System;
using System.Threading.Tasks;
using Automatizar.TheInternet.Infrastructure;
using Automatizar.TheInternet.Scenarios;

namespace Automatizar.TheInternet
{
    // Ponto de entrada da aplicação.
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Cria a página do Playwright.
            var page = await PlaywrightFactory.CreatePageAsync();
            // Cria a instância do cenário AB Test.
            var abTest = new ABTest();
            // Executa o cenário AB Test.
            await abTest.ExecuteAsync(page);

            // Cria a instância do cenário Add Remove Elements.
            var AddRemoveElements = new AddRemoveElements();
            // Executa o cenário Add Remove Elements.
            await AddRemoveElements.ExecuteAsync(page);

            // Cria página com autenticação.
            var pageAuth = await PlaywrightFactory.CreatePageWithAuthAsync("admin", "admin");
            // cria a instância do cenário Basic Auth.
            var basicAuth = new BasicAuth();
            // Executa o cenário Basic Auth.
            await basicAuth.ExecuteAsync(pageAuth);

            // Cria a instância do cenário BrokenImages
            var brokenImages = new BrokenImages();
            // Executa o cenário BronkenImages
            await brokenImages.ExecuteAsync(page);

            Console.ReadKey();
        }
    }
}