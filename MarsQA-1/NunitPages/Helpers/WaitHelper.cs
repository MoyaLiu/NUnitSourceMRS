using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQA_1.Helpers
{
    class WaitHelper
    {
        public static void WaitClickble(IWebDriver driver, IWebElement element)
        {
            Thread.Sleep(1000);
            try
            {
                var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch(Exception error)
            {
                Assert.Fail("Time out to find element: "+error);
            }


        }
        public static IWebElement WaitClickble(IWebDriver driver, IWebElement element, int timeout)
        {
            try
            {
                var Wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException error)
            {
                Assert.Fail("Time out to find element: " + error);
                return null;
            }
        }
        public static IWebElement WaitClickble(IWebDriver driver, By locator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeout));
                return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("The element is not clickable, time out, " + ex.Message);
                return null;
            }
        }

        public static bool CheckClickable(IWebElement element)
        {
            try
            {
                element.Click();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void LongWait()
        {
            Thread.Sleep(60000);
        }

        public static bool WaitVisible(IWebDriver webDriver, By locator, int timeout)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("The element is not visible, time out, " + ex.Message);
                return false;
            }
        }
    }
}
