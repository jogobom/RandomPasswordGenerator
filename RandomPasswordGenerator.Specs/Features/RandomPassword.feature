Feature: RandomPassword
	As an internet user I want a secure password so that I don't get hacked

Scenario: Password should be the required length
	When I generate a password
	Then the password will be 32 characters long
