Feature: CreateVideoGameV2

As a user, I want to be able to create a video game on the video game database using a POST request.

@happy
Scenario: Creating a video game successfully
	Given I create a POST request with authorisation to the "V2" API version
	And my request content is formatted correctly
	When I send the request to the specified endpoint
	Then I receive a 200 OK response code
	And the response JSON content is formatted correctly

@sad
Scenario: Creating a video game unsuccessfully (invalid authorisation)
	Given I create a POST request with invalid authorisation to the "V2" API version
	And my request content is formatted correctly
	When I send the request to the specified endpoint
	Then I receive a 500 Internal Server Error status code

@sad
Scenario: Creating a video game unsuccessfully (invalid JSON content)
	Given I create a POST request with authorisation to the "V2" API version
	And my request content is formatted incorrectly
	When I send the request to the specified endpoint
	Then I receive a 400 Bad Request error code
