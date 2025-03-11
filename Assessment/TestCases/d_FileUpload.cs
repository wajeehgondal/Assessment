using Assessment.BaseClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;

namespace Assessment.TestCases
{
    [TestClass]
    public class d_FileUploadTestCase : BaseTest
    {
        Elements.WebElement element = new Elements.WebElement();

        [TestMethod]
        public void a_FileUpload_UsingInputSimulator()
        {
            Debug.WriteLine("\n" + "File Upload using InputSimulator Test Case Started");

            try
            {
                // Navigate to file upload page
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
                Thread.Sleep(4000); // Wait for the page to load

                // Locate the file input field and send file path
                IWebElement fileInput = driver.FindElement(element.chooseFileBtn);
                fileInput.SendKeys(@"D:\file.txt");

                // Click the submit button
                driver.FindElement(element.fileUploadBtn).Click();
                Thread.Sleep(2000);

                // Verify file upload success
                string uploadedFileName = driver.FindElement(element.uploadedFile).Text;
                Assert.AreEqual("file.txt", uploadedFileName, "File upload failed!");

                Debug.WriteLine("File Upload Successful");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception - File Upload Test Case: " + e);
                Debug.WriteLine(e.StackTrace);
            }

            finally
            {
                // Close browser after execution

                Debug.WriteLine("Executing Finally Block - Closing Browser.");
                if (driver != null)
                {
                    driver.Quit();
                }
            }

        }
    }
}

