using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InoveTeste.PageObject
{
    class ContatoPageObject
    {
        //Campo Nome
        [FindsBy(How = How.Name, Using ="your-name")]
        public IWebElement Nome { get; set; }

        //Campo E-mail
        [FindsBy(How = How.Name, Using = "your-email")]
        public IWebElement Email { get; set; }

        //Campo Assunto
        [FindsBy(How = How.Name, Using = "your-subject")]
        public IWebElement Assunto { get; set; }

        //Campo Mensagem
        [FindsBy(How = How.Name, Using = "your-message")]
        public IWebElement Mensagem { get; set; }

        //Botão Enviar
        [FindsBy(How = How.CssSelector, Using = ".wpcf7-submit")]
        public IWebElement Enviar { get; set; }
    }
}
