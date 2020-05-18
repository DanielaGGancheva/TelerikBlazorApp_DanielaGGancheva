using Blazor.UITest.PageObjectModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Blazor.UITest
{
    public class Home
    {
        public class HomeNav : IClassFixture<ChromeDriverFixture>
        {
            private readonly ChromeDriverFixture ChromeDriverFixture;
            private readonly ITestOutputHelper output;

            public HomeNav(ChromeDriverFixture chromeDriverFixture, ITestOutputHelper output)
            {
                this.output = output;
                ChromeDriverFixture = chromeDriverFixture;
                ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
            }


            [Trait("Category", "Smoke")]
            [Fact]
            public void OpenLinksOnHomePage()
            {
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Navigating to HomePage.");
                var homePage = new HomePage(ChromeDriverFixture.Driver);
                homePage.NavigateTo();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Open link to ChartPage.");
                ChartPage chartPage = homePage.OpenChartLink();
                chartPage.EnsurePageLoaded();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Go BACK to HomePage.");
                ChromeDriverFixture.Driver.Navigate().Back();
                homePage.EnsurePageLoaded();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Open link to DataGridPage.");
                DataGridPage dataGridPage = homePage.OpenDataGridLink();
                dataGridPage.EnsurePageLoaded();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Go BACK to HomePage.");
                ChromeDriverFixture.Driver.Navigate().Back();
                homePage.EnsurePageLoaded();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Refresh HomePage.");
                ChromeDriverFixture.Driver.Navigate().Refresh();
                homePage.EnsurePageLoaded();

            }
        }
    }
}
