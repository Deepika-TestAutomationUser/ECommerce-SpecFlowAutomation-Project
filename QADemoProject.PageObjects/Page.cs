using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QADemoProject.PageObjects
{
    //Page initializer class
    public abstract class Page
    {
        protected IWebDriver Driver;
        protected WebDriverWait DriverWait;

        public Page(IWebDriver driver)
        {
            Driver = driver;
            // wait up to 30 seconds.
            DriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

        }


        public virtual string Url => string.Empty;

        public void GoTo() => Driver.Navigate().GoToUrl(Url);

        public void Refresh() => Driver.Navigate().Refresh();
    }
}
