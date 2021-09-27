using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TesteHypeFlame.PageObject
{
    class PaginaPesquisa
    {
        public IWebElement tituloPagina;
        public IWebElement campoPesquisa;
        public ReadOnlyCollection<IWebElement> listaArtigos;
        IWebElement artigo;
        IWebDriver driver;
        WebDriverWait espera;

        public PaginaPesquisa(IWebDriver driver, WebDriverWait espera, bool pesquisaValida)
        {
            this.driver = driver;
            this.espera = espera;

            PageObject(pesquisaValida);
        }

        public void PageObject(bool pesquisaValida)
        {
            tituloPagina = espera.Until(ExpectedConditions.ElementExists(By.ClassName(Constantes.CLASS_NAME_TITULO_PAGINA_PESQUISA)));
            campoPesquisa = espera.Until(ExpectedConditions.ElementExists(By.Name(Constantes.NAME_CAMPO_PESQUISA)));

            if (pesquisaValida)
            {
                IWebElement artigo = espera.Until(ExpectedConditions.ElementExists(By.TagName("article")));

                if (artigo != null) listaArtigos = driver.FindElements(By.ClassName("entry-title"));
            }
        }
    }
}
