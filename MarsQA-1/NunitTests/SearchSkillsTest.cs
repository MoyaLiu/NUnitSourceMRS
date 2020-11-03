using MarsQA_1.Helpers;
using MarsQA_1.NunitPages.Pages;
using MarsQA_1.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    class SearchSkillTest : Driver
    {
        #region Start
        [SetUp]
        public void Setup()
        {
            //launch the browser
            Initialize();
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "TestData");

        }

        [TearDown]
        public void TearDown()
        {
            //Screenshot
            string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");

            //Close the browser
            Close();

        }
        #endregion

        [Test]// Test Case 015-002
        [Category("")]
        public void SearchSkillByInput()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if user is able to Enter Skill in Search box
            SearchSkills.EnterText(2);

            //Check if user is able to click on search icon
            SearchSkills.ClickOnSearchButton();

            //check if search for particular input
            SearchSkills.CheckSearchSkills(2);

        }

        [Test]// Test Case 015-005
        [Category("")]
        public void SearchSkillBySubcategory()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if user is able to click on search icon
            SearchSkills.ClickOnSearchButton();

            //Check if user is able to click on Category and Sub category respectively
            SearchSkills.ClickOnCategory(3);

            //Check if user is at right page
            SearchSkills.CheckSubCategory();

        }


        [Test]// Test Case 015-007
        [Category("")]
        public void SearchSkillByUsername()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if user is able to click on search icon
            SearchSkills.ClickOnSearchButton();

            //Check if user is able to input username
            SearchSkills.EnterUserName(5);

            //Check if user is able to find all record of user
            SearchSkills.CheckSkillByUsername(5);

        }


        [Test]// Test Case 016-02
        [Category("")]
        public void FilterByOnline()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if user is able to click on search icon
            SearchSkills.ClickOnSearchButton();

            //Check if user is able to click on Online filter
            SearchSkills.ClickOnOnline();

            //Check if user is at right page
            SearchSkills.CheckClickOnOnline();
        }


        [Test]// Test Case 016-03
        [Category("")]
        public void FilterByOnsite()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if user is able to click on search icon
            SearchSkills.ClickOnSearchButton();

            //Check if user is able to click on On-site filter
            SearchSkills.ClickOnOnsite();

            //Check if user is at right page
            SearchSkills.CheckClickOnsite();

        }


        [Test]// Test Case 016-07
        [Category("")]
        public void LastPageNavi()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(2);

            //Check if user is able to click on search icon
            SearchSkills.ClickOnSearchButton();

            //Check if user is able to click on Show All Button
            SearchSkills.ClickOnShowAll();

            //Check if user is at Last Page
            SearchSkills.CheckLastPage();
        }
    }
}
