using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;

namespace QADemoProject.UI.SeleniumWrapper
{
    //This class has all the method related to keyboard and mouse actions
    public class ActionClass_Handler
    {

        public static void SendText_UpperCase(IWebDriver driver, By by, string key, string text)
        {
            try
            {

                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.KeyDown(element, key).SendKeys(text).KeyUp(key).Build().Perform();
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.KeyDown(element, key).SendKeys(text).KeyUp(key).Build().Perform();
            }
        }
        public static void KeyDown(IWebDriver driver, string key)
        {
            try
            {

                Actions actions = new Actions(driver);
                actions.KeyDown(key).Build().Perform();
            }

            catch (Exception ex) when (ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();

            }

        }

        public static void KeyUp(IWebDriver driver, string key)
        {
            try
            {

                Actions actions = new Actions(driver);
                actions.KeyUp(key).Build().Perform();
            }

            catch (Exception ex) when (ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();

            }

        }

        public static void ClickElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.Click(element).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.Click(element).Build().Perform();

            }
        }


        public static void Click(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.Click().Build().Perform();

            }
            catch (Exception ex) when (ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }

        public static void DoubleClickElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.DoubleClick(element).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.DoubleClick(element).Build().Perform();

            }
        }

        public static void DoubleClick(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.DoubleClick().Build().Perform(); ;

            }
            catch (Exception ex) when (ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }


        public static void RightClickElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.ContextClick(element).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.ContextClick(element).Build().Perform();

            }
        }

        public static void ContextClick(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.ContextClick().Build().Perform();

            }
            catch (Exception ex) when (ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }

        public static void Release(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.Release().Build().Perform();

            }
            catch (Exception ex) when (ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }

        }

        public static void ReleaseElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.Release(element).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.Release(element).Build().Perform();

            }

        }

        public static void SendKeysToElement(IWebDriver driver, By by, string text, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.SendKeys(element, text).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.SendKeys(element, text).Build().Perform();

            }

        }

        public static void SendKeys(IWebDriver driver, string text, bool inputValidation = false)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.SendKeys(text).Build().Perform();

            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }


        }

        public static void MoveToElement(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.MoveToElement(element).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.MoveToElement(element).Build().Perform();

            }

        }


        public static void MoveToElement_OffSet(IWebDriver driver, By by, int offX, int offY, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.MoveToElement(element, offX, offY).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.MoveToElement(element, offX, offY).Build().Perform();

            }

        }

        public static void ClickAndHold_Element(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.ClickAndHold(element).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement element = driver.FindElement(by);
                actions.ClickAndHold(element).Build().Perform();

            }

        }

        public static void ClickAndHold(IWebDriver driver, By by, bool inputValidation = false)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.ClickAndHold().Build().Perform();

            }
            catch (Exception ex) when (ex is WebDriverTimeoutException)
            {
                //ExtentTest test = 
                //test.Error("Could not perform SendKeys on element identified by " + by.ToString() + " after " + "60" + " seconds", MediaEntityBuilder.CreateScreenCaptureFromPath(ReportingMethods.CreateScreenshot(driver)).Build());
                Assert.Fail();
            }


        }

        public static void DragAndDrop_Element(IWebDriver driver, By source, By target, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(source));
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(target));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement sourceElement = driver.FindElement(source);
                OpenQA.Selenium.IWebElement targetElement = driver.FindElement(target);
                actions.DragAndDrop(sourceElement, targetElement).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(source));
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(target));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement sourceElement = driver.FindElement(source);
                OpenQA.Selenium.IWebElement targetElement = driver.FindElement(target);
                actions.DragAndDrop(sourceElement, targetElement).Build().Perform();

            }

        }
        public static void ScrollDownByValue(IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,1000)");
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {
                

            }
        }


        public static void ScrollDownByElement(IWebDriver driver, By by)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                IWebElement element = driver.FindElement(by);
                js.ExecuteScript("arguments[0].scrollIntoView();", element);
            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {


            }
        }

        public static void MouseOverAndClick(IWebDriver driver, By by)
        {
            try
            {
                Actions actions = new Actions(driver);
                IWebElement element = driver.FindElement(by);
                actions.MoveToElement(element).Click().Build().Perform();

            }
            catch (Exception ex) when (ex is StaleElementReferenceException)
            {


            }
        }


        public static void MouseOverAndClickRobotClass(IWebDriver driver, By by)
        {
            driver.Manage().Window.Size = new System.Drawing.Size(1000, 900);
            Actions actions = new Actions(driver);
            IWebElement element = driver.FindElement(by);
            actions.MoveToElement(element).Click().Build().Perform();
            driver.Manage().Window.Maximize();

        }


        public static void DragAndDrop_OffSet(IWebDriver driver, By source, int offX, int offY, bool inputValidation = false)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(source));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement sourceElement = driver.FindElement(source);
                actions.DragAndDropToOffset(sourceElement, offX, offY).Build().Perform();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(source));
                Actions actions = new Actions(driver);
                OpenQA.Selenium.IWebElement sourceElement = driver.FindElement(source);
                actions.DragAndDropToOffset(sourceElement, offX, offY).Build().Perform();

            }

        }


       

    }
}
