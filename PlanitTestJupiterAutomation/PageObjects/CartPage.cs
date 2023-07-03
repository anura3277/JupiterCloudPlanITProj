using System.Text.RegularExpressions;
using OpenQA.Selenium;
using PlanitTestJupiterAutomation.Models;

namespace PlanitTestJupiterAutomation.PageObjects
{
    internal class CartPage : BasePage
    {
        private readonly By cartRowLocator = By.CssSelector(".cart-item");
        private readonly By cartNameLocator = By.CssSelector("td:nth-child(1)");
        private readonly By cartQuantityLocator = By.CssSelector("td:nth-child(3) input");
        private readonly By cartPriceLocator = By.CssSelector("td:nth-child(2)");
        private readonly By cartSubtotalLocator = By.CssSelector("td:nth-child(4)");
        private readonly By carttotalLocator = By.CssSelector("[class='total ng-binding']");
        

        List<CartItems> cartItems;
        IWebDriver driver;
        public CartPage(IWebDriver webDriver) : base(webDriver)
        {
            this.driver = webDriver;
        }
        public CartItems GetCartItem(string itemName)
        {
            var cartItems = GetCartItems();
            return cartItems.FirstOrDefault(item => item.ItemName.Equals(itemName));
        }

        public IEnumerable<CartItems> GetCartItems()
        {
            var cartRows = driver.FindElements(cartRowLocator);
            cartItems = new List<CartItems>();

            foreach (var row in cartRows)
            {
                var itemName = row.FindElement(cartNameLocator).Text;
                var quantity = int.Parse(row.FindElement(cartQuantityLocator).GetAttribute("value"));
                var price = decimal.Parse (row.FindElement(cartPriceLocator).Text.Substring(1));
                var subtotal = decimal.Parse(row.FindElement(cartSubtotalLocator).Text.Substring(1));

                var item = new CartItems
                {
                    ItemName = itemName,
                    Quantity = quantity,
                    Price    = price,
                    Subtotal = subtotal
                };

                cartItems.Add(item);
            }

            return cartItems;
        }
        public decimal cartSubTotalSum()
        {
            string value;
            decimal subTotalSum;
            value= driver.FindElement(carttotalLocator).Text;
            subTotalSum = decimal.Parse(Regex.Match(value, @"\d+\.\d+").Value);
            return subTotalSum;
        }


    }
}
