using Assessment.BaseClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assessment.TestCases
{
    [TestClass]
    public class B_TableTestCase : BaseTest
    {
        Elements.WebElement element = new Elements.WebElement();

        [TestMethod]
        public void A_TableHandling()
        {
            Debug.WriteLine("\n" + "Table Handling Test Case Started");

            try
            {
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");

                // Call generic function to extract table data
                List<Dictionary<string, string>> tableData = ExtractTableDataById("table1");

                // Print extracted data
                foreach (var row in tableData)
                {
                    Console.WriteLine($"First Name: {row["First Name"]}, Last Name: {row["Last Name"]}");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception - Table Handling Test Case: " + e);
                Debug.WriteLine(e.StackTrace);
            }
        }

        public List<Dictionary<string, string>> ExtractTableDataById(string tableId)
        {
            List<Dictionary<string, string>> tableData = new List<Dictionary<string, string>>();

            try
            {
                var rows = driver.FindElements(By.XPath($"//table[@id='{tableId}']/tbody/tr"));
                var headers = driver.FindElements(By.XPath($"//table[@id='{tableId}']/thead/tr/th"));

                foreach (var row in rows)
                {
                    Dictionary<string, string> rowData = new Dictionary<string, string>();

                    for (int i = 0; i < headers.Count; i++)
                    {
                        string columnName = headers[i].Text.Trim();
                        string cellValue = row.FindElement(By.XPath($"./td[{i + 1}]")).Text.Trim();
                        rowData[columnName] = cellValue;
                    }

                    tableData.Add(rowData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error extracting table: " + e.Message);
            }

            return tableData;
        }
    }
}