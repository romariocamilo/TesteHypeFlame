using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace TesteHypeFlame.PageObject
{
    class PaginaBlog
    {
        public IWebElement tituloPagina;
        IWebDriver driver;
        WebDriverWait espera;

        public PaginaBlog(IWebDriver driver, WebDriverWait espera)
        {
            this.driver = driver;
            this.espera = espera;

            PageObject();
        }

        public void PageObject()
        {
            tituloPagina = espera.Until(ExpectedConditions.ElementExists(By.ClassName(Constantes.CLASS_NAME_TITULO_PAGINA_BLOG)));
        }
    }
}
