using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TesteHypeFlame.PageObject
{
    class PaginaPrincipal
    {
        private IWebDriver _driver;
        private WebDriverWait _espera;

        public IWebElement iconeSobre { get; private set; }
        public IWebElement iconeContato { get; private set; }
        public IWebElement iconeBlog { get; private set; }
        public IWebElement lupaPesquisa { get; private set; }
        public IWebElement campoPesquisa { get; private set; }
        public IWebElement iconeLinkedin { get; private set; }
        public IWebElement iconeInstagran { get; private set; }

        public PaginaPrincipal(IWebDriver driver, WebDriverWait espera)
        {
            _driver = driver;
            _espera = espera;

            PageObject();
        }

        public void PageObject()
        {
            lupaPesquisa = _espera.Until(ExpectedConditions.ElementExists(By.Id(Constantes.ID_LUPA_PESQUISA)));
            campoPesquisa = _espera.Until(ExpectedConditions.ElementExists(By.Name(Constantes.NAME_CAMPO_PESQUISA)));
            iconeSobre = _espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_SOBRE)));
            iconeContato = _espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_CONTATO)));
            iconeBlog = _espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_BLOG)));
            iconeLinkedin = _espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_LINKEDIN)));
            iconeInstagran = _espera.Until(ExpectedConditions.ElementExists(By.XPath(Constantes.XPATH_ICONE_INSTAGRAN)));
        }
    }
}
