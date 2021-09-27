using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TesteHypeFlame.PageObject;
using TesteHypeFlame.TesteFuncionais.PFuncaoPesquisa;

namespace TesteHypeFlame
{
    class FuncaoPesquisa
    {
        private AuxiliarFuncaoPesquisa _auxiliarFuncaoPesquisa;

        [SetUp]
        public void Setup()
        {
            _auxiliarFuncaoPesquisa = new AuxiliarFuncaoPesquisa();
            _auxiliarFuncaoPesquisa.driver.Manage().Window.Maximize();
            _auxiliarFuncaoPesquisa.driver.Navigate().GoToUrl("https://hypeflame.blog/blog/");

            _auxiliarFuncaoPesquisa.paginaPrincipal = new PaginaPrincipal(_auxiliarFuncaoPesquisa.driver, _auxiliarFuncaoPesquisa.espera);
        }

        [TestCase("Nenhum resultado", "blogs hyper", TestName = "Realiza uma pesquisa inválida")]
        public void RealizaPesquisaInvalidaTeste(string titulo, string pesquisa)
        {
            _auxiliarFuncaoPesquisa.RealizaPesquisaInvalida(pesquisa);

            Assert.AreEqual(titulo, _auxiliarFuncaoPesquisa.paginaPesquisa.tituloPagina.Text);
            Assert.AreEqual(pesquisa, _auxiliarFuncaoPesquisa.paginaPesquisa.campoPesquisa.GetAttribute("value"));
        }

        [TestCase("Resultados da busca por: Segurança", "Segurança", TestName = "Realiza uma pesquisa válida - Segurança")]
        [TestCase("Resultados da busca por: Golpes", "Golpes", TestName = "Realiza uma pesquisa válida - Golpes")]
        public void RealizaPesquisaValidaTest(string titulo, string pesquisa)
        {
            _auxiliarFuncaoPesquisa.RealizaPesquisaValida(pesquisa);

            Assert.AreEqual(titulo, _auxiliarFuncaoPesquisa.paginaPesquisa.tituloPagina.Text);
            Assert.AreEqual(pesquisa, _auxiliarFuncaoPesquisa.paginaPesquisa.campoPesquisa.GetAttribute("value"));
        }

        [TestCase("Segurança", 1, TestName = "Acessar um artigo pesquisado - Posição 1 ")]
        [TestCase("Segurança", 5, TestName = "Acessar um artigo pesquisado - Posição 6")]
        public void AcessaArtigoPesquisadoTest(string pesquisa, int posicao)
        {
            string tituloBlog = _auxiliarFuncaoPesquisa.AcessaArtigoPesquisado(pesquisa, posicao);

            Assert.AreEqual(tituloBlog, _auxiliarFuncaoPesquisa.paginaBlog.tituloPagina.Text, "Passou");
        }

        [TearDown]
        public void TearDown()
        {
            _auxiliarFuncaoPesquisa.driver.Close();
            _auxiliarFuncaoPesquisa.driver.Dispose();
        }
    }
}