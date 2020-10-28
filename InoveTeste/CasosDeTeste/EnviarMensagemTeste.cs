using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using InoveTeste.PageObject;
using InoveTeste.Comandos;

namespace CasosDeTeste
{
    [TestFixture]
    public class ContatoTeste
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;

        [SetUp]
        public void SetUp()
        {
            driver = Comandos.Navegador(driver, ConfigurationManager.AppSettings["navegador"]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void EnviarMensagemTeste()
        {
            // Verifica se os campos da tela estão habilitados
            ContatoPageObject contato = new ContatoPageObject();
            PageFactory.InitElements(driver, contato);

            Assert.IsTrue(contato.Nome.Displayed && contato.Nome.Enabled);
            Assert.IsTrue(contato.Email.Displayed && contato.Email.Enabled);
            Assert.IsTrue(contato.Assunto.Displayed && contato.Assunto.Enabled);
            Assert.IsTrue(contato.Mensagem.Displayed && contato.Mensagem.Enabled);
            Assert.IsTrue(contato.Enviar.Displayed && contato.Enviar.Enabled);

            // Clica em enviar para Enviar para verificar as mensagens de campos obrigatórios
            contato.Enviar.Click();

            // Verifica mensagens de obrigatoriedade
            Assert.That(driver.FindElement(By.CssSelector(".your-name > .wpcf7-not-valid-tip")).Text, Is.EqualTo("O campo é obrigatório."));
            Assert.That(driver.FindElement(By.CssSelector(".your-email > .wpcf7-not-valid-tip")).Text, Is.EqualTo("O campo é obrigatório."));
            Assert.That(driver.FindElement(By.CssSelector(".your-subject > .wpcf7-not-valid-tip")).Text, Is.EqualTo("O campo é obrigatório."));
            Assert.That(driver.FindElement(By.CssSelector(".your-message > .wpcf7-not-valid-tip")).Text, Is.EqualTo("O campo é obrigatório."));
            Assert.That(driver.FindElement(By.CssSelector(".wpcf7-response-output")).Text, Is.EqualTo("Um ou mais campos possuem um erro. Verifique e tente novamente."));

            // Preenche os campos da tela com valores válidos e envia
            driver.FindElement(By.Name("your-name")).SendKeys("Luís Fernando da Silveira");
            driver.FindElement(By.Name("your-email")).SendKeys("fernandinholfs@hotmail.com");
            driver.FindElement(By.Name("your-subject")).SendKeys("Curso de Automação de Testes Selenium com C#");
            driver.FindElement(By.Name("your-message")).SendKeys("Estou enviando essa mensagem conforme a aula de recording usando o Selenium ID");
            contato.Enviar.Click();

            // Verifica se exibe mensagem sobre sucesso do envio
            Thread.Sleep(2500);
            Assert.That(driver.FindElement(By.CssSelector(".wpcf7-response-output")).Text, Is.EqualTo("Agradecemos a sua mensagem."));
        }
    }
}
