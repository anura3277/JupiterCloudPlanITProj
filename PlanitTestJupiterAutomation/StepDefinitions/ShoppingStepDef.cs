
using NUnit.Framework;
using OpenQA.Selenium;
using PlanitTestJupiterAutomation.Models;
using PlanitTestJupiterAutomation.PageObjects;
using TechTalk.SpecFlow;

namespace PlanitTestJupiterAutomation.StepDefinitions
{
    [Binding]
    public class ShoppingStepDef
    { 
        private ScenarioContext context;
        private readonly HomePage homePage;
        private readonly ShopPage shopPage;
        private readonly CartPage cartPage;
        public ShoppingStepDef(ScenarioContext context, IWebDriver driver)
        {
            this.context= context;
            homePage = new HomePage(driver);
            shopPage = new ShopPage(driver);
            cartPage = new CartPage(driver);
        }

        [StepDefinition(@"I go to Jupiter home page")]
        public void GivenIGoToJupiterHomePage()
        {
            homePage.Load();
        }

        [StepDefinition(@"I go to Shop page")]
        public void GivenIGoToShopPage()
        {
            homePage.GoToPage("Shop");
        }

        [StepDefinition(@"I buy below items")]
        public void GivenIBuyBelowItems(Table itemTable)
        {

            context["ItemTable"] = itemTable;

                foreach (var row in itemTable.Rows)
                    {
                        var item = row["Item"];
                        var count = int.Parse(row["Count"]);

                        shopPage.BuyItem(item, count);
                    }            
        }
        [StepDefinition(@"I open the Cart I can see Items are added")]
        public void WhenIOpenTheCartICanSeeItemsAreAdded()
        {
            
            homePage.GoToPage("Cart");           
        }

        [StepDefinition(@"I verify subtotal, price for each products on Shop page and Cart are correct")]
        public void ThenIVerifySubtotalForEachProductIsCorrect()
        {
            var itemListInCart = cartPage.GetCartItems();
            var itemListInShopPage = shopPage.GetShoppingItemList();

            string failMessage1 = " Subtotal on Shop page and Cart page are different";
            string failMessage2 = " Price on Shop page and Cart page are different";

            for (int i = 0; i < (itemListInCart.ToList().Count); i++)
            {
                Assert.That(itemListInCart.ToList<CartItems>()[i].Subtotal, Is.EqualTo(itemListInShopPage.ToList<ShoppingItems>()[i].Subtotal), message: itemListInShopPage.ToList<ShoppingItems>()[0].ItemName + failMessage1);
                Assert.That(itemListInCart.ToList<CartItems>()[i].Price, Is.EqualTo(itemListInShopPage.ToList<ShoppingItems>()[i].Price), message: itemListInShopPage.ToList<ShoppingItems>()[0].ItemName + failMessage2);
            }
        }

        [StepDefinition(@"I verify Total on Shop page and Cart are correct")]
        public void ThenIVerifyTotalOnShopPageAndCartAreCorrect()
        {
            Assert.That(cartPage.cartSubTotalSum(), Is.EqualTo(shopPage.shopSubTotalSum()), message:  " Total Price on Shop page and Cart page are different");
        }

    }

}