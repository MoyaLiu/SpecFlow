Feature: Employee

@functional
Scenario: Verify the user is able to create new employee record
	Given I click the create button
	When I input the data
	| Name | Username | Contact | Password  | RetypePassword | IsAdmin | Vehicle | Groups |
	| A    | AA       |          | QQww1234@ | QQww1234@      |         |         |        |
	And I click the Save
	Then The result should be displayed
