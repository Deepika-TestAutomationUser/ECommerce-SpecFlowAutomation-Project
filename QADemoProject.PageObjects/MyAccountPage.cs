using OpenQA.Selenium;
using PathFinders.SupportClasses;
using QADemoProject.UI.SeleniumWrapper;
using System.Collections.Generic;
using System.Linq;

namespace QADemoProject.PageObjects
{
    public class MyAccountPage : Page
    {

        public MyAccountPage(IWebDriver driver) : base(driver)
        {

        }

        //Object Repository of Prodcut selection Panel
        private readonly By searchTextBox = By.Name("search_query");
        private readonly By searchButton = By.Name("submit_search");
        private readonly By categoryLink = By.XPath("//div[contains(text(),'Categories')]");
        private readonly By womenCategoryLink = By.XPath("//*[@id='block_top_menu']//a[contains(text(),'Women')]");
        private readonly By dressesCategoryLink = By.XPath("//*[@id='block_top_menu']/ul/li[2]//a[contains(text(),'Dresses')and contains(@title,'Dresses')]");
        private readonly By tshirtCategoryLink = By.XPath("//*[@id='block_top_menu']//ul/li[3]/a[contains(text(),'T-shirts')]");
        private readonly By addToCartButton = By.XPath("//div/a/span[contains(text(),'Add to cart')]");
        private readonly By checkOutButton = By.XPath("//a[contains(@title,'Proceed to checkout')]");
        private By addToCartProduct = By.XPath("//div/a/span[contains(text(),'Add to cart')]/../../..//a[contains(text(),'name')]");
        ////a[contains(text(),'Faded Short Sleeve T-shirts')]/../..//div/a/span[contains(text(),'Add to cart')]
        private readonly By continueShoppingButton = By.XPath("//*[contains(@title,'Continue shopping')]");
        private readonly By goToCartLink = By.XPath("//*[contains(@title,'View my shopping cart')]");


        //Validates page title
        public bool ValidatePageTitle(string pageTitle)
        {
            string actualTitle = Browser_And_Navigation_Handler.GetPageTitle(Driver, true);
            return actualTitle.Equals(pageTitle);
        }

        
        //Selects product from category dresses
        public void SelectSingleProductFromDresses()
        {
            //Button_Link_RadioButton_Handler.ClickElement(Driver, categoryLink, false);
            Button_Link_RadioButton_Handler.ClickElement(Driver, dressesCategoryLink, false);


        }
        //Adds products to cart
        public void AddToCart()
        {

            ActionClass_Handler.ScrollDownByElement(Driver, addToCartButton);
            ActionClass_Handler.MouseOverAndClickRobotClass(Driver, addToCartButton);
            Button_Link_RadioButton_Handler.ClickElement(Driver, checkOutButton, false);
        }

        //Selects product from category women
        public void SelectSingleProductFromWomenCategory()
        {

            Button_Link_RadioButton_Handler.ClickElement(Driver, womenCategoryLink, false);


        }

        //Selects product from category t-shirts
        public void SelectSingleProductFromTShirts()
        {

            Button_Link_RadioButton_Handler.ClickElement(Driver, tshirtCategoryLink, false);


        }

        //Searches for category
        public void SelectSingleProductBySearch(string categoryToSearch)
        {
            TextBox_Handler.TextBox_SendKeys(Driver, searchTextBox, categoryToSearch, false);
            Button_Link_RadioButton_Handler.ClickElement(Driver, searchButton, false);


        }

        //Searches for category and selects list of products under it
        public void SelectProductBasedOnName(string categoryName, string listOfProductToSelect)
        {
            SelectSingleProductBySearch(categoryName);
            List<string> Listofthestring = new List<string>();
            Listofthestring = listOfProductToSelect.Split(',').ToList();

            //loop for print out put
            foreach (string product in Listofthestring)
            {
                string elementToFind = "//div/a/span[contains(text(),'Add to cart')]/../../..//a[contains(text(),'name')]".Replace("name", product);
                string elementToClick = elementToFind + "/../..//div/a/span[contains(text(),'Add to cart')]";
                Button_Link_RadioButton_Handler.IdentifyAndClick(Driver, elementToFind, elementToClick);
                //Button_Link_RadioButton_Handler.ClickElement(Driver, checkOutButton, false);
                Button_Link_RadioButton_Handler.ClickElement(Driver, continueShoppingButton, false);


            }
            Button_Link_RadioButton_Handler.ClickElement(Driver, goToCartLink, false);

        }

        //Searches for criteria and selects list of products under it
        public void SelectProductBasedOnCriteria(string criteria, string value)
        {
            Button_Link_RadioButton_Handler.ClickElement(Driver, dressesCategoryLink, false);
            string elementToFind = "//a[./text()='name']".Replace("name", value);
            Button_Link_RadioButton_Handler.ClickElement(Driver, By.XPath(elementToFind), false);
            string elementToClick =  "//div/a/span[contains(text(),'Add to cart')]";
            IReadOnlyCollection<IWebElement> element = Driver.FindElements(By.XPath(elementToClick));

            foreach (IWebElement item in element)
            {
                Button_Link_RadioButton_Handler.IdentifyAndClick(Driver, item);
                Button_Link_RadioButton_Handler.ClickElement(Driver, continueShoppingButton, false);
         
            }

            Button_Link_RadioButton_Handler.ClickElement(Driver, goToCartLink, false);

        }

        //Removes list of added items from cart
        public void RemoveItemFromCart(string categoryName)
        {
            
            List<string> Listofthestring = new List<string>();
            Listofthestring = categoryName.Split(',').ToList();

            //loop for print out put
            foreach (string product in Listofthestring)
            {
                string elementToFind = "//p[contains(@class,'product-name')]/a[contains(text(),'productname')]/../../../td[contains(@class,'cart_delete')]//a[contains(@title,'Delete')]".Replace("productname", product);
                string elementToClick = elementToFind;
                Button_Link_RadioButton_Handler.IdentifyAndClick(Driver, elementToFind, elementToClick);
                
            }

        }



    }
}