Feature: ECommerceSiteSingleProductSelectionFeature

Validating product selection and checkout functionality of ECommerce site
@SelectProductFromDressesCategory
Scenario: Validate the functionality of selecting a product from category Dresses
	Given User has valid portal url
	And User has already signed up as customer hence has valid username and password
	And Click on Sign in
	And User able to login profile successfully
	When User select an item from category dresses
	Then Item should be successfully added to cart
	And User should be able to checkout successfully

@SelectProductFromTShirtsCategory
Scenario: Validate the functionality of selecting a product from category TShirts
	Given User has valid portal url
	And User has already signed up as customer hence has valid username and password
	And Click on Sign in
	And User able to login profile successfully
	When User select an item from category Tshirts
	Then Item should be successfully added to cart
	And User should be able to checkout successfully

@SelectProductFromWomenCategory
Scenario: Validate the functionality of selecting a product from category Women
	Given User has valid portal url
	And User has already signed up as customer hence has valid username and password
	And Click on Sign in
	And User able to login profile successfully
	When User select an item from category Women
	Then Item should be successfully added to cart
	And User should be able to checkout successfully


	@SelectProductFromAnyCategory
	Scenario Outline: Validate the functionality of selecting a product from mulitple category
	Given User has valid portal url
	And User has already signed up as customer hence has valid username and password
	And Click on Sign in
	And User able to login profile successfully
	When User select an item from category <CategoryName>;<ProductName>
	Then User should be able to checkout successfully

	Examples:
	| CategoryName | ProductName                                                                                 |
	| Dresses      | Printed Dress,Printed Chiffon Dress,Printed Summer Dress                                    |
	| T-shirts     | Faded Short Sleeve T-shirts,Blouse                                                          |
	


	@SelectProductFromAnyCategory
	Scenario Outline: Validate the functionality of removing product from cart
	Given User has valid portal url
	And User has already signed up as customer hence has valid username and password
	And Click on Sign in
	And User able to login profile successfully
	When User select an item from category <CategoryName>;<ProductName>
	When User removes one product from cart <RemoveItem>
	Then User should be able to checkout successfully

	Examples:
	| CategoryName | ProductName                                              | RemoveItem                         |
	| Dresses      | Printed Dress,Printed Chiffon Dress,Printed Summer Dress | Printed Dress,Printed Summer Dress |
	| T-shirts     | Faded Short Sleeve T-shirts,Blouse                       | Blouse                             |
