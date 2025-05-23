﻿Feature: GetAllVideoGamesV1

I want to send a GET request to the '/api/v2/videogame' endpoint,
and receive JSON in the response containing all of the video games in the database.


Scenario: Check get all video games
	Given I create a new GET request for the specified endpoint for the "V1" API version
	When I send a GET request to that endpoint
	Then I receive a success code of 200 OK
