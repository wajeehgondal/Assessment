# Selenium Automation Test Suite  

## Overview  
This project contains automated test cases using **Selenium WebDriver** with **C# and MSTest**.  
The test cases validate different functionalities of the website given in the Assessment.  

---

## Project Structure  
The following test files are included in the project:  

1. **BaseTest.cs** - Sets up and tears down the WebDriver.  
2. **LoginTest.cs** - Automates login functionality with validation.  
3. **TableTest.cs** - Extracts and verifies table data.  
4. **AlertTest.cs** - Handles JavaScript alerts (pop-ups).  
5. **FileTest.cs** - Automates file upload functionality. **As I am using the C# - Visual Studio, so Robot Class is not compatible with it.
6. **WebElements.cs - Stored the web elements used in the test classes

---

## Setup & Prerequisites  

### 1 Install Required Tools  
Ensure you have the following installed:  

- **Visual Studio** (Latest Version)  
- **.NET SDK**  
- **Selenium WebDriver**  
- **ChromeDriver   

### 2 Install Required NuGet Packages  
Goto the Tools and open the NuGet Manager and install the following:  

Selenium.WebDriver
Selenium.Support
MSTest.TestAdapter
MSTest.TestFramework
