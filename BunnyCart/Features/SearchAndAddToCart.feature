Feature: SearchAndAddToCart


@E2E-Search_AddToCart
Scenario Outline: 01 Search 
	Given User will be on the HomePage
	When User will type the '<searchtext>' in the searchbox
	Then Search results are loaded in the same page with '<searchtext>'
	Then The heading should have the '<searchtext>'
	* Title should have '<searchtext>'
	When User selects a '<productno>'
	Then Product page is loaded
Examples: 
	| searchtext | productno |
	| water      | 1         |
	| java       | 2         |




