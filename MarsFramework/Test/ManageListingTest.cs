using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
        [TestFixture]
        [Category("Sprint1")]
        class ManageListingTest : Global.Base
        {
            [Test,Order(2)]
            public void EditListingTest()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.EditListings();

                bool EditResult = manageListings.ValidateEdit(Global.GlobalDefinitions.driver);
                Assert.IsTrue(EditResult);
            }

            [Test,Order(3)]
            public void DeleteListingTest()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.DeleteListings();

                bool DelResult = manageListings.ValidateDelete(Global.GlobalDefinitions.driver);
                Assert.IsTrue(DelResult);
            }

        }
    
}