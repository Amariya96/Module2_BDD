Feature: Login
User logs in with credentials (usename, password)
Home page will load after successful login


Background: 
	Given User will be on the login page

@positive
Scenario Outline: Login with Valid Credentials
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login button
	Then User will be redirected to Home page
	Examples: 
	| UserName    | Password |
	| abc@xyc.com | 12345    |
	| ert@rty.com | 34567    |

@negative
Scenario Outline: Login with Invalid Credentials
	When User will enter username '<UserName>'
	And User will enter password '<Password>'
	And User will click on login button
	Then Error message for Password Length should be thrown
	Examples: 
	| UserName    | Password |
	| abc@xyc.com | 12345    |
	| ert@rty.com | 34567    |

	
@regression
Scenario Outline: Check for Password Hidden Display
	When User will enter password '<Password>'
	And User will click on Show Link in the password textbox
	Then The password characters should be shown
	Examples: 
	   | Password    |
	   | 12345       |
	  

@regression
Scenario Outline: Check for Password Show Display
	When User will enter password '<Password>'
	And User will click on Show Link in the password textbox
	And User will click on Hide Link in the password textbox
	Then The password characters should not be shown
	Examples: 
	   | Password    |
	   | 12345       | 
	  
