using Assessment.BaseClass;
using OpenQA.Selenium;

namespace Assessment.Elements
{
    public class WebElement : BaseTest
    {
        #region Login Elements

        public By username = By.Id("username");
        public By password = By.Id("password");
        public By loginBtn = By.XPath("//*[@id=\"login\"]/button");
        public By logoutBtn = By.XPath("//*[@id=\"content\"]/div/a");

        #endregion


        #region Tables

        public By tableRows = By.XPath("//table[@id='table1']/tbody/tr");

        #endregion



        #region File

        public By chooseFileBtn = By.Id("file-upload");
        public By fileUploadBtn = By.Id("file-submit");
        public By uploadedFile = By.Id("uploaded-files");

        #endregion




        #region File

        #endregion
    }
}
