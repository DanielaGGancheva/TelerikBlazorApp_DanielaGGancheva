using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Blazor.UITest.PageObjectModules
{
    class DataGridPage : Page
    {
        public DataGridPage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected override string PageUrl => "https://localhost:5001/grid";
        protected override string PageTitle => "GridAndMenuServerApp";

        public void ClickAddForecast() => Driver.FindElement(By.XPath("//button[text()='Add Forecast']")).Click();

        public void ClickUpdate() => Driver.FindElement(By.CssSelector(".k-i-save")).Click();

        public void ClickCancel() => Driver.FindElement(By.XPath(".k-i-cancel")).Click();

        public void AddForecast(string date, string tempC, string tempF, string summary) 
        {
            ClickAddForecast();
            Helper.Pause();
            WebDriverWait wait = new WebDriverWait(Driver, timeout: TimeSpan.FromSeconds(5));
            IWebElement AddForecast = wait.Until((d) => d.FindElement(By.CssSelector(".k-i-save")));
            TypeInitialfomationInForecast(1, date, tempC, tempF, summary);
            Helper.Pause();
            ClickUpdate();
            Helper.Pause();
        }


        private void TypeInitialfomationInForecast(int row, string date, string tempC, string tempF, string summary)
        {
            if (date != null) Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[2]//input")).SendKeys(date);

            if (tempC != null) Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[3]//input")).SendKeys(tempC);

            if (tempF != null) Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[4]//input")).SendKeys(tempF);

            if (summary != null) Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[5]//input")).SendKeys(summary);

        }

        public void UpdateForecast(int row, string date, string tempC, string tempF, string summary)
        {
            var EditButtons = Driver.FindElements(By.XPath("//button[text()='Edit']"));
            EditButtons[row].Click();
            Helper.Pause();
            UpdateInfomationInForecast(row+1, date, tempC, tempF, summary);
            Helper.Pause();

        }

        public void DeleteForecast(int row)
        {
            var DeleteButtons = Driver.FindElements(By.XPath("//button[text()='Delete']"));
            DeleteButtons[row].Click();
            Helper.Pause();
        }

        private void UpdateInfomationInForecast(int row, string date, string tempC, string tempF, string summary)
        {
            if (date != null)
            {
                var FieldDate = Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[2]//input"));
                FieldDate.ClearAndSetText(date);
            }
            if (tempC != null)
            {
                var FieldTempC = Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[3]//input"));
                FieldTempC.ClearAndSetText(tempC);
            }
            if (tempF != null)
            {
                var FieldTempF = Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[4]//input"));
                FieldTempF.ClearAndSetText(tempF); 
            }

            if (summary != null)
            {
                var FieldSummary = Driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[5]//input"));
                FieldSummary.ClearAndSetText(summary);
            }

            Driver.FindElement(By.XPath("//tbody/tr[" + row + "]//button[text()='Update']")).Click();
        }


        public ReadOnlyCollection<(int id, string date, string tempC, string tempF, string summary)> ForecastTable
        {
            get
            {
                var forecasts = new List<(int id, string date, string tempC, string tempF, string summary)>();

                var forecastCells = Driver.FindElements(By.TagName("td"));


                for (int i = 0; i < forecastCells.Count - 1; i += 6)
                {
                    int id = int.Parse(forecastCells[i].Text);
                    string date = forecastCells[i + 1].Text;
                    string tempC = forecastCells[i + 2].Text;
                    string tempF = forecastCells[i + 3].Text;
                    string summary = forecastCells[i + 4].Text;
                    forecasts.Add((id, date, tempC, tempF, summary));
                }

                return forecasts.AsReadOnly();
            }
        }
    }
}
 