using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace InoveTeste.Comandos
{
    class Comandos
    {
        #region Navegador
        public static IWebDriver Navegador(IWebDriver driver, string navegador)
        {
            switch (navegador)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("https://cursos.inoveteste.com.br/contato");
                    driver.Manage().Window.Maximize();
                    driver.FindElement(By.CssSelector("#main-menu-item-420 span")).Click();
                    break;
                case "Internet Explorer":
                    driver.Navigate().GoToUrl("https://cursos.inoveteste.com.br/contato");
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    driver.FindElement(By.CssSelector("#main-menu-item-420 span")).Click();
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    driver.Navigate().GoToUrl("https://cursos.inoveteste.com.br/contato");
                    driver.Manage().Window.Maximize();
                    driver.FindElement(By.CssSelector("#main-menu-item-420 span")).Click();
                    break;
            }
            return driver;
        }
        #endregion

        #region Javascript
        public static void ExecutarJavaScript(IWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(script);
        }
        #endregion
    }
}
