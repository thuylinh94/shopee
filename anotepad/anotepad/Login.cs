using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace anotepad
{
    class Login
    {
            private IWebDriver driver;
            public string homeURL;

        [SetUp]
            public void SetupTest()
            {
                driver = new ChromeDriver("D:\\driver\\chromedriver.exe");
            }

        [Test]
            public void Login_Fail()
            {
                homeURL = "https://anotepad.com/";
                driver.Navigate().GoToUrl(homeURL);
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

                IWebElement loginPageLnk = driver.FindElement(By.XPath("//a[@href='create_account']"));
                loginPageLnk.Click();

                IWebElement loginTxtBx = driver.FindElement(By.Id("loginEmail"));
                loginTxtBx.SendKeys("linhnguyen4@gmail.com");

                IWebElement pwdTxtbox = driver.FindElement(By.Id("password"));
                pwdTxtbox.SendKeys("123456");

                IWebElement loginBtn = driver.FindElement(By.Id("submit"));
                loginBtn.Click();   

                Assert.AreEqual("Email and password do not match", loginBtn.GetAttribute("text"));
            }

            [TearDown]
            public void TearDownTest()
            {
                driver.Close();
            }            
        }
}