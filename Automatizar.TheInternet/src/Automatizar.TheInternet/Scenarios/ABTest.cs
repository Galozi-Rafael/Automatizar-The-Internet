using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automatizar.TheInternet.Scenarios
{
    // Cria o teste para saber se a página carregada é A ou B.
    public class ABTest
    {
        // Captura as informações sobre a página e realiza o test.
        public async Task ExecuteAbTestAsync(IPage page)
        {
            await page.GotoAsync("https://the-internet.herokuapp.com/abtest");

            var heading = await page.Locator("h3").InnerTextAsync();

            Console.WriteLine($"Texto exibido: {heading}");

            if (heading.Contains("Variation"))
            {
                Console.WriteLine("Variação B detectada");
            }
            else
            {
                Console.WriteLine("Variação A detectada");
            }
        }
    }
}
