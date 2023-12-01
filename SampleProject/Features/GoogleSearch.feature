Feature: GoogleSearch

To perform search operations on Google home page

@tag1
Scenario: To perform search with Google Search button
	Given Google home page should be loaded
	When Type "Hp Laptop" in the search text input
	And Click on the Google Search button
	Then the results should be displayed on the next page with title "Hp Laptop - Google Search"

	Scenario: To perform search with IMFL button
	Given Google home page should be loaded
	When Type "Hp Laptop" in the search text input
	And Click on the IMFL button
	Then the results should be redirected to a new page with title "HP Laptops"
