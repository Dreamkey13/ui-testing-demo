#define REMOTE

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using Xunit;


namespace GoogleUiTests3
{
    public class ChromeNode2TestCollection : IDisposable
    {
        private IWebDriver driver;
        public ChromeNode2TestCollection()
        {
#if REMOTE
            var options = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), options.ToCapabilities());
#else
            driver = new ChromeDriver();
#endif
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }
        }

        //[Theory]
        [InlineData("ECU Computer Science Programs")]
        [InlineData("Twitter Elon Musk")]
        [InlineData("Poison Pill Twitter")]
        public void Should_Open_Default_Page(string query)
        {
            // arrange
            var expectedTitle = "Google";
            var expectedUrl = "https://www.google.com/";
            driver.Navigate().GoToUrl(expectedUrl);

            // act
            var actualTitle = driver.Title;
            var actualUrl = driver.Url;

            // assert
            Assert.Equal(expectedTitle, actualTitle);
            Assert.Equal(expectedUrl, actualUrl);

            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys(query);
            searchBox.Submit();

            DemoHelper.Pause();
        }
    }
}
