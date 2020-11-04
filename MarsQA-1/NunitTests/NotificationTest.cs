using MarsQA_1.Helpers;
using MarsQA_1.NunitPages.Pages;
using MarsQA_1.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.NunitTests
{
    [TestFixture]
    [Category("Notification")]
    class NotificationTest : Start
    {
        public string DashBoardUrl = "http://localhost:5000/Account/Dashboard";
        NotificationPage notification = new NotificationPage();
        CommonPage commonPage = new CommonPage();
        public int RowNumber = 2;//The second row in the SignIn tab of TestData.xls

        #region notification-menu
        [Test, Description("Check if user is able to click on 'Notification'")]
        public void TC_017_01_Click_Notification_Menu()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();

            Assert.IsTrue(notification.getServiceRequestText().Contains("Updated at"));
        }

        [Test, Description("Check if user is able to click on 'Notification'->'Mark all as read'")]
        public void TC_017_02_Click_Notification_MarkAllAsRead()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();
            notification.ClickMarkAllAsReadButton();

            Assert.IsTrue(!notification.isNumberVisible());
        }

        [Test, Description("Check if user is able to click on 'Notification'->'See all'")]
        public void TC_017_03_Click_Notification_SeeAll()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();
            notification.ClickSeeAllButton();

            Assert.AreEqual(DashBoardUrl, Driver.driver.Url);
        }
        #endregion
        #region notification-dashboard
        [Test, Description("Check if user is able to click on 'Load more'")]
        public void TC_018_01_Click_Notification_LoadMore()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();
            notification.ClickSeeAllButton();
            notification.ClickLoadMoreButton();

            Assert.IsTrue(notification.isShowLessButtonVisible());
        }

        [Test, Description("Check if user is able to click on 'ShowLess'")]
        public void TC_018_02_Click_Notification_ShowLess()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();
            notification.ClickSeeAllButton();
            notification.ClickLoadMoreButton();
            notification.ClickShowLessButton();

            Assert.IsTrue(!notification.isShowLessButtonVisible());
        }

        [Test, Description("Check if user is able to Delete for single notification")]
        public void TC_019_01_Delete_Single_Notification()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();
            notification.ClickSeeAllButton();
            notification.TickNotificationItem(0);//0 is the first notification
            notification.ClickDelectSelectionButton();

            Assert.AreEqual("Notification updated", commonPage.getAlertDialogText());
        }

        [Test, Description("Check if user is able to Delete for multiple notifications")]
        public void TC_019_02_Delete_Multiple_Notifications()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();
            notification.ClickSeeAllButton();
            notification.TickNotificationItem(0);//0 is the first notification
            notification.TickNotificationItem(1);//0 is the first notification
            notification.ClickDelectSelectionButton();

            Assert.AreEqual("Notification updated", commonPage.getAlertDialogText());
        }

        [Test, Description("Check if user is able to delete all notifications")]
        public void TC_019_03_Delete_All_Notifications()
        {
            SignIn.OpenForm();
            SignIn.FillCredentials(RowNumber);
            notification.ClickNotificationButton();
            notification.ClickSeeAllButton();
            Thread.Sleep(2000);
            notification.ClickSelectAllButton();
            notification.ClickDelectSelectionButton();

            Assert.AreEqual("Notification updated", commonPage.getAlertDialogText());
        }
        #endregion
    }
}
