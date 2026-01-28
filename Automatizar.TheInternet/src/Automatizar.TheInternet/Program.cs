using System;
using System.Threading.Tasks;
using Automatizar.TheInternet.Infrastructure;
using Automatizar.TheInternet.Scenarios;


namespace Automatizar.TheInternet
{
    // Ponto de entrada da aplicação.
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            // Cria a página do Playwright.
            var page = await PlaywrightFactory.CreatePageAsync();
            // Cria página com autenticação.
            var pageAuth = await PlaywrightFactory.CreatePageWithAuthAsync("admin", "admin");
            
            
            #region AB Test 
            // Cria a instância do cenário AB Test.
            var abTest = new ABTest();
            // Executa o cenário AB Test.
            await abTest.ExecuteAsync(page);
            #endregion

            #region Add Remove Elements
            // Cria a instância do cenário Add Remove Elements.
            var AddRemoveElements = new AddRemoveElements();
            // Executa o cenário Add Remove Elements.
            await AddRemoveElements.ExecuteAsync(page);
            #endregion

            #region BasicAuth
            
            // cria a instância do cenário Basic Auth.
            var basicAuth = new BasicAuth();
            // Executa o cenário Basic Auth.
            await basicAuth.ExecuteAsync(pageAuth);
            #endregion

            #region Digest Auth
            // Cria a instância do cenário Digest Auth.
            var digestAuth = new DigestAuth();
            // Executa o cenário Digest Auth.
            await digestAuth.ExecuteAsync(pageAuth);
            #endregion

            #region Broken Images
            // Cria a instância do cenário BrokenImages
            var brokenImages = new BrokenImages();
            // Executa o cenário BronkenImages
            await brokenImages.ExecuteAsync(page);
            #endregion

            #region Checkboxes
            // Cria a instância do cenário ChallengingDOM
            var challengingDOM = new ChallengingDOM();
            var buttonsDOM = new ChallengingDOM.ButtonsDOM();
            var tableDOM = new ChallengingDOM.TableDOM();
            var canvasDOM = new ChallengingDOM.CanvasDOM();
            #endregion

            #region ChallengingDOM
            // Executa o cenário ChallengingDOM
            await buttonsDOM.ButtonsExecuteAsync(page);
            await tableDOM.TableExecuteAsync(page);
            await canvasDOM.CanvasExecuteAsync(page);

            // Cria a instância do cenário Checkboxes
            var checkboxes = new Checkboxes();
            // Executa o cenário Checkboxes
            await checkboxes.ExecuteAsync(page);
            #endregion
            
            #region Context Menu
            // Cria a instância do cenário Context Menu
            var contextMenu = new ContextMenu();
            // Executa o cenário Context Menu
            await contextMenu.ExecuteAsync(page);
            #endregion

            #region Desappearing Elements
            // Cria a instância do cenário Disappearing Elements
            var desappearingElements = new DisappearingElements();
            // Executa o cenário Disappearing Elements
            await desappearingElements.ExecuteAsync(page);
            #endregion

            Console.ReadKey();
        }
    }
}