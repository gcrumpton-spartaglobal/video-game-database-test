Feature: UpdateVideoGame

As a user, I want to be able to make a PUT request to the '/api/v2/videogame/{id}' end point 
containing a JSON object matching an existing video game in order to update that 
video game's details.

Scenario Outline: Check various valid and invalid IDs with valid authorisation
	Given I create a PUT request with valid authorisation with an ID of <ID>
	And my PUT request content is formatted correctly
	When I send the PUT request to the specified endpoint
	Then I receive a status code of <status_code>
	And The PUT request response JSON content is formatted correctly
Examples:
	| ID | status_code |
	| -1 | 404         |
	| 0  | 404         |
	| 1  | 200         |
	| 9  | 200         |
	| 10 | 200         |
	| 11 | 404         |

Scenario Outline: Check various valid and invalid IDs with invalid authorisation
	Given I create a PUT request with invalid authorisation with an ID of <ID>
	And my PUT request content is formatted correctly
	When I send the PUT request to the specified endpoint
	Then I receive a status code of <status_code>
Examples: 
	| ID | status_code |
	| 0  | 403         |
	| 6  | 403         |
	| 11 | 403         |

Scenario: Check valid ID response with valid authorisation but invalid request JSON content
	Given I create a PUT request with valid authorisation with an ID of 1
	And my PUT request content is formatted incorrectly
	When I send the PUT request to the specified endpoint
	Then I receive a response with a 400 Bad Request error code


