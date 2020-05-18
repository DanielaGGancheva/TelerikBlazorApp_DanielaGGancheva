using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.UITest
{
    internal static class Helper
    {

        /// <summary>
        /// Pauses application for specified interval
        /// </summary>
        /// <param name="millisecondsToPause">Sets interval to Pause</param>
        public static void Pause(int millisecondsToPause = 2000)
        {
            Thread.Sleep(millisecondsToPause);
        }

        /// <summary>
        /// Clears the content of field.
        /// <param name="element">input which will be cleared.</param>
        /// </summary>
        public static void ClearField(this IWebElement element)
        {
            for (int i = 0; i < 30; i++)
            {
                element.SendKeys(Keys.Backspace);
            }
        }

        /// <summary>
        /// Clears the content of field and set text
        /// <param name="element">input which will be cleared.</param>
        /// <param name="text">Text to be set</param>
        /// </summary>
        public static void ClearAndSetText(this IWebElement element, string text)
        {
            ClearField(element);
            element.SendKeys(text);
        }


    }
}
