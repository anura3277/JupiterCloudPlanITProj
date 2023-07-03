Feature: Shopping items

As a customer 
I want to select and add Items to Cart
So that I can verify cost and buy Items

@smoke
Scenario: user can add items to the cart
	Given I am in the Jupiter home page
	And I went to the Shop page
	And I bought below items
	| Item           | Count |
	| Stuffed Frog   | 2     |
	| Fluffy Bunny   | 5     |
	| Valentine Bear | 3     |
	When I open the Cart
	Then the subtotal, item price for each products is correct
	And the cart Total is correct

