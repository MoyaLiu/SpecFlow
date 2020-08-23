Feature: Employee

Scenario: Verify the user is able to navigate to the employee page
	Given I navigate to the home page
	When I login to the home page
	And I navigate to the employee page
	Then I am on the employee page