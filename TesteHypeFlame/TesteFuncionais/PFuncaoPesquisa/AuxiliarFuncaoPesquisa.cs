using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TesteHypeFlame.PageObject;

namespace TesteHypeFlame.TesteFuncionais.PFuncaoPesquisa
{
    class AuxiliarFuncaoPesquisa
    {
        public IWebDriver driver { get; private set; }
        public WebDriverWait espera { get; private set; }
        public PaginaPrincipal paginaPrincipal;
        public PaginaPesquisa paginaPesquisa { get; private set; }
        public PaginaBlog paginaBlog { get; private set; }


        public AuxiliarFuncaoPesquisa()
        {
            (driver, espera) = Configuracao.RetornaConfiguracoes();
        }

        public void RealizaPesquisaInvalida(string pesquisa)
        {
            paginaPrincipal.lupaPesquisa.Click();
            paginaPrincipal.campoPesquisa.SendKeys(pesquisa);
            paginaPrincipal.campoPesquisa.Submit();

            paginaPesquisa = new PaginaPesquisa(driver, espera, false);
        }

        public void RealizaPesquisaValida(string pesquisa)
        {
            paginaPrincipal.lupaPesquisa.Click();
            paginaPrincipal.campoPesquisa.SendKeys(pesquisa);
            paginaPrincipal.campoPesquisa.Submit();

            paginaPesquisa = new PaginaPesquisa(driver, espera, true);
        }

        public string AcessaArtigoPesquisado(string pesquisa, int posicao)
        {
            paginaPrincipal.lupaPesquisa.Click();
            paginaPrincipal.campoPesquisa.SendKeys(pesquisa);
            paginaPrincipal.campoPesquisa.Submit();

            paginaPesquisa = new PaginaPesquisa(driver, espera, true);
            string tituloBlog = "";


            tituloBlog = paginaPesquisa.listaArtigos[posicao].Text;
            paginaPesquisa.listaArtigos[posicao].Click();

            paginaBlog = new PaginaBlog(driver, espera);

            return tituloBlog;
        }
    }
}
