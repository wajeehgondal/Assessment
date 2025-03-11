using Assessment.BaseClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace Assessment.TestCases
{
    [TestClass]
    public class c_JavaScriptTestCase : BaseTest
    {
        Elements.WebElement element = new Elements.WebElement();

        [TestMethod]
        public void A_JSHandling()
        {
            Debug.WriteLine("\n" + "JavaScript Alert Handling Test Case Started");

            try
            {
                // Navigate to the JavaScript alert test page
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");

                // Handle JS Alert
                HandleJavaScriptAlert("//button[text()='Click for JS Alert']", true, null);

                // Handle JS Confirm
                HandleJavaScriptAlert("//button[text()='Click for JS Confirm']", true, null);

                // Handle JS Prompt
                HandleJavaScriptAlert("//button[text()='Click for JS Prompt']", true, "Test Input");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception - JavaScript Alert Handling Test Case: " + e);
                Debug.WriteLine(e.StackTrace);
            }
        }

        // Method to handle different types of JavaScript alerts
        public void HandleJavaScriptAlert(string buttonXPath, bool accept, string inputText)
        {
            try
            {
                // Click the button to trigger the alert
                driver.FindElement(By.XPath(buttonXPath)).Click();
                IAlert alert = driver.SwitchTo().Alert();

                Debug.WriteLine("Alert Text: " + alert.Text);

                // If input is required (JS Prompt), send input text
                if (inputText != null)
                {
                    alert.SendKeys(inputText);
                }

                // Accept or dismiss the alert
                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error handling JavaScript alert: " + e.Message);
            }
        }
    }
}

