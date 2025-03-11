using Assessment.BaseClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

namespace Assessment.TestCases
{
    [TestClass]
    public class a_LoginTestCase : BaseTest
    {
        Elements.WebElement element = new Elements.WebElement();

        // Method to check if an element is present on the page
        public bool isElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        [TestMethod]
        public void a_LoginUser()
        {
            // Initialize the browser and open the login page
            initBrowser();

            string username = "tomsmith";
            string password = "SuperSecretPassword!";

            Debug.WriteLine("\n" + "LoginUser Test Case Started");

            try
            {

                driver.FindElement(element.username).SendKeys(username);
                Thread.Sleep(500); // Short wait for stability
                driver.FindElement(element.password).SendKeys(password);
                Thread.Sleep(500); // Short wait for stability

                // Click the login button if it exists
                if (isElementPresent(element.loginBtn))
                {
                    driver.FindElement(element.loginBtn).Click();
                }

                // Wait for the page to load completely
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);


                // Verify if the logout button is visible after login
                Assert.IsTrue(isElementPresent(element.logoutBtn), "Logout button is not visible after login!");


                Debug.WriteLine("LoginUser Test Case Ended");

            }

            catch (Exception e)
            {
                Debug.WriteLine("Exception - LoginUser Test Case: " + e);
                Debug.WriteLine(e.StackTrace);

            }
        }
    }
}

