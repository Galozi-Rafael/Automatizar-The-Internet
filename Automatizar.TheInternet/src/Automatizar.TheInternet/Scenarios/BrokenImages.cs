using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Playwright;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;


namespace Automatizar.TheInternet.Scenarios
{
    internal class BrokenImages
    {
        public async Task ExecuteAsync(IPage page)
        {
            await page.GotoAsync("https://the-internet.herokuapp.com/broken_images");

            var images = await page.QuerySelectorAllAsync("img");

            using var httpClient = new HttpClient();

            int okCount = 0;
            int brokenCount = 0;

            foreach (var img in images)
            {
                var src = await img.GetAttributeAsync("src");

                if (string.IsNullOrWhiteSpace(src))
                {
                    brokenCount++;
                    Console.WriteLine("Imagem quebrada: src inválido ou nulo.");
                    continue;
                }

                var absoluteUrl = BuildAbsoluteUrl("https://the-internet.herokuapp.com", src);

                try
                {
                    using var response = await httpClient.GetAsync(absoluteUrl, HttpCompletionOption.ResponseHeadersRead);

                    if (response.IsSuccessStatusCode)
                    {
                        okCount++;
                        Console.WriteLine($"OK ({(int)response.StatusCode}) - {absoluteUrl}");
                    }
                    else
                    {
                        brokenCount++;
                        Console.WriteLine($"BROKEN ({(int)response.StatusCode}) - {absoluteUrl}");
                    }
                }
                catch (Exception ex)
                {
                    brokenCount++;
                    Console.WriteLine($"BROKEN (EXCEPTION) - {absoluteUrl} - {ex.Message}");
                }
            }

            Console.WriteLine($"Total ok: {okCount}");
            Console.WriteLine($"Total Broken: {brokenCount}");
        }

        private static string BuildAbsoluteUrl(string baseUrl, string src)
        {
            if (src.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || 
                src.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                return src;
            }

            if (!src.StartsWith("/"))
            {
                src = "/" + src;
            }
            return baseUrl.TrimEnd('/') + src;
        }
    }
}
