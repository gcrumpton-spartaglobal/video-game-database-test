Feature: DeleteVideoGameV2

As a user, I want to be able to send a DELETE request to the '/api/v2/videogame/{int}' end point
so that I can delete the video game that exists with a given ID.

Scenario Outline: Check various valid and invalid IDs with valid authorisation
	Given I create a DELETE request with valid authorisation with an ID of <ID>
	When I send the DELETE request to the specified endpoint
	Then I receive a status code of <status_code> from the DELETE request
Examples:
	| ID | status_code |
	| -1 | 404         |
	| 0  | 404         |
	| 1  | 200         |
	| 9  | 200         |
	| 10 | 200         |
	| 11 | 404         |

Scenario Outline: Check various valid and invalid IDs with invalid authorisation
	Given I create a DELETE request with invalid authorisation with an ID of <ID>
	When I send the DELETE request to the specified endpoint
	Then I receive a status code of <status_code> from the DELETE request
Examples: 
	| ID | status_code |
	| 0  | 403         |
	| 6  | 403         |
	| 11 | 403         |
