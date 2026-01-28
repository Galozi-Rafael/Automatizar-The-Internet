using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automatizar.TheInternet.Scenarios
{
    internal class DisappearingElements
    {
        // Método para executar o cenário Disappearing Elements.
        public async Task ExecuteAsync(IPage page)
        {
            await page.GotoAsync("https://the-internet.herokuapp.com/disappearing_elements");

            // Conta o número de botões no menu.
            var menuButtons = await page.Locator("ul li").CountAsync();

            // Tenta localizar o botão "Gallery".
            var galleryButton = page.GetByRole(AriaRole.Link, new() { Name = "Gallery" });

            // Verifica se o botão "Gallery" está visível e exibe a mensagem apropriada.
            if (await galleryButton.IsVisibleAsync())
            {
                var name = await galleryButton.InnerTextAsync();
                Console.WriteLine($"Menu com {menuButtons} botões. O botão {name} foi encontrado");
            }
            else
            {
                Console.WriteLine($"Menu com {menuButtons} botões. Nenhum outro botão foi encontrado");
            }
        }
    }
}
