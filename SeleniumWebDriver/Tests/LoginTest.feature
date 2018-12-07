Feature: LoginTest
	In order to use gmail page
	As a user
	I want to be told how to authorised
Background: 
		Given Open Gmail main page

@mytag
Scenario: Successfull authorization

	When  Authorize as "default" user
	Then Verify user authorized successfully
