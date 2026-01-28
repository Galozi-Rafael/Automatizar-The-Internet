using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automatizar.TheInternet.Scenarios
{
    internal class ContextMenu
    {
        // Método para executar o cenário de menu de contexto.
        public async Task ExecuteAsync(IPage page)
        {
            await page.GotoAsync("https://the-internet.herokuapp.com/context_menu");

            // Adiciona um evento para capturar o diálogo de alerta.
            page.Dialog += async (_, dialog) =>
            {
                Console.WriteLine($"Dialog message: {dialog.Message}");
                await dialog.AcceptAsync();
            };

            // Realiza um clique com o botão direito no elemento com id "hot-spot".
            await page.Locator("#hot-spot").ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right
            });
        }
    }
}
