using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TesteHypeFlame.PageObject;

namespace TesteHypeFlame.TesteFuncionais
{
    class FuncaoRedirecionamento
    {
        private IWebDriver _driver;
        private WebDriverWait _espera;

        private PaginaPrincipal _paginaPrincipal;

        [SetUp]
        public void Setup()
        {
            (_driver, _espera) = Configuracao.RetornaConfiguracoes();

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://hypeflame.blog/blog/");

            _paginaPrincipal = new PaginaPrincipal(_driver, _espera);
        }
        
        [TestCase("LinkedIn", "LinkedIn", "lazy-loaded", TestName = "Redireciona para o linkedin")]
        [TestCase("Instagran", "HypeFlame", "rhpdm", TestName = "Redireciona para o instagran")]
        public void RedirecionaSiteExterno(string site, string titulo, string className)
        {
            switch(site)
            {
                case "LinkedIn":
                    _paginaPrincipal.iconeLinkedin.Click();
                    IWebElement tituloLinkedin = _espera.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
                    Assert.AreEqual(titulo.Trim(), tituloLinkedin.GetAttribute("alt"));
                    break;

                case "Instagran":
                    _paginaPrincipal.iconeInstagran.Click();
                    IWebElement tituloInstagran = _espera.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
                    Assert.AreEqual(titulo.Trim(), tituloInstagran.Text.Trim());
                    break;
            }
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
