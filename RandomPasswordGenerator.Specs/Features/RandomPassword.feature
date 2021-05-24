Feature: RandomPassword
	As an internet user I want a secure password so that I don't get hacked

Scenario: Password should be the required length
	When I generate a password
	Then the password will be 32 characters long

Scenario: Password should be different each time
	When I generate a password
	And I generate another password
	Then the passwords will be different

Scenario: Password should meet the content requirements
	When I generate a password
	# This failed on the billionth run because our random generation doesn't guarantee any particular number of letters/numbers
	# We got lucky that it failed quite quickly, this bug could have hidden for a long time
	# Next time we should write some unit tests to capture this problem more directly
	Then the password will contain at least 1 uppercase character
	And the password will contain at least 1 lowercase character
	And the password will contain at least 2 numeric characters
	And the password will contain at least 1 of the characters "#![]{}£$%&"