using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        //Elements
        //Finding ManageListings Button
        private IWebElement ManageListingsTab => GlobalDefinitions.driver.FindElement(By.XPath("//a[@href='/Home/ListingManagement']"));

        //Finding Edit Button
        //private IWebElement EditButton => GlobalDefinitions.driver.FindElement(By.XPath())
        internal void EditListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");

            By WaitCond1 = By.XPath("//a[@href='/Home/ListingManagement']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCond1, 60);
            
            ManageListingsTab.Click();

            By WaitCondition = By.XPath("//th[text()='Image']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            string Editrecord = GlobalDefinitions.ExcelLib.ReadData(2, "EditTitle");
            
            GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'" + Editrecord + "')]//following-sibling::td//child::i[@class='outline write icon']")).Click();
            
            By WaitCond = By.XPath("//input[@name='title']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCond, 60);

            ShareSkill EditSkillInstance = new ShareSkill();
            EditSkillInstance.EnterShareSkill();
                        
        }

        public bool ValidateEdit(IWebDriver driver)
        {
            driver.FindElement(By.LinkText("Manage Listings")).Click();

            By WaitCondition = By.XPath("(//button[@class='ui button'])[1]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);
            try
            {
                driver.FindElement(By.XPath("//td[contains(text(),'" + GlobalDefinitions.ExcelLib.ReadData(2, "Title") + "')]"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteListings()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "DeleteAction");

            By WaitCondition = By.XPath("//a[contains(text(),'Manage')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            //Click on ManageListings tab
            ManageListingsTab.Click();

            By WaitCondition1 = By.XPath("//th[text()='Image']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);

            string Deleterecord = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            
            IWebElement delete = GlobalDefinitions.driver.FindElement(By.XPath("//td[contains(text(),'" + Deleterecord + "')]//following-sibling::td//child::i[@class='remove icon']"));
            
            //Click on Delete button
            delete.Click();

            //Click Yes on Popup window
            // GlobalDefinitions.driver.SwitchTo().Alert().Accept();

            GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']")).Click();

        }

        public bool ValidateDelete(IWebDriver driver)
        {
            By WaitCondition = By.XPath("//th[contains(text(),'Title')]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            try
            {
                driver.FindElement(By.XPath("//th[contains(text(),'" + GlobalDefinitions.ExcelLib.ReadData(2, "Title") + "')]"));
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
