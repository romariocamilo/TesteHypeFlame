using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TesteHypeFlame.PageObject
{
    class PaginaPrincipal
    {
        IWebDriver driver;
        WebDriverWait espera;

        public IWebElement iconeSobre;
        public IWebElement iconeContato;
        public IWebElement iconeBlog;
        public IWebElement lupaPesquisa;
        public IWebElement campoPesquisa;
        public IWebElement iconeLinkedin;
        public IWebElement iconeInstagran;

        public PaginaPrincipal(IWebDriver driver, WebDriverWait espera)
        {
            this.driver = driver;
            this.espera = espera;

            PageObject();
        }

        public void PageObject()
        {
            lupaPesquisa = espera.Until(ExpectedConditions.ElementExists(By.Id(Constantes.ID_LUPA_PESQUISA)));
            campoPesquisa = espera.Until(ExpectedConditions.ElementExists(By.Name(Constantes.NAME_CAMPO_PESQUISA)));
            iconeSobre = espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_SOBRE)));
            iconeContato = espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_CONTATO)));
            iconeBlog = espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_BLOG)));
            iconeLinkedin = espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_LINKEDIN)));
            iconeInstagran = espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_INSTAGRAN)));
        }
    }
}
