using OpenQA.Selenium;
using PathFinders.SupportClasses;
using QADemoProject.SupportClasses;
using QADemoProject.UI.SeleniumWrapper;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace QADemoProject.PageObjects
{
    public class LoginPage : Page
    {

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }
        //Object Repository of Login Page
        private readonly By userNameTextBox = By.Name("email");
        private readonly By passwordTextBox = By.Name("passwd");
        private readonly By loginSubmitButton = By.Name("SubmitLogin");
        private readonly By signInLink = By.XPath("//a[contains(text(),'Sign in')]");
        private readonly By signUpUserNameTextBox = By.XPath("customer_firstname");
        private readonly By signUpSubmitButton = By.XPath("customer_lastname");
        private readonly By firstNameTextBox = By.XPath("//input[contains(@name,'customer_firstname')]");
        private readonly By lastNameTextBox = By.XPath("//input[contains(@name,'customer_lastname')]");
        private readonly By newPasswordTextBox = By.XPath("//input[contains(@name,'passwd')]");
        private readonly By gendorRadioButton = By.XPath("//input[contains(@id,'id_gender2')]");
        private readonly By addressFirstNameTextBox = By.XPath("//input[starts-with(@id,'firstname')]");
        private readonly By addressLastNameTextBox = By.XPath("//input[starts-with(@id,'lastname')]");
        private readonly By addressLine1TextBox = By.XPath("//input[starts-with(@id,'address1')]");
        private readonly By addressLine2TextBox = By.XPath("//input[starts-with(@id,'address2')]");
        private readonly By addressCompanyTextBox = By.XPath("//input[starts-with(@id,'company')]");
        private readonly By cityTextBox = By.XPath("//input[starts-with(@id,'city')]");
        private readonly By zipTextBox = By.XPath("//input[starts-with(@id,'postcode')]");
        private readonly By mobileNumberTextBox = By.XPath("//input[starts-with(@id,'phone_mobile')]");
        private readonly By aliasTextBox = By.XPath("//input[starts-with(@id,'alias')]");
        private readonly By stateDropDown = By.XPath("//select[starts-with(@id,'id_state')]");
        private readonly By registerButton = By.XPath("//button[starts-with(@id,'submitAccount')]");
        private readonly By createAccountIDTextBox = By.XPath("//input[starts-with(@id,'email_create')]");
        private readonly By createAccountButton = By.XPath("//button[starts-with(@id,'SubmitCreate')]");
        private readonly By userProfileNameLabel = By.XPath("//a[contains(@title,'View my customer account')]/span");







        public override string Url => AppSettingsJsonReader.Env_EdgeUrl;

        //Validates Page title
        public bool ValidatePageTitle(string pageTitle)
        {
            string actualTitle = Browser_And_Navigation_Handler.GetPageTitle(Driver, true);
            return actualTitle.Equals(pageTitle);
        }

        //Login method for ecommerce entry
        public void LoginToECommerceSite()
        {
            
            Button_Link_RadioButton_Handler.ClickElement(Driver, signInLink, false);
            TextBox_Handler.TextBox_SendKeys(Driver, userNameTextBox, AppSettingsJsonReader.Env_EdgeUserName, false);
            TextBox_Handler.TextBox_SendKeys(Driver, passwordTextBox, AppSettingsJsonReader.Env_EdgePwd, false);
            Button_Link_RadioButton_Handler.ClickElement(Driver, loginSubmitButton, false);


        }

        //Actions Performed for Signup in main page, Enters email for signup process
        public void SignUpToECommerceSite(string firstName)
        {
            Button_Link_RadioButton_Handler.ClickElement(Driver, signInLink, false);
            TextBox_Handler.TextBox_SendKeys(Driver, createAccountIDTextBox, firstName+ DataHelper.RandomNumberGenerator()+"@gmail.com", false);
            Button_Link_RadioButton_Handler.ClickElement(Driver,createAccountButton, false);

        }

        //Actions performed in Sign up form during data entry, enters required fields in sign up form
        public void SignUpSubmitUserDetails(string FirstName, string LastName, string Password, string Company, string AddressLine1, string City, string Zip, string Mobile, string Alias, string State)
        {
           // Button_Link_RadioButton_Handler.ClickElement(Driver, gendorRadioButton, false);
            TextBox_Handler.TextBox_SendKeys(Driver, firstNameTextBox, FirstName, false);
            TextBox_Handler.TextBox_SendKeys(Driver, lastNameTextBox, LastName, false);
            TextBox_Handler.TextBox_SendKeys(Driver, newPasswordTextBox, Password, false);
            TextBox_Handler.TextBox_SendKeys(Driver, addressFirstNameTextBox, FirstName, false);
            TextBox_Handler.TextBox_SendKeys(Driver, addressLastNameTextBox, LastName, false);
            TextBox_Handler.TextBox_SendKeys(Driver, addressCompanyTextBox, Company, false);
            TextBox_Handler.TextBox_SendKeys(Driver, addressLine1TextBox, AddressLine1, false);
            TextBox_Handler.TextBox_SendKeys(Driver, cityTextBox, City, false);
            DropDown_Handler.SelectDropDownOptionByText(Driver, stateDropDown, State, false);
            TextBox_Handler.TextBox_SendKeys(Driver, zipTextBox, Zip, false);
            TextBox_Handler.TextBox_SendKeys(Driver, mobileNumberTextBox, Mobile, false);
            TextBox_Handler.TextBox_SendKeys(Driver, aliasTextBox, Alias, false);
            

        }

        //Performs User register action
        public void RegisterNewUser()
        {
            Button_Link_RadioButton_Handler.ClickElement(Driver, registerButton, false);
        }
        // Validates successful signup process
        public bool ValidateSignUp(string profileName)
        {
            string check = Label_Handler.Label_GetElementText(Driver, userProfileNameLabel, true);
            LogFunctions.TakeScreenshot("","",Driver);
            return check.Equals(profileName);
        }

        public void CallScreenshotMethod(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            LogFunctions.TakeScreenshot(scenarioContext.ScenarioInfo.Title, featureContext.FeatureInfo.Title, Driver);
        }
    }
}