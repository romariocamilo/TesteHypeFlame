using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TesteHypeFlame
{
    static class Configuracao
    {
        private static IWebDriver _driver;
        private static WebDriverWait _espera;

        public static (IWebDriver, WebDriverWait) RetornaConfiguracoes()
        {
            _driver = new ChromeDriver();
            _espera = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            return (_driver, _espera);
        }
    }
}
