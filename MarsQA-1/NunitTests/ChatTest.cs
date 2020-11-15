using MarsQA_1.NunitPages.Pages;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class ChatTest : Start
    {

        [Test]
        [Category("TC_022_01")]
        public void ClickOnChat()
        {
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(7);

            //Click on chat
            ChatPage.ClickOnChat();

            //Assertion
            ChatPage.AbleToClickOnChatAssertion();
        }

        [Test]
        [Category("TC_022_02")]
        public void SendMessage()
        {
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(7);

            //Click on chat
            ChatPage.ClickOnChat();

            //Type in and send a message on chat
            ChatPage.TypeAndSendMessage();

            //Assertion
            ChatPage.SendMessageAssertion();
        }

        [Test]
        [Category("TC_022_04")]
        public void NumberOfChatNotifications()
        {
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(7);

            //Assertion
            ChatPage.NumberOfMessagesAssertion();

        }

        [Test]
        [Category("TC_023_01")]
        public void UserAbleToClickOtherUser()
        {
            // Sign into Mars Portal
            SignIn.OpenForm();

            //Fill in credentials
            SignIn.FillCredentials(6);

            //Click on Chat
            ChatPage.ClickOnChat();

            //Click on other user on chat room
            ChatPage.ClickUserChat();

            //Assertion
            ChatPage.AbleToClickUsernameAssertion();

        }
    }


}
