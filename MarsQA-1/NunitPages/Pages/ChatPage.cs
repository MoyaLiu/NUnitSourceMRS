using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;


namespace MarsQA_1.NunitPages.Pages
{
    class ChatPage
    {
        #region Page Elements

        private static IWebElement chatIcon => Driver.driver.FindElement(By.XPath("//i[@class='comment outline icon']"));
        private static IWebElement chatRoomHeader => Driver.driver.FindElement(By.XPath("//*[contains(text(),'Chat room')]"));
        private static IWebElement typeMessageTextBox => Driver.driver.FindElement(By.Id("chatTextBox"));
        private static IWebElement sendMessageButton => Driver.driver.FindElement(By.Id("btnSend"));
        private static IWebElement findMessageSent => Driver.driver.FindElement(By.XPath("//div[@class='message-container']//span[contains(text(),'IndustryConnect2')]"));
        private static IWebElement userChat => Driver.driver.FindElement(By.XPath("//div[@class='header' and contains(text(),'John')]"));
        #endregion

        public static void ClickOnChat()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//i[@class='comment outline icon']", 5);
            chatIcon.Click();
        }

        public static void TypeAndSendMessage()
        {
            typeMessageTextBox.Click();
            typeMessageTextBox.SendKeys("IndustryConnect2");
            sendMessageButton.Click();
        }

        public static bool NumberOfMessagesAssertion()
        {
            try
            {
                Driver.driver.FindElement(By.XPath("//div[@class='floating ui teal label']"));
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static void AbleToClickOnChatAssertion()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//*[contains(text(),'Chat room')]", 5);
            if (chatRoomHeader.Text == "Chat room")
            {
                Assert.Pass("User is able to go to Chat room!");
            }
            else
            {
                Assert.Fail("User not able to go to Chat room!");
            }
        }

        public static void SendMessageAssertion()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//span[contains(text(),'IndustryConnect2')]", 5);
            if (findMessageSent.Text == "IndustryConnect2")
            {
                Assert.Pass("Message sent successfully!");
            }
            else
            {
                Assert.Fail("Message not sent!");
            }
        }

        public static void ClickUserChat()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[@class='header' and contains(text(),'John')]", 5);
            userChat.Click();
        }

        public static void AbleToClickUsernameAssertion()
        {
            WaitHelper.ElementIsVisible(Driver.driver, "Xpath", "//div[@class='message-container']//span[contains(text(),'IndustryConnect2')]", 5);
            Assert.IsTrue(userChat.Enabled);
        }

    }
}
