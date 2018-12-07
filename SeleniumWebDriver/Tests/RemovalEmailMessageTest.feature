Feature:  RemovalLetterTest
	In order to remove the email
	As authorized user
	I want to check the email was removed
Background: 
	Given Open Gmail main page
		Given Authorize as "default" user

@mytag
Scenario: Email message was successfully removed

	When Remove email message
	Then Verify email message was removed
