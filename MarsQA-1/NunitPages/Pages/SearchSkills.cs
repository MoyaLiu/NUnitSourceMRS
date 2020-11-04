using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MarsQA_1.Pages

{
    public static class SearchSkills
    {

        #region Initailize Web Elements
        private static IWebElement SearchBox => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input"));
        private static IWebElement SearchIcon => Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/i"));
        private static IList<IWebElement> getRow => Driver.driver.FindElements(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div"));
        private static IList<IWebElement> getTitle => Driver.driver.FindElements(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p"));
        private static IList<IWebElement> getUsername => Driver.driver.FindElements(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[1]"));
        private static IList<IWebElement> Pagination => Driver.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
        private static IList<IWebElement> AllCategory => Driver.driver.FindElements(By.XPath("//a[@class='item category']"));
        private static IList<IWebElement> Sub_Category => Driver.driver.FindElements(By.XPath("//a[@class='item subcategory']"));
        private static IWebElement userTextBox => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input"));
        private static IWebElement userSearchIcon => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/i"));
        private static IWebElement onlineButton => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]"));
        private static IWebElement onsiteButton => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]"));
        private static IWebElement showAllButton => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]"));
        private static IWebElement Username => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[1]"));
        private static IWebElement RecordTitle => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]/p"));
        private static IWebElement LocationType => Driver.driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]"));
        private static IWebElement ActivePage => Driver.driver.FindElement(By.XPath("//button[@class='ui active button currentPage']"));
        private static IWebElement FirstSkillBox => Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img"));

        #endregion

        //Function To Enter Search Input in Search Box
        public static void EnterText(int DataRow)
        {
            //Wait until find search box
            WaitHelper.WaitClickble(Driver.driver, SearchBox);

            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            //Find and Input Skill in Search TextBox
            SearchBox.SendKeys(ExcelLibHelper.ReadData(DataRow, "Title"));
        }

        //Function to Click on Search Icon
        public static void ClickOnSearchButton()
        {
            //Wait until find Search Icon
            WaitHelper.WaitClickble(Driver.driver, SearchIcon);

            //Click on Search Icon
            SearchIcon.Click();
        }

        //Function
        public static void ClickOnSkills(int DataRow)
        {
            int row = getRow.Count();
            int pageNo = Pagination.Count();
            string a = ExcelLibHelper.ReadData(DataRow, "Title");
            string b = ExcelLibHelper.ReadData(DataRow, "Username");
            for (int j = 2; j <= pageNo; j++)
            {
                for (int i = 0; i < row; i++)
                {
                    if (getTitle[i].Text == a && getUsername[i].Text == b)
                    {
                        getTitle[i].Click();
                        break;
                    }

                }

                Pagination[j].Click();

            }
        }

        //Function for Clicking on Category and sub-category
        public static void ClickOnCategory(int DataRow)
        {
            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");

            WaitHelper.WaitClickble(Driver.driver, AllCategory[5]);
            //Count Category
            var countCategory = AllCategory.Count();
            for (int i = 0; i < countCategory; i++)
            {
                string Category = AllCategory[i].Text;  //Get whole text from web page
                string[] trimmedText = Category.Split(new char[] { '\n' });  //Split by enter
                string CategoryName = trimmedText.First();  //Find first word

                //Check if web Element matches Category in a Excel file
                if (CategoryName == (ExcelLibHelper.ReadData(DataRow, "Category") + "\r"))
                {
                    //Click on Category
                    AllCategory[i].Click();

                    //Count Subcategory
                    var countSubCat = Sub_Category.Count();

                    for (int j = 1; j <= countSubCat; j++)
                    {
                        string subCategory = Sub_Category[j].Text;  //Get whole text from web page
                        string[] trimText = subCategory.Split(new char[] { '\n' });   //Split by enter
                        string subCategoryName = trimText.First();  //Find first word

                        //Check if web Element matches Sub-Category in a Excel file
                        if (subCategoryName == (ExcelLibHelper.ReadData(DataRow, "Sub-Category") + "\r"))
                        {
                            //Click on Sub-Category
                            Sub_Category[j].Click();
                            i--;
                            countCategory = AllCategory.Count();
                            break;
                        }
                    }
                }
            }
        }


        //Function to Enter Name in Search Box
        public static void EnterUserName(int DataRow)
        {
            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "Profile");

            //Enter User name
            userTextBox.SendKeys(ExcelLibHelper.ReadData(DataRow, "FirstName") + " " + ExcelLibHelper.ReadData(DataRow, "LastName"));
            Thread.Sleep(3000);
            userTextBox.SendKeys(Keys.ArrowDown + Keys.Enter);
            Thread.Sleep(2000);

        }

        //Function to Check Search Skills (TC-015-02)
        public static void CheckSearchSkills(int DataRow)
        {
            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "ShareSkill");
            string searchWord = ExcelLibHelper.ReadData(DataRow, "Title");
            string expectedWord = searchWord.ToLower();

            string ExpectedURL = "http://192.168.99.100:5000/Home/Search?searchString=" + searchWord;

            string ActualURL = Driver.driver.Url;

            if (ExpectedURL == ActualURL)
            {
                Assert.Pass("I am at " + searchWord + " Skills Page");
            }
            else
            {
                Assert.Fail(searchWord + " Skills not Found");
            }
        }

        //Function to Check Sub category Search Skills (TC-015-05)
        public static void CheckSubCategory()
        {
            string ExpectedURL = "http://192.168.99.100:5000/Home/Search?cat=ProgrammingTech&subcat=4";

            string ActualURL = Driver.driver.Url;

            if (ExpectedURL != ActualURL)
            {
                Assert.Fail("Not on a Right page");
            }

        }

        //Function to check Search skilll by user name
        public static void CheckSkillByUsername(int DataRow)
        {
            //Prepares the Excel Sheet
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.ExcelPath, "SignUp");
            if (Username.Text == (ExcelLibHelper.ReadData(DataRow, "FirstName") + " " + ExcelLibHelper.ReadData(DataRow, "LastName")))
            {
                Assert.Pass("Successfully on user page");
            }
            else
            {
                Assert.Fail("Not found User");
            }
        }

        //Function to click on online filter
        public static void ClickOnOnline()
        {
            //Wait until finds Online Button
            WaitHelper.WaitClickble(Driver.driver, onlineButton);

            //Click on Online button
            onlineButton.Click();
            Thread.Sleep(7000);
        }

        //Function to check filter by online
        public static void CheckClickOnOnline()
        {
            RecordTitle.Click();

            if (LocationType.Text == "Online")
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }


        //Function to click on online filter
        public static void ClickOnOnsite()
        {
            //Wait until finds Online Button
            WaitHelper.WaitClickble(Driver.driver, onsiteButton);

            //Click on Online button
            onsiteButton.Click();
            Thread.Sleep(7000);
        }

        public static void ClickOnOnFirstBox()
        {
            //Wait until finds Online Button
            WaitHelper.WaitClickble(Driver.driver, FirstSkillBox);

            //Click on Online button
            FirstSkillBox.Click();
            Thread.Sleep(2000);
        }

        //Function to check filter by online
        public static void CheckClickOnsite()
        {
            RecordTitle.Click();

            if (LocationType.Text == "On-Site")
            {
                Assert.Pass("Test pass got " + LocationType.Text + " Page");
            }

        }

        //Function to click on online filter
        public static void ClickOnShowAll()
        {
            //Wait until finds Online Button
            WaitHelper.WaitClickble(Driver.driver, showAllButton);

            //Click on Online button
            showAllButton.Click();

            WaitHelper.WaitClickble(Driver.driver, Pagination[3]);
            int pageNo = Pagination.Count();
            for (int i = 0; i < pageNo; i++)
            {
                if (Pagination[i].Text == "145")
                {
                    Pagination[i].Click();
                    break;
                }

            }
        }

        //function to check Last page
        public static void CheckLastPage()
        {
            if (ActivePage.Text == "145")
            {
                Assert.Pass();
            }
        }
    }
}
