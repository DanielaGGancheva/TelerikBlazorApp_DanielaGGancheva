using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.UITest.PageObjectModules
{
    class HomePage : Page
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected override string PageUrl => "https://localhost:5001";
        protected override string PageTitle => "GridAndMenuServerApp";           

        public DataGridPage OpenDataGridLink()
        {
            Driver.FindElement(By.XPath("//a[text()='Data Grid']")).Click();
            return new DataGridPage(Driver);
        }

        public ChartPage OpenChartLink()
        {
            Driver.FindElement(By.XPath("//a[text()='Chart']")).Click();
            return new ChartPage(Driver);
        }
    }
}
