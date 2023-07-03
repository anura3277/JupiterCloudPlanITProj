Feature: Shopping items

As a customer 
I want to select and add Items to Cart
So that I can verify cost and buy Items

@smoke
Scenario: 1_Select items from the shop page and add to the cart
	Given I go to Jupiter home page
	And I go to Shop page
	And I buy below items
	| Item           | Count |
	| Stuffed Frog   | 2     |
	| Fluffy Bunny   | 5     |
	| Valentine Bear | 3     |
	When I open the Cart I can see Items are added
	Then I verify subtotal, price for each products on Shop page and Cart are correct
	And I verify Total on Shop page and Cart are correct

