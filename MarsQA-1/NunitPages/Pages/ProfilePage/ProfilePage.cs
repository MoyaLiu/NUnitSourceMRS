using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages
{
    class ProfilePages
    {
        #region Initialize Web Elements
        //Main Profile Elements
        private static IWebElement labelGreeting => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        private static IWebElement SignOut => Driver.driver.FindElement(By.XPath("//button[text()='Sign Out']"));
        private static IWebElement buttonEditDescription => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i"));
        private static IWebElement textboxDescription => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
        private static IWebElement buttonSaveDescription => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
        private static IWebElement Description => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        private static IWebElement Name => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));
        private static IWebElement NameIcon => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i"));
        private static IWebElement FirstName => Driver.driver.FindElement(By.XPath("//input[@name='firstName']"));
        private static IWebElement LastName => Driver.driver.FindElement(By.XPath("//input[@name='lastName']"));
        private static IWebElement SaveName => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/button"));
        private static IWebElement AvailabilityEditIcon => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
        private static IWebElement AvailabilityDropdown => Driver.driver.FindElement(By.XPath("//select[@name='availabiltyType']"));
        private static IWebElement AvailabilityEditCancel => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
        private static IWebElement HoursEditIcon => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        private static IWebElement HoursDropdown => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
        private static IWebElement HoursEditCancel => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
        private static IWebElement EarnTargetEditIcon => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        private static IWebElement EarnTargetDropdown => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
        private static IWebElement EarnTargetEditCancel => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
        private static IWebElement ChangePassword => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]"));
        private static IWebElement ShareSkillBtn => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));
        private static IWebElement ManageListingBtn => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
        #endregion

        public static void OpenDescriptionTextfield()
        {
            //Wait for the Profile details to be interactable and clicks it
            WaitHelper.WaitClickble(Driver.driver, buttonEditDescription);
            buttonEditDescription.Click();
            Thread.Sleep(300);

        }
        
        public static void FillDescription(int DataRow)
        {
            //Prepares de ExcelSheet for reading and fills the text field
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");
            textboxDescription.Clear();
            textboxDescription.SendKeys(ExcelLibHelper.ReadData(DataRow, "Description"));
            buttonSaveDescription.Click();

        }

        public static void EditName(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            WaitHelper.WaitClickble(Driver.driver, buttonEditDescription);
            NameIcon.Click();
            FirstName.Clear();
            FirstName.SendKeys(ExcelLibHelper.ReadData(DataRow, "FirstName"));
            LastName.Clear();
            LastName.SendKeys(ExcelLibHelper.ReadData(DataRow, "LastName"));
            SaveName.Click();
            Thread.Sleep(3000);
        }

        public static void FillCardField()
        {
            WaitHelper.WaitClickble(Driver.driver, buttonEditDescription);
            EditAvailability();
            EditHours();
            EditEarnTarget();
        }
        public static void EditHours()
        {
            HoursEditIcon.Click();
            Thread.Sleep(500);
            HoursDropdown.Click();
            HoursDropdown.SendKeys(Keys.ArrowDown+Keys.Enter);
        }

        public static void EditAvailability()
        {
            AvailabilityEditIcon.Click();
            Thread.Sleep(500);
            AvailabilityDropdown.Click();
            AvailabilityDropdown.SendKeys(Keys.ArrowDown+Keys.Enter);
        }

        public static void EditEarnTarget()
        {
            EarnTargetEditIcon.Click();
            Thread.Sleep(500);
            EarnTargetDropdown.Click();
            EarnTargetDropdown.SendKeys(Keys.ArrowDown + Keys.Enter);
        }

        public static void OpenChangePassword()
        {
            CheckProfilePage();
            labelGreeting.Click();
            Thread.Sleep(500);
            ChangePassword.Click();
        }

        public static void LogOut()
        {
            Thread.Sleep(3000);
            SignOut.Click();
            Thread.Sleep(500);
        }

        public static void GoToShareSkill()
        {
            ShareSkillBtn.Click();
        }

        public static void GoToManageListing()
        {
            ManageListingBtn.Click();
        }

        public static void CheckName(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Check if the Name is displayed correctly
            string CheckName = ExcelLibHelper.ReadData(DataRow, "FirstName") + " " + ExcelLibHelper.ReadData(DataRow, "LastName");
            if (Name.Text== CheckName)
            {
                Assert.Pass("The name "+Name.Text+" matches: "+ CheckName);
            }
            else
            {
                Assert.Fail("The name " + Name.Text + " doesn't matches: "+ CheckName);
            }
        }

        public static void CheckProfilePage()
        {
            //Check that we are log-in in the Profile Page by looking for the greeting message
            WaitHelper.WaitClickble(Driver.driver, labelGreeting);

        }

        public static void CheckProfileDescription(int DataRow)
        {
            //Prepares de ExcelSheet for reading
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Check if the description is displayed correctly
            if (Description.Text == ExcelLibHelper.ReadData(DataRow, "Description"))
            {
                Assert.Pass("The description " + Description.Text + " matches: " + ExcelLibHelper.ReadData(DataRow, "Description"));
            }
            else
            {
                Assert.Fail("The description " + Description.Text + " doesn't matches: " + ExcelLibHelper.ReadData(DataRow, "Description"));
            }
        }
    }
}
