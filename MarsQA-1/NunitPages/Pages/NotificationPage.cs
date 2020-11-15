using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.NunitPages.Pages
{
    class NotificationPage
    {
        #region elements
        
        //Moya's Section
        private IWebElement NotificationButton => WaitHelper.WaitClickble(Driver.driver,  By.XPath("//div[contains(@class,'ui top left pointing dropdown item')]"), 5);
        private IWebElement MarkAllAsRead => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div/center/a[text() = 'Mark all as read']"), 5);
        private IWebElement SeeAll => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div/center/a[@href]"), 5);
        private IWebElement LoadMore => WaitHelper.WaitClickble(Driver.driver, By.XPath("//a[@class = 'ui button'][text() = 'Load More...']"), 5);
        private IWebElement ShowLess => WaitHelper.WaitClickble(Driver.driver, By.XPath("//a[@class = 'ui button'][text() = '...Show Less']"), 5);
        private IWebElement SelectAll => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div[@class = 'ui icon basic button'][@data-tooltip = 'Select all']"), 10);
        private IWebElement DeleteSelection => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div[@class = 'ui icon basic button'][@data-tooltip = 'Delete selection']"), 10);
        
        //Bruno's Section
        private static IWebElement notifications => Driver.driver.FindElement(By.XPath("//i[@class='icon list']"));
        private static IWebElement seAll => Driver.driver.FindElement(By.XPath("//*[contains(text(), 'See All...')]"));
        private static IWebElement selectServiceRequestTickBox => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']"));
        private static IWebElement selectServiceRequestTickBox2 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']"));
        private static IWebElement selectServiceRequestTickBox3 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']"));
        private static IWebElement selectServiceRequestTickBox4 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']"));
        private static IWebElement selectServiceRequestTickBox5 => Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']"));
        private static IWebElement selectAll => Driver.driver.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
        private static IWebElement unselectAll => Driver.driver.FindElement(By.XPath("//div[@class='ui icon basic button button-icon-style']"));
        private static IWebElement markSelectionAsRead => Driver.driver.FindElement(By.XPath("//i[@class='check square icon']"));
        private static IWebElement popUpMessageSelectionRead => Driver.driver.FindElement(By.XPath("//div[contains(text(),'Notification updated')]"));
        #endregion

        #region locators
        private By ServiceRequest = By.XPath("//div[@class = 'extra']/div[@id = 'myDIV']");
        private By ShowLessLocator = By.XPath("//a[@class = 'ui button'][text() = '...Show Less']");
        private By NumberLocator = By.XPath("//div[@class = 'floating ui blue label']");
        private By NoNotificationLocator = By.XPath("//div[@class = 'ui items segment']/span/div[@class = 'item']");
        #endregion

        #region methods
        internal void ClickNotificationButton()
        {
            Thread.Sleep(2000);
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(NotificationButton).Perform();
        }
        internal void ClickMarkAllAsReadButton()
        {
            MarkAllAsRead.Click();
        }
        internal void ClickSeeAllButton()
        {
            SeeAll.Click();
        }
        internal void ClickLoadMoreButton()
        {
            LoadMore.Click();
        }
        internal void ClickShowLessButton()
        {
            ShowLess.Click();
        }
        internal void ClickSelectAllButton()
        {
            SelectAll.Click();
        }
        internal void ClickDelectSelectionButton()
        {
            DeleteSelection.Click();
        }
        internal void TickNotificationItem(int i)
        {
            //i: The index of the notification item in the notification list
            var itemWebElement = "//input[@type = 'checkbox'][@value = '" + i.ToString() + "']";
            Console.WriteLine("item index is " + i + ", element locator path = " + itemWebElement);
            WaitHelper.WaitClickble(Driver.driver, By.XPath(itemWebElement), 10).Click();
        }
        #endregion

        #region assertion
        internal string getServiceRequestText()
        {
            WaitHelper.WaitVisible(Driver.driver, ServiceRequest, 5);
            return Driver.driver.FindElement(ServiceRequest).Text;
        }
        internal string getNoNotificationText()
        {
            WaitHelper.WaitVisible(Driver.driver, NoNotificationLocator, 5);
            return Driver.driver.FindElement(NoNotificationLocator).Text;
        }
        internal bool isShowLessButtonVisible()
        {
            return WaitHelper.WaitVisible(Driver.driver, ShowLessLocator, 5);
        }
        internal bool isNumberVisible()
        {
            Thread.Sleep(3000);
            return WaitHelper.WaitVisible(Driver.driver, NumberLocator, 2);
        }
        #endregion

        #region Bruno's Methods

        public static void ClickNotifications()
        {
            notifications.Click();
        }

        public static void SeeAllNotifications()
        {
            //Click on See All notifications
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//*[contains(text(), 'See All...')]", 5);
            seAll.Click();

        }

        public static void SelectServiceRequest()
        {
            //Select SINGLE service request with checkbox
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//input[@type='checkbox' and @value='0']", 5);
            selectServiceRequestTickBox.Click();
        }

        public static void SelectMultipleServiceRequests()
        {
            //Select MULTIPLE service requests with checkbox
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//input[@type='checkbox' and @value='0']", 5);
            selectServiceRequestTickBox.Click();
            selectServiceRequestTickBox2.Click();
            selectServiceRequestTickBox3.Click();
        }

        public static void SelectAllServiceRequests()
        {
            //WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//i[@class='mouse pointer icon']", 5);
            Thread.Sleep(5000);
            selectAll.Click();
        }

        public static void MarkSelection()
        {
            //Click on mark selection as read
            markSelectionAsRead.Click();
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[contains(text(),'Notification updated')]", 5);
        }

        public static void MarkAsReadAssertion()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[contains(text(),'Notification updated')]", 5);
            if (popUpMessageSelectionRead.Text == "Notification updated")
            {
                Assert.Pass("Notification record updated successfully!");
            }
            else
            {
                Assert.Fail("Notification record not updated!");
            }
        }

        public static void AllServiceRequestsSelectedAssertion()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[@class='ui icon basic button button-icon-style']", 5);
            try
            {
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']")).Selected);
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']")).Selected);

            }
            catch (Exception e)
            {

            }
        }

        public static void UnselectAllServiceRequests()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[@class='ui icon basic button button-icon-style']", 5);
            unselectAll.Click();
        }

        public static void UnselectAllAssertion()
        {
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='0']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='1']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='2']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='3']")).Selected);
            Assert.IsFalse(Driver.driver.FindElement(By.XPath("//input[@type='checkbox' and @value='4']")).Selected);

        }

        #endregion

    }
}
