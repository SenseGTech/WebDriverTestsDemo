using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;


        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            //Act
            driver.Url = "https://softuni.bg";
            string expectedTitle = "Îáó÷åíèå ïî ïðîãðàìèðàíå - Ñîôòóåðåí óíèâåðñèòåò";
            
            //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
          
        }
        [Test]
        public void Test_AssertAboutUsTitle()
        {
    
            //Act
           
            var ZanasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            ZanasElement.Click();
            string expectedTitle = "Çà íàñ - Ñîôòóåðåí óíèâåðñèòåò";

            //Assert
            Assert.AreEqual(expectedTitle, driver.Title);
          
        }
        [Test]
        public void test_Login_InvalidUsernameAndPassword()
        {
           
           //Invalid Login
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("user1");
            driver.FindElement(By.Id("password-input")).SendKeys("user1");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector("li")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));
            driver.Close();
        }
    }
}
