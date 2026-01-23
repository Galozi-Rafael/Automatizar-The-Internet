using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Automatizar.TheInternet.Scenarios
{
    internal class BasicAuth
    {
        // Método para realizar autenticação básica em uma página.
        public async Task ExecuteAsync(IPage page)
        {
            await page.GotoAsync("https://the-internet.herokuapp.com/basic_auth");

            // Captura a mensagem de sucesso da autenticação.
            var message = await page.Locator("p").InnerTextAsync();

            Console.WriteLine($"Mensagem retornada: {message}");

            // Verifica se a mensagem contém o texto de sucesso.
            bool success = message.Contains("Congratulations!");

            Console.WriteLine($"Autenticação bem sucedida: {success}");

        }
    }
}
