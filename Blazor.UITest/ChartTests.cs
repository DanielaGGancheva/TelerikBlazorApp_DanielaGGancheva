using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.Windows;
using Blazor.UITest.PageObjectModules;
using OpenQA.Selenium;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Blazor.UITest
{
    public class ChartTests : IClassFixture<ChromeDriverFixture>
    {
        private readonly ChromeDriverFixture ChromeDriverFixture;
        private readonly ITestOutputHelper output;

        public ChartTests(ChromeDriverFixture chromeDriverFixture, ITestOutputHelper output)
        {
            this.output = output;
            ChromeDriverFixture = chromeDriverFixture;
            ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
        }


        [Trait("Category", "Smoke")]
        [Fact]
        [UseReporter(typeof(BeyondCompareReporter))]
        public void CompareAddingElementInChart()
        {
            output.WriteLine($"{DateTime.Now.ToLongTimeString()} Navigating to DataGrid.");
            var dataGridPage = new DataGridPage(ChromeDriverFixture.Driver);
            dataGridPage.NavigateTo();

            output.WriteLine($"{DateTime.Now.ToLongTimeString()} Add Forecast in Celsious.");
            dataGridPage.AddForecast(null, "4", null, "Test summary");

            output.WriteLine($"{DateTime.Now.ToLongTimeString()} Verify that forecast is properly added.");
            Assert.Equal("4", dataGridPage.ForecastTable[0].tempC);
            Assert.Equal("39", dataGridPage.ForecastTable[0].tempF);
            Assert.Equal("Test summary", dataGridPage.ForecastTable[0].summary);

            output.WriteLine($"{DateTime.Now.ToLongTimeString()} Navigating to Chart page.");
            var chartPage = new ChartPage(ChromeDriverFixture.Driver);
            chartPage.NavigateTo();

            output.WriteLine($"{DateTime.Now.ToLongTimeString()} Take screenshot.");
            ITakesScreenshot screenShotDriver = (ITakesScreenshot)ChromeDriverFixture.Driver;
            Screenshot screenShot = screenShotDriver.GetScreenshot();
            screenShot.SaveAsFile("Chart.bmp", ScreenshotImageFormat.Bmp);

            output.WriteLine($"{DateTime.Now.ToLongTimeString()} Compare creenshot with original.");
            FileInfo file = new FileInfo("Chart.bmp");
            Approvals.Verify(file);
        }
    }
}
