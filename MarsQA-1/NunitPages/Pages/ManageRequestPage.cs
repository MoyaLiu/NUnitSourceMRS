using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages
{
    class ManageRequestPage
    {
        #region Initialize WebElements
        private static IWebElement ManageRequestDropdown => Driver.driver.FindElement(By.XPath("//div[text()='Manage Requests']"));
        private static IWebElement ReceivedRequestOption => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]"));
        private static IWebElement SentRequestOption => Driver.driver.FindElement(By.XPath("//a[text()='Sent Requests']"));
        private static IWebElement AcceptButton => Driver.driver.FindElement(By.XPath("//button[text()='Accept']"));
        private static IWebElement DeclineButton => Driver.driver.FindElement(By.XPath("//button[text()='Decline']"));
        private static IWebElement CompleteButton => Driver.driver.FindElement(By.XPath("//button[text()='Complete']"));
        private static IWebElement CompletedButton => Driver.driver.FindElement(By.XPath("//button[text()='Completed']"));
        private static IWebElement WithdrawButton => Driver.driver.FindElement(By.XPath("//button[text()='Withdraw']"));
        private static IWebElement RequestTitle => Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[2]/a"));
        private static IWebElement RequestStatus => Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]"));
        private static IWebElement RequestButton => Driver.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]"));
        private static IWebElement RequestAcceptButton => Driver.driver.FindElement(By.XPath("/html/body/div[4]/div/div[3]/button[1]"));
        private static IWebElement SentStatus => Driver.driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[5]"));
        private static IWebElement SentTitle => Driver.driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[2]/a"));
        private static IWebElement LogOutButton => Driver.driver.FindElement(By.XPath("//button[text()='Sign Out']"));
        private static IWebElement Alert => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div"));
        #endregion

        public static void GenerateNewRequest(int Profile)
        {
            if (Profile == 2)
            {
                Thread.Sleep(3000);
                Driver.driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home/ServiceDetail?id=5f90766151f40e000141e9b3");
            }
            else
            {
                SignIn.OpenForm();
                SignIn.FillCredentials(Profile);
                ProfilePages.CheckProfilePage();
                Driver.driver.Navigate().GoToUrl("http://192.168.99.100:5000/Home/ServiceDetail?id=5f678a0708945f000120afb3");
            }
            Thread.Sleep(2000);
            RequestButton.Click();
            //Thread.Sleep(1000);
            RequestAcceptButton.Click();
            Thread.Sleep(2000);
            if (Profile != 2)
            {
                LogOutButton.Click();
            }
            else
            {
                Driver.driver.Navigate().GoToUrl("http://192.168.99.100:5000/Account/Profile");
            }
            Thread.Sleep(500);
        }

        public static void SentRequest()
        {
            //Check if there is a Request button and clicks it
            WaitHelper.WaitClickble(Driver.driver, RequestButton);
            RequestButton.Click();

            //Clicks on the Accept Request alert and waits for 2 second for the page to load
            RequestAcceptButton.Click();
            Thread.Sleep(2000);
        }

        public static void AcceptRequestWithOtherUser()
        {
            ProfilePages.LogOut();
            SignIn.OpenForm();
            SignIn.FillCredentials(5);
            ProfilePages.CheckProfilePage();
            NavigateToReceivedRequest();
            AcceptRequest();
            Thread.Sleep(3000);
            LogOutButton.Click();
            SignIn.OpenForm();
            SignIn.FillCredentials(2);
            ProfilePages.CheckProfilePage();
            NavigateToSentRequest();
        }

        public static void NavigateToReceivedRequest()
        {
            ManageRequestDropdown.Click();
            WaitHelper.WaitClickble(Driver.driver, ReceivedRequestOption);
            ReceivedRequestOption.Click();
        }

        public static void NavigateToSentRequest()
        {
            ManageRequestDropdown.Click();
            WaitHelper.WaitClickble(Driver.driver, SentRequestOption);
            SentRequestOption.Click();
        }

        public static void AcceptRequest()
        {
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, AcceptButton);
            AcceptButton.Click();
        }

        public static void DeclineRequest()
        {
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, DeclineButton);
            DeclineButton.Click();
        }

        public static void WithdrawRequest()
        {
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, WithdrawButton);
            WithdrawButton.Click();
        }

        public static void CompleteRequest()
        {
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, CompleteButton);
            CompleteButton.Click();
        }

        public static void CompletedRequest()
        {
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, CompletedButton);
            CompletedButton.Click();
        }

        public static void CheckReceivedRequest()
        {
            //Waits for the elements to load
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, RequestTitle);

            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            //Compares the request title with the "Add Skill Share" or "Edit Skill Share" test cases
            if (RequestTitle.Text == ExcelLibHelper.ReadData(2, "Title") || RequestTitle.Text == ExcelLibHelper.ReadData(3, "Title") || RequestTitle.Text == "TitleText")
            {
                Assert.Pass("Request Title Found!");
            }
            else
            {
                Assert.Fail(RequestTitle.Text + "::doesn't match::" + ExcelLibHelper.ReadData(2, "Title") + "::nor::" + ExcelLibHelper.ReadData(3, "Title"));
            }

        }

        public static void CheckSentRequest()
        {
            //Waits for the elements to load
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, SentTitle);

            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            //Compares the request title with the "Add Skill Share" or "Edit Skill Share" test cases
            if (SentTitle.Text == ExcelLibHelper.ReadData(2, "Title") || SentTitle.Text == ExcelLibHelper.ReadData(3, "Title") || SentTitle.Text == "TitleText" || SentTitle.Text == "DevOps")
            {
                Assert.Pass("Request Title Found!");
            }
            else
            {
                Assert.Fail(SentTitle.Text + "::doesn't match::" + ExcelLibHelper.ReadData(2, "Title") + "::nor::" + ExcelLibHelper.ReadData(3, "Title"));
            }

        }

        public static void CheckNewRequestStatus(string SpectedStatus)
        {
            Thread.Sleep(1000);
            //Refresh the page to update the listing
            Driver.driver.Navigate().Refresh();
            WaitHelper.LongWait();
            WaitHelper.WaitClickble(Driver.driver, RequestTitle);

            //Check if the newest request status matches the expected status
            if (RequestStatus.Text == SpectedStatus)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(RequestStatus.Text + "::Doesn't match::" + SpectedStatus);
            }
        }

        public static void CheckNewSentStatus(string SpectedStatus)
        {
            Thread.Sleep(1000);
            //Refresh the page to update the listing
            Driver.driver.Navigate().Refresh();
            Thread.Sleep(5000);
            WaitHelper.WaitClickble(Driver.driver, SentStatus);

            //Check if the newest request status matches the expected status
            if (SentStatus.Text == SpectedStatus)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail(SentStatus.Text + "::Doesn't match::" + SpectedStatus);
            }
        }

        public static void CheckAlert()
        {
            Thread.Sleep(1000);
            if (Alert.Text == "Service has been updated")
            {
                Assert.Pass("Alert Found!");
            }
            else
            {
                Assert.Fail(Alert.Text + "::Alert doesn't match::Service has been updated");
            }
        }
    }
}