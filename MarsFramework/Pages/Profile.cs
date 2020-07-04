﻿using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace MarsFramework
{
    internal class Profile
    {
        private IWebElement ProfileDropDownBox = GlobalDefinitions.driver.FindElement(By.XPath("//span[@tabindex=\"0\"]"));

        internal void ChangePassword()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Change Password");

            //Select Change Password in Useraccount
            ProfileDropDownBox.Click();           

            //wait untill Change Password option under Profile is visible
            WebDriverWait wait = new WebDriverWait(GlobalDefinitions.driver, TimeSpan.FromSeconds(30));
            IWebElement ChangePassword = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@tabindex=\"0\"]//a[contains(text(),'Change Password')]")));
            ChangePassword.Click();

            //Send OldPassword through Excel
            GlobalDefinitions.driver.FindElement(By.Name("oldPassword")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Old Password"));

            //Send New Password through Excel
            GlobalDefinitions.driver.FindElement(By.Name("newPassword")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "New Password"));

            //Send Confirm Password through Excel
            GlobalDefinitions.driver.FindElement(By.Name("confirmPassword")).SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Confirm Password"));

            //Click on Save button
            GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui button ui teal button']")).Click();

        }

        public bool ValidateChangePassword(IWebDriver driver)
        {
            try
            {
                driver.FindElement(By.XPath("//button[text()='Sign Out']"));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}