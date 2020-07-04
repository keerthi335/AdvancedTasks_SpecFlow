using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsFramework.Global.GlobalDefinitions;


namespace MarsFramework
{
    [TestFixture]
    class ProfileTest : Global.Base
    {
        [Test,Order(4)]
        public void ChangePassword()
        {
            By WaitCondition = By.XPath("//span[@tabindex='0']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            Profile profile = new Profile();
            profile.ChangePassword();

            bool PwdChgResult = profile.ValidateChangePassword(Global.GlobalDefinitions.driver);
            Assert.IsTrue(PwdChgResult);
        }

    }
}
