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
            await abTest.ExecuteAbTestAsync(page);

            Console.ReadKey();
        }
    }
}