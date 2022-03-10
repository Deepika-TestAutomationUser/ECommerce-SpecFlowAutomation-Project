using FluentAssertions;
using QADemoProject.PageObjects;
using QADemoProject.SupportClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Unity;

namespace QADemoProject.UI.Tests.SpecFlow
{
    [Binding]

   
    public class File_Validation_Steps
    {

        private readonly LoginPage _loginPage;
        private readonly MyAccountPage _myAccountPage;
        private readonly CheckOutPage _checkOutPage;


        public File_Validation_Steps()
        {
            string currentNewTimeStamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _loginPage = (LoginPage)UnityContainerFactory.GetContainer().Resolve<Page>("LoginPage");
            _myAccountPage = (MyAccountPage)UnityContainerFactory.GetContainer().Resolve<Page>("MyAccountPage");
            _checkOutPage = (CheckOutPage)UnityContainerFactory.GetContainer().Resolve<Page>("CheckOutPage");
        }

        
        [Given(@"User has valid portal url")]
        public void GivenUserHasValidPortalUrl()
        {
            _loginPage.GoTo();
        }

        [Given(@"User has already signed up as customer hence has valid username and password")]
        public void GivenUserHasAlreadySignedUpAsCustomerHenceHasValidUsernameAndPassword()
        {

            _loginPage.ValidatePageTitle("My Store").Should().Be(true);
            _loginPage.CallScreenshotMethod(ScenarioContext.Current, FeatureContext.Current);
        }


        [When(@"Click on Sign in")]
        public void WhenClickOnSignIn()
        {
            _loginPage.LoginToECommerceSite();
        }

        [Then(@"User should be able to login profile successfully")]
        public void ThenUserShouldBeAbleToLoginProfileSuccessfully()
        {
            _loginPage.ValidatePageTitle("My account - My Store").Should().Be(true);
            _loginPage.CallScreenshotMethod(ScenarioContext.Current, FeatureContext.Current);
        }


        [Given(@"Click on Sign in")]
        public void GivenClickOnSignIn()
        {
            _loginPage.LoginToECommerceSite();
        }

        [Given(@"User able to login profile successfully")]
        public void GivenUserAbleToLoginProfileSuccessfully()
        {
            _loginPage.ValidatePageTitle("My account - My Store").Should().Be(true);
            _loginPage.CallScreenshotMethod(ScenarioContext.Current, FeatureContext.Current);
        }

        [When(@"User select an item from category dresses")]
        public void WhenUserSelectAnItemFromCategoryDresses()
        {
            _myAccountPage.SelectSingleProductFromDresses();
        }

        [Then(@"Item should be successfully added to cart")]
        public void ThenItemShouldBeSuccessfullyAddedToCart()
        {
            _myAccountPage.AddToCart();
        }

        [When(@"User select an item from category Tshirts")]
        public void WhenUserSelectAnItemFromCategoryTshirts()
        {
            _myAccountPage.SelectSingleProductFromTShirts();
        }


        [When(@"User select an item from category Women")]
        public void WhenUserSelectAnItemFromCategoryWomen()
        {
            _myAccountPage.SelectSingleProductFromWomenCategory();
        }

        [Then(@"User should be able to checkout successfully")]
        public void ThenUserShouldBeAbleToCheckoutSuccessfully()
        {
            _checkOutPage.CheckOutSuccessfully().Should().BeTrue();

        }

        [When(@"User select an item from category (.*);(.*)")]
        public void WhenUserSelectAnItemFromCategoryCatogoryNamePrintedDressPrintedChiffonDressPrintedSummerDress(string categoryName,string listOfProducts)
        {
            _myAccountPage.SelectProductBasedOnName(categoryName,listOfProducts);
        }

        
        [When(@"User removes one product from cart (.*)")]
        public void WhenUserRemovesOneProductFromCart(string removeItems)
        {
            _myAccountPage.RemoveItemFromCart(removeItems);
            _loginPage.CallScreenshotMethod(ScenarioContext.Current, FeatureContext.Current);
        }


        [Given(@"Below User details such as (.*);(.*);(.*);(.*);(.*);(.*);(.*);(.*);(.*);(.*)")]
        public void GivenBelowUserDetailsSuchAsTestAutomationTestpwdTestcompNumberMatAvenueLATestIndiana(string FirstName, string LastName, string Password, string Company, string AddressLine1, string City, string Zip, string Mobile, string Alias, string State)
        {
          _loginPage.SignUpSubmitUserDetails(FirstName, LastName, Password, Company, AddressLine1, City, Zip, Mobile, Alias, State);
        }



        [When(@"Click on Register")]
        public void WhenClickOnRegister()
        {
            _loginPage.RegisterNewUser();
        }


        [Given(@"User enter email for Signing up as '([^']*)' profile")]
        public void GivenUserEnterEmailForSigningUpAsProfile(string profileName)
        {
            _loginPage.SignUpToECommerceSite(profileName);
            _loginPage.CallScreenshotMethod(ScenarioContext.Current, FeatureContext.Current);
        }

       
        [Then(@"User should be able to register profile successfully as '([^']*)' profile")]
        public void ThenUserShouldBeAbleToRegisterProfileSuccessfullyAsProfile(string profileName)
        {
            _loginPage.ValidateSignUp(profileName).Should().BeTrue();
            _loginPage.CallScreenshotMethod(ScenarioContext.Current, FeatureContext.Current);


        }

        [When(@"User select an item based on (.*);(.*)")]
        public void WhenUserSelectAnItemFrom(string criteria,string value)
        {
            _myAccountPage.SelectProductBasedOnCriteria(criteria, value);
        }

        




    }
}
