using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.UITest.PageObjectModules
{
    class ChartPage : Page
    {
        public ChartPage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected override string PageUrl  => "https://localhost:5001/chart";
        protected override string PageTitle => "GridAndMenuServerApp";

    }
}
