Feature: Employee

@functional
Scenario: Verify the user is able to navigate to the employee page
	Given I navigate to the home page
		| url                                 |
		| http://horse-dev.azurewebsites.net/ |
	When I login to the home page
		| Username | Password |
		| hari | 123123 |
	And I navigate to the employee page
	Then I am on the employee page