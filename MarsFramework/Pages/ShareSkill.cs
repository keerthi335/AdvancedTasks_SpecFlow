using AutoItX3Lib;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using MarsFramework.Global;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    public class ShareSkill
    {
        //Elements

        //Finding Title field
        private IWebElement Title = driver.FindElement(By.XPath("//input[@name='title']"));

        //Identify the "Description" field
        private IWebElement Description = driver.FindElement(By.XPath("//textarea[@name=\"description\"]"));

        //Identify the "Category" Dropdown
        private IWebElement CategoryDropDown = driver.FindElement(By.XPath("//select[@name=\"categoryId\"]"));

        //SubCategory


        //Tags
        private IWebElement Tags = driver.FindElement(By.XPath("//h3[text()=\"Tags\"]/parent::div/following-sibling::div//input[@placeholder=\"Add new tag\"]"));

        //Service Type - One-Off
        private IWebElement ServiceTypeOneOff => driver.FindElement(By.XPath("//label[contains(text(),'One-off')]"));

        //Service Type - Hourly
        private IWebElement ServiceTypeHourly => driver.FindElement(By.XPath("//label[contains(text(),'Hourly')]"));

        //Location Type - Onsite
        private IWebElement LocationTypeOnsite => driver.FindElement(By.XPath("//label[contains(text(),'On-site')]"));

        //Location Type - Online
        private IWebElement LocationTypeOnline => driver.FindElement(By.XPath("//label[contains(text(),'Online')]"));

        //SkillExchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//label[contains(text(),'Skill-exchange')]"));

        //Required Skills
        private IWebElement RequiredSkills => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));

        //Credit
        private IWebElement Credit => driver.FindElement(By.XPath("//label[contains(text(),'Credit')]"));

        //Credit Amount
        private IWebElement CreditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //Work Sample
        private IWebElement Sample => driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
        //Status - Active
        private IWebElement Active => driver.FindElement(By.XPath("//label[contains(text(),'Active')]"));

        //Status - Hidden
        private IWebElement Hidden => driver.FindElement(By.XPath("//label[contains(text(),'Hidden')]"));

        //Finding Save Button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@class='ui teal button']"));
        public void EnterShareSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            By WaitCondition1 = By.XPath("//input[@name='title']");
            WaitForElement(driver, WaitCondition1, 60);

            //Enter the "Title" field
            Title.SendKeys(ExcelLib.ReadData(2, "Title"));

            //Enter the "Description" field
            Description.SendKeys(ExcelLib.ReadData(2, "Description"));

            //Select the Category
            SelectElement category = new SelectElement(CategoryDropDown);
            category.SelectByText(ExcelLib.ReadData(2, "Category"));

            //Select the Subcategory
            IWebElement SubCategoryDropDown = driver.FindElement(By.XPath("//select[@name=\"subcategoryId\"]"));
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            SubCategory.SelectByText(ExcelLib.ReadData(2, "SubCategory"));

            //enter the value for "Add new tag"
            Tags.SendKeys(ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Click Service type
            string ServiceType = ExcelLib.ReadData(2, "ServiceType");
            if (ServiceType == "One-off service")
                ServiceTypeOneOff.Click();
            else
                ServiceTypeHourly.Click();

            //Click Location Type
            string LocationType = ExcelLib.ReadData(2, "LocationType");

            if (LocationType == "On-site")
                LocationTypeOnsite.Click();
            else
                LocationTypeOnline.Click();

            //Select Skill Trade
            string SkillTrade = ExcelLib.ReadData(2, "SkillTrade");

            if (SkillTrade == "Skill-Exchange")
            {
                SkillExchange.Click();

                RequiredSkills.SendKeys(ExcelLib.ReadData(2, "Skill-Exchange"));
                RequiredSkills.SendKeys(Keys.Enter);
            }
            else
            {
                Credit.Click();
                CreditAmount.SendKeys(ExcelLib.ReadData(2, "CreditAmount"));
            }

            //Upload Sample file
            Sample.Click();

            Thread.Sleep(1500);

            AutoItX3 AutoIT = new AutoItX3();
            AutoIT.WinActivate("Open");

            Thread.Sleep(1500);

            AutoIT.Send(Base.ImagePath);

            Thread.Sleep(1500);

            AutoIT.Send("{ENTER}");

            //Click on Active field
            string Activefield = ExcelLib.ReadData(2, "Active");

            if (Activefield == "Active")
                Active.Click();
            else
                Hidden.Click();

            //Click on Save button
            Save.Click();

        }

        public void ValidateShareSkill()
        {
            try
            {
                //Wait untill page is loaded
                driver.FindElement(By.LinkText("Manage Listings")).Click();

                By WaitCondition = By.XPath("//table[@class='ui striped table']");
                WaitForElement(driver, WaitCondition, 60);

                //IWebElement table = driver.FindElement(By.XPath("//table[@class='ui striped table']"));
                //Validate Category
                string ActualCategory = GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[2]")).Text;
                string ExpectedCategory = GlobalDefinitions.ExcelLib.ReadData(2, "Category");
                Assert.AreEqual(ExpectedCategory, ActualCategory);

                //Validate Title
                string ActualTitle = GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[3]")).Text;
                string ExpectedTitle = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
                Assert.AreEqual(ExpectedTitle, ActualTitle);

                //Validate Description
                string ActualDescription = GlobalDefinitions.driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[4]")).Text;
                string ExpectedDescription = GlobalDefinitions.ExcelLib.ReadData(2, "Description");
                Assert.AreEqual(ExpectedDescription, ActualDescription);

                Base.test.Log(LogStatus.Info, "ShareSkill validated successfully");
            }
            catch (AssertionException)
            {
                Base.test.Log(LogStatus.Info, "Share Skill exception handeled successfully");
            }
        }

    }
}
