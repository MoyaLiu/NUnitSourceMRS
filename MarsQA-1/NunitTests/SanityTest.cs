using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.SanityTest
{
    [TestFixture]
    class SanityTest:Start
    {
        [Test]
        public static void HappyPathAsLearner()
        {
            //LogIn
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if user is able to click on search icon
            SearchSkills.ClickOnSearchButton();

            //Check if user is able to input username
            SearchSkills.EnterUserName(4);

            //Check if user can open a Skill Box
            SearchSkills.ClickOnOnFirstBox();

            //Sent a request for an already opened Skill
            ManageRequestPage.SentRequest();

            //Go to manage request page
            ManageRequestPage.NavigateToSentRequest();

            //The User checks the new request
            ManageRequestPage.CheckNewSentStatus("Pending");
        }

        [Test]
        public static void HappyPathAsSeller()
        {
            //LogIn
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Create a new skill to trade
            ProfilePages.GoToShareSkill();
            ShareSkillPage.FillShareSkill(2);
            Thread.Sleep(3000);

            //LogsOut to allow the second user to request the Skill
            ProfilePages.LogOut();
            ManageRequestPage.GenerateNewRequest(5);

            //LogIn with the main account
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Navigate to Manage Received Request and accepts the Trade
            ManageRequestPage.NavigateToReceivedRequest();
            ManageRequestPage.AcceptRequest();

            //The User checks the new request
            ManageRequestPage.CheckNewRequestStatus("Accepted");

        }
    }
}
