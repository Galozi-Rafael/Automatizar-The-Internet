using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Automatizar.TheInternet.Scenarios
{
    //Cria a classe que irá adicionar e remover botões.
    public class AddRemoveElements
    {
        public async Task ExecuteAsync(IPage page)
        {
            await page.GotoAsync("https://the-internet.herokuapp.com/add_remove_elements/");

            // Acha o botão para adicionar  e adiciona 5 botões de delete.
            var addButton = page.Locator("button:has-text('Add Element')");

            int amount = 5;

            for (int i = 0; i < amount; i++)
            {
                await addButton.ClickAsync();
            }
                
            // Localiza os botões delete criados e os apaga um por um.
            var delButton = page.Locator("button.added-manually");

            // Método para contar quantidade de elementos em uma página.
            int totalDel = await delButton.CountAsync();

            Console.WriteLine($"Botões Delete criados: {totalDel}");

            for (int i = 0; i < totalDel; i ++)
            {
                await delButton.First.ClickAsync();
            }

            int totalLeft = await delButton.CountAsync();

            Console.WriteLine($"Botões Delete restantes: {totalLeft}");
        }
    }
}
