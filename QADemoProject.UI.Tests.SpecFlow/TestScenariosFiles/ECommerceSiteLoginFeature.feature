Feature: ECommerceSiteLoginFeature

Validating Login functionality of ECommerce site
@LoginFunctionality
Scenario: Validate User ability to login to ecommerce site for shopping
	Given User has valid portal url
	And User has already signed up as customer hence has valid username and password
	When Click on Sign in
	Then User should be able to login profile successfully

@SignUpFunctionality
Scenario: Validate User ability to signup successfully to ecommerce site for shopping
	Given User has valid portal url
	And User enter email for Signing up as 'Test' profile
	And Below User details such as <FirstName>;<LastName>;<Password>;<Company>;<AddressLine1>;<City>;<Zip>;<Mobile>;<Alias>;<State>
	When Click on Register
	Then User should be able to register profile successfully as 'Test Automation' profile

Examples:
| FirstName | LastName   | Password | Company  | AddressLine1         | City | Zip   | Mobile     | Alias | State   |
| Test      | Automation | testpwd  | testcomp | number 27,mat avenue | LA   | 65753 | 5784848484 | test  | Indiana |
