using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Automatizar.TheInternet.Scenarios
{
    internal class ChallengingDOM
    {
        public class ButtonsDOM
        {
            public async Task ButtonsExecuteAsync(IPage page)
            {
                await page.GotoAsync("https://the-internet.herokuapp.com/challenging_dom");
                // Clica no botão azul
                await page.ClickAsync(".button");
                // Clica no botão vermelho
                await page.ClickAsync(".button.alert");
                // Clica no botão verde
                await page.ClickAsync(".button.success");
            }
        }

        public class TableDOM
        {
            public async Task TableExecuteAsync(IPage page)
            {
                await page.GotoAsync("https://the-internet.herokuapp.com/challenging_dom");
                
                var tableHeader = await page.QuerySelectorAllAsync("table thead th");
                var rows = await page.QuerySelectorAllAsync("table tbody tr");
                var headers = new List<string>();
                
                // Extrai o cabeçalho da tabela
                foreach (var header in tableHeader)
                {
                    var text = await header.InnerTextAsync();
                    headers.Add(text);
                }
                Console.WriteLine(string.Join(" | ", headers));

                // Extrai os dados da tabela
                foreach (var row in rows)
                {
                    var columns = await row.QuerySelectorAllAsync("td");
                    var rowData = new List<string>();
                    foreach (var column in columns)
                    {
                        var text = await column.InnerTextAsync();
                        rowData.Add(text);
                    }
                    Console.WriteLine(string.Join(" | ", rowData));
                }
            }
        }

        public class CanvasDOM
        {
            public async Task CanvasExecuteAsync(IPage page)
            {
                await page.GotoAsync("https://the-internet.herokuapp.com/challenging_dom");
                // Verifica se o elemento canvas está presente
                var canvas = await page.QuerySelectorAsync("#canvas");
                if (canvas != null)
                {
                    Console.WriteLine("Canvas has found.");
                }
                else
                {
                    Console.WriteLine("Canvas not found.");
                }


            }
        }

    }
}
