using OpenQA.Selenium;
using PathFinders.SupportClasses;
using QADemoProject.UI.SeleniumWrapper;

namespace QADemoProject.PageObjects
{
    public class CheckOutPage : Page
    {

        public CheckOutPage(IWebDriver driver) : base(driver)
        {

        }
        //Object Repository of Checkout Panel 
        private readonly By checkOutButton = By.XPath("//*[@id='center_column']//span[contains(text(),'Proceed to checkout')]/..");
        private readonly By proceedToCheckOutButton = By.XPath("//button[contains(@name,'processAddress')]");
        private readonly By acknowledgeCheckBox = By.XPath("//input[contains(@type,'checkbox')]");
        private readonly By addressProceedButton = By.XPath("//button[contains(@name,'processCarrier')]");
        private readonly By payByCheckLink = By.XPath("//a[contains(@title,'Pay by check')]");
        private readonly By confirmOrderButton = By.XPath("//button[contains(@type,'submit')]//span[contains(text(),'I confirm my order')]/..");
        private readonly By orderConfirmLabel = By.XPath("//p[contains(text(),'Your order on My Store is complete.')]");
        private readonly By signOutLink = By.XPath("//a[contains(@title,'Log me out')]");
       
        
        //Actions performed in CheckOut Window
        public bool CheckOutSuccessfully()
        {
            ActionClass_Handler.ScrollDownByElement(Driver, checkOutButton);
            Button_Link_RadioButton_Handler.ClickElement(Driver, checkOutButton,false);

            ActionClass_Handler.ScrollDownByElement(Driver, proceedToCheckOutButton);
            Button_Link_RadioButton_Handler.ClickElement(Driver, proceedToCheckOutButton,false);

            ActionClass_Handler.ScrollDownByElement(Driver, acknowledgeCheckBox);
            ActionClass_Handler.MouseOverAndClick(Driver, acknowledgeCheckBox);

            ActionClass_Handler.ScrollDownByElement(Driver, addressProceedButton);
            Button_Link_RadioButton_Handler.ClickElement(Driver, addressProceedButton,false);

            ActionClass_Handler.ScrollDownByElement(Driver, payByCheckLink);
            Button_Link_RadioButton_Handler.ClickElement(Driver, payByCheckLink,false);

            ActionClass_Handler.ScrollDownByElement(Driver, confirmOrderButton);
            Button_Link_RadioButton_Handler.ClickElement(Driver, confirmOrderButton,false);

            ActionClass_Handler.ScrollDownByElement(Driver, orderConfirmLabel);
            bool statusMatch = Label_Handler.Label_GetElementText(Driver, orderConfirmLabel, true).Equals("Your order on My Store is complete.");

            ActionClass_Handler.ScrollDownByElement(Driver, signOutLink);
            Button_Link_RadioButton_Handler.ClickElement(Driver, signOutLink,false);


            return statusMatch;

        }


    }
}