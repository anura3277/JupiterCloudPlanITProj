Feature: ContactPage

As a user
I want to provide message to Jupiter Toys shop
By using contact page

@Samoke
Scenario: Test 1_Verify Contact page error messages
	Given I load Jupiter home page 
	And I navigate to Contact page
	When I click "Submit" button on Contact Page
	Then I verify error messages are appeared
	And I enter values to Mandatory fields
	| Forename | Surname | Email           | Telephone | Message      |
	| Anura    |         | Anura@gmail.com |           | Test Message |
	And I verify the error messages are gone

@Regression
Scenario: Test 2_Verify Contact page submit messages
	Given I load Jupiter home page 
	And I navigate to Contact page
	When I enter values to <Forename>,<Email>,<Message> fields
	Then I click "Submit" button on Contact Page
	And I verify the successful submission message

	Examples: 

	| Forename | Surname | Email           | Telephone | Message				|
	| Anura    |         | Anura@gmail.com |           | Test Message for Anura |
	| Sam      |         | Sam@gmail.com   |           | Test Message for Sam   |
	| Luke     |         | Luke@gmail.com  |           | Test Message for Luke  |
	| Jude     |         | Jude@gmail.com  |           | Test Message for Jude  |
	| Manu     |         | Manu@gmail.com  |           | Test Message for Manu  |
