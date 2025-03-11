using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Assessment.BaseClass
{
    public class BaseTest
    {
        public static IWebDriver driver;

        public void initBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");

            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(60));
            driver.Manage().Window.Maximize();

            //URL 
            string UrlToOpen = "https://the-internet.herokuapp.com/login";

            driver.Url = UrlToOpen;
        }


        public void tearDown()
        {
            driver.Quit();
        }

    }
}
