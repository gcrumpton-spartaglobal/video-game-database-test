Feature: UpdateVideoGame

As a user, I want to be able to make a PUT request containing a JSON object matching an existing 
video game in order to update that video game's details.

Scenario Outline: Check various valid and invalid requests give the correct status codes
	Given I create a PUT request using a token of <token>
	When I send the request to the /api/v2/videogame/<ID> end point
	Then I receive a status code of <status_code>
Examples:
	| token | ID | status_code |
	| Token | 1  | 200         |
