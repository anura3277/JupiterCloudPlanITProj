using OpenQA.Selenium;
using PlanitTestJupiterAutomation.Core;
using PlanitTestJupiterAutomation.Models;

namespace PlanitTestJupiterAutomation.PageObjects
{
    internal class ShopPage : BasePage
    {
        private readonly By _productContainerLocator = By.CssSelector("[class*='products ng-scope']");
        private readonly By _productLocator = By.CssSelector("[class='product ng-scope']");

        private readonly By _itemsLocator = By.CssSelector("li.product");
        private readonly By stuffedFrogLocator = By.XPath("//li[contains(@id, 'product-2')]//div//p//a");
        private readonly By fluffyBunnyLocator = By.XPath("//li[contains(@id, 'product-4')]//div//p//a");
        private readonly By valentineBearLocator = By.XPath("//li[contains(@id, 'product-7')]//div//p//a");

        private readonly By stuffedFrogPriceLocator = By.XPath("//li[contains(@id, 'product-2')]//div//p//span");
        private readonly By fluffyBunnyPriceLocator = By.XPath("//li[contains(@id, 'product-4')]//div//p//span");
        private readonly By valentineBearPriceLocator = By.XPath("//li[contains(@id, 'product-7')]//div//p//span");

        IWebDriver driver;
        List<ShoppingItems> shoppingItems = new List<ShoppingItems>();
        public ShopPage(IWebDriver webDriver) : base(webDriver)
        {
            this.driver = webDriver;
        }

        public void BuyItem(string item, int count)
        {
            switch (item)
            {
                case "Stuffed Frog":
                    {                        
                        addToCart(item, count, stuffedFrogLocator);
                        AddShoppingItems(item, count, stuffedFrogPriceLocator);
                    }
                    break;
                case "Fluffy Bunny":
                    {
                        addToCart(item, count, fluffyBunnyLocator);
                        AddShoppingItems(item, count, fluffyBunnyPriceLocator);
                    }
                    break;
                case "Valentine Bear":
                    {
                        addToCart(item, count, valentineBearLocator);
                        AddShoppingItems(item, count, valentineBearPriceLocator);
                    }
                    break;
            }

        }
        public void addToCart(string item,int count, By locator) 
        {
            for (int i=1; i <= count; i++)
            {
                driver.WaitForElementToLoad(locator);
                var searchBox = driver.FindElement(locator);
                searchBox.SendKeys(item);
                var addToCartButton = driver.FindElement(locator);
                addToCartButton.Click();

            }       
        }
        public void AddShoppingItems(string itemSelected, int count,By priceLocator)
        {

                var itemName = itemSelected;
                var quantity = count;
                var price = decimal.Parse(driver.FindElement(priceLocator).Text.Substring(1));
                var subtotal = (price * count);

                var item = new ShoppingItems
                {
                    ItemName = itemName,
                    Quantity = quantity,
                    Price = price,
                    Subtotal = subtotal
                };

                shoppingItems.Add(item);

        }
        public IEnumerable<ShoppingItems> GetShoppingItemList() 
        {
            return shoppingItems;
        }
        public decimal shopSubTotalSum()
        {
            decimal sum = 0;
            for (int i= 0 ; i < (shoppingItems.ToList().Count()); i++) 
            {
                 sum = sum + shoppingItems.ToList<ShoppingItems>()[i].Subtotal;
            }
            return sum;
        }

    }
}

