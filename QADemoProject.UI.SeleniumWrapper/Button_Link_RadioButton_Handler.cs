using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace QADemoProject.UI.SeleniumWrapper
{//This class has all the method related to button,link,radio button
    public class Button_Link_RadioButton_Handler
    {

        public static void ClickElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                driver.FindElement(by).Click();

            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                driver.FindElement(by).Click();

            }
        }


        public static bool ValidateElementIsVisible(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Displayed;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return false;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Displayed;
            }
        }
        public static bool ValidateElementIsEnabled(IWebDriver driver, By by, string valueToType, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Enabled;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return false;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).Enabled;
            }
        }

        public static string GetElementAttribute(IWebDriver driver, By by, string AttributeToGet, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).GetAttribute(AttributeToGet);
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
                return null;
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                // find element again and retry
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return driver.FindElement(by).GetAttribute(AttributeToGet);
            }
        }

        public static  void IdentifyAndClick(IWebDriver driver,string elementToIdentify,string elementToClick)
        {
            IReadOnlyCollection<IWebElement> element = driver.FindElements(By.XPath(elementToIdentify));
            if (element.Count != 0)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement clickElement = driver.FindElement(By.XPath(elementToClick));
                js.ExecuteScript("arguments[0].scrollIntoView();", clickElement);
                driver.Manage().Window.Size = new System.Drawing.Size(1000, 900);
                Actions actions = new Actions(driver);
                actions.MoveToElement(clickElement).Click().Build().Perform();
                driver.Manage().Window.Maximize();
            }

        }

        public static void IdentifyAndClick(IWebDriver driver, IWebElement item)
        {
                Thread.Sleep(5000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", item);
                driver.Manage().Window.Size = new System.Drawing.Size(1000, 900);
                Actions actions = new Actions(driver);
                actions.MoveToElement(item).Click().Build().Perform();
                driver.Manage().Window.Maximize();

        }


    }
}
