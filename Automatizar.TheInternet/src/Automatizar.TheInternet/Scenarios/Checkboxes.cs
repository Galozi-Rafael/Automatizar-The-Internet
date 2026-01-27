using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;

namespace Automatizar.TheInternet.Scenarios
{
    internal class Checkboxes
    {
        // Cria o método para executar o cenário de checkboxes.
        public async Task ExecuteAsync(IPage page)
        {
            await page.GotoAsync("https://the-internet.herokuapp.com/checkboxes");
            
            var checkboxes = await page.QuerySelectorAllAsync("input[type='checkbox']");
            
            for (int i = 0; i < checkboxes.Count; i++)
            {
                var checkbox = checkboxes[i];
                var isChecked = await checkbox.IsCheckedAsync();

                Console.WriteLine($"Checkbox {i + 1} inicialmente {(isChecked ? "marcado" : "desmarcado")}.");

                // Manter o estado do checkbox
                if (!isChecked)
                {
                    await checkbox.UncheckAsync();
                }
                else
                {
                    await checkbox.CheckAsync();

                }

                var newState = await checkbox.IsCheckedAsync();

                Console.WriteLine($"Checkbox {i + 1} agora {(newState ? "marcado" : "desmarcado")}.");
            }
        }
    }
}
