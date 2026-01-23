using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Automatizar.TheInternet.Infrastructure
{
    // Classe que cria e configura a instancia do Playwright e do navegador
    public static class PlaywrightFactory
    {
        public static async Task<IPage> CreatePageAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser =  await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            // Cria um novo contexto de navegador.
            // Permitindo que cada execução seja um ambiente isolado.
            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();

            return page;
        }

        public static async Task<IPage> CreatePageWithAuthAsync(string username, string password)
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

            // Cria um novo contexto de navegador com autenticação HTTP.
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                HttpCredentials = new HttpCredentials
                {
                    Username = username,
                    Password = password
                }
            });

            var page = await context.NewPageAsync();

            return page;
        }
    }
}
