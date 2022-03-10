using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace QADemoProject.UI.SeleniumWrapper
{
    public class JavaScripts
    {

        public static void JavaScriptClick(IWebDriver driver, By by)
        {
            IWebElement element = driver.FindElement(by);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
