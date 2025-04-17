Feature: GetVideoGameByIdV2

I want to be able to pass an id number in a GET request using the endpoint '/api/v2/videogame/{id}',
and receive a JSON response for the game with that ID. 

@happy
Scenario Outline: Check various valid IDs return their respective games
	Given I am creating a GET request for the specified endpoint with an ID of <ID>
	When I send the GET request and receive a response
	Then I receive a status code of 200 OK
Examples:
	| ID |
	| 1  |
	| 2  |
	| 3  |

@sad
Scenario Outline: Check various invalid IDs returns a 404 error code
	Given I am creating a GET request for the specified endpoint with an ID of <ID>
	When I send the GET request and receive a response
	Then I receive a status code of 404 NotFound
Examples:
	| ID |
	| -1  |
	| 11  |
	| 99  |
