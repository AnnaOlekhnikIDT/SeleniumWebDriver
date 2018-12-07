Feature: SendLetterTest
	In order to send the letter
	As authorized user
	I want to check the letter was sent
	Background: 
		Given Open Gmail main page
			And Authorize as "default" user

@mytag
Scenario: Email was successfully sent

	When I open send Email form

	And I fill in "reciever" field with "annaolekhnik@gmail.com"
	And I fill in "theme" field with "Hi from Ann" 
	And I fill in "body" field with "I am a lazy pig" 
	And I submit email sending
	Then Verify email was successfully sent
