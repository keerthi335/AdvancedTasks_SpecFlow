using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Global;
using static MarsFramework.Global.GlobalDefinitions;
using OpenQA.Selenium;

namespace MarsFramework
{   
          [TestFixture]
        class ShareSkills : Global.Base
        {
            [Test,Order(1)]
            public void ShareYourSkill()
            {
            
            By WaitCondition = By.XPath("//a[@class='ui basic green button']");
            WaitForElement(driver, WaitCondition, 60);

            IWebElement ShareSkillButton = driver.FindElement(By.XPath("//a[@class='ui basic green button']"));
            ShareSkillButton.Click();

            ShareSkill ShareSkillInstance = new ShareSkill();
            ShareSkillInstance.EnterShareSkill();

            //Assertion
            ShareSkillInstance.ValidateShareSkill();
            }
        }
}
