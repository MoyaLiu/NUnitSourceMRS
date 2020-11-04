using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private IWebElement NotificationButton => WaitHelper.WaitClickble(Driver.driver,  By.XPath("//div[contains(@class,'ui top left pointing dropdown item')]"), 5);
        private IWebElement MarkAllAsRead => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div/center/a[text() = 'Mark all as read']"), 5);
        private IWebElement SeeAll => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div/center/a[@href]"), 5);
        private IWebElement LoadMore => WaitHelper.WaitClickble(Driver.driver, By.XPath("//a[@class = 'ui button'][text() = 'Load More...']"), 5);
        private IWebElement ShowLess => WaitHelper.WaitClickble(Driver.driver, By.XPath("//a[@class = 'ui button'][text() = '...Show Less']"), 5);
        private IWebElement SelectAll => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div[@class = 'ui icon basic button'][@data-tooltip = 'Select all']"), 10);
        private IWebElement DeleteSelection => WaitHelper.WaitClickble(Driver.driver, By.XPath("//div[@class = 'ui icon basic button'][@data-tooltip = 'Delete selection']"), 10);
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

    }
}
