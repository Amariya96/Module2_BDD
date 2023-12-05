Feature: Search


@Product-Search
Scenario Outline: Search For Products
	Given User will be on the HomePage
	When User will type the '<searchtext>' in the searchbox
	# * User clicks on search button
	Then Search results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext | 
	| water      |
	| java       |
	| hairgrass  |
