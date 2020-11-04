using MarsQA_1.Helpers;
using NUnit.Framework;
using static MarsQA_1.Helpers.CommonMethods;

namespace MarsQA_1.Utils
{
    [TestFixture]
    public class Start : Driver
    {

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
            //test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(img));

            //Close the browser
            Close();

        }
    }
}
