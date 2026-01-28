using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Automatizar.TheInternet.Scenarios
{
    internal class DigestAuth
    {
        public async Task ExecuteAsync(IPage page)
        {
            // Implementar o cenário de autenticação Digest aqui.
            await page.GotoAsync("https://the-internet.herokuapp.com/digest_auth");

            // Captura a mensagem de sucesso da autenticação.
            var message = await page.Locator("p").InnerTextAsync();

            if (string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Falha ao capturar a mensagem de autenticação.");
                return;
            }
            else
            {
                Console.WriteLine($"Mensagem retornada: {message}");
            }
            

            // Verifica se a mensagem contém o texto de sucesso.
            bool success = message.Contains("Congratulations!");
        }
    }
}
