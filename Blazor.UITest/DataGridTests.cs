using Blazor.UITest.PageObjectModules;
using OpenQA.Selenium;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Blazor.UITest
{
    public class DataGridTests
    {

        public class AddForecast : IClassFixture<ChromeDriverFixture>
        {
            private readonly ChromeDriverFixture ChromeDriverFixture;
            private readonly ITestOutputHelper output;
  
            public AddForecast(ChromeDriverFixture chromeDriverFixture, ITestOutputHelper output)
            {
                this.output = output;
                ChromeDriverFixture = chromeDriverFixture;
                ChromeDriverFixture.Driver.Navigate().GoToUrl("about:blank");
            }


            [Trait("Category", "Smoke")]
            [Fact]
            public void AddForecastsWithTemperatureInCelsious()
            {
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Navigating to DataGrid.");
                var dataGridPage = new DataGridPage(ChromeDriverFixture.Driver);
                dataGridPage.NavigateTo();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Add Forecast in Celsious.");
                dataGridPage.AddForecast(null, "4",null,"Test summary");

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Verify that forecast is properly added.");
                Assert.Equal("4", dataGridPage.ForecastTable[0].tempC);
                Assert.Equal("39", dataGridPage.ForecastTable[0].tempF);
                Assert.Equal("Test summary", dataGridPage.ForecastTable[0].summary);

            }

            [Trait("Category", "Smoke")]
            [Fact]
            public void AddForecastsWithTemperatureInFahrenheit()
            {
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Navigating to DataGrid.");
                var dataGridPage = new DataGridPage(ChromeDriverFixture.Driver);
                dataGridPage.NavigateTo();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Add Forecast in Fahrenheit.");
                dataGridPage.AddForecast(null, null, "39", "Test summary");

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Verify that forecast is properly added.");
                Assert.Equal("4", dataGridPage.ForecastTable[0].tempC);
                Assert.Equal("39", dataGridPage.ForecastTable[0].tempF);
                Assert.Equal("Test summary", dataGridPage.ForecastTable[0].summary);
            }

            [Trait("Category", "Smoke")]
            [Fact]
            public void UpdateForecasts()
            {
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Navigating to DataGrid.");
                var dataGridPage = new DataGridPage(ChromeDriverFixture.Driver);
                dataGridPage.NavigateTo();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Update Forecast");
                dataGridPage.UpdateForecast(3, null, "4", null, "Test summary");

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Verify that forecast is properly added.");
                Assert.Equal("4", dataGridPage.ForecastTable[3].tempC);
                Assert.Equal("39", dataGridPage.ForecastTable[3].tempF);
                Assert.Equal("Test summary", dataGridPage.ForecastTable[3].summary);
            }


            [Trait("Category", "Smoke")]
            [Fact]
            public void DeleteForecasts()
            {
                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Navigating to DataGrid.");
                var dataGridPage = new DataGridPage(ChromeDriverFixture.Driver);
                dataGridPage.NavigateTo();

                output.WriteLine($"{DateTime.Now.ToLongTimeString()} Update Forecast");
                dataGridPage.DeleteForecast(3);
              
                //TODO - Addd verification
            }
        }

    }
}
    