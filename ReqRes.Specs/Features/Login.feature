@login
Feature: Login

@post @successful
Scenario: Login_Successful_StatusOK
	Given The user logs in with valid email and password
	Then The request succeeds

Scenario: Login_MissingPassword_StatusBadRequest
	Given The user logs in with missing password
	Then The request fails
