﻿Feature: CreateAPIKeyV2

As a user, I want to be able to send a POST request containing a username and password,
so that I get a API key as a response.

Scenario: Create API key
	Given I create a POST request with a given username and password
	When I send the POST request
	Then I receive a response with a 200 OK status code
	And The response JSON content is formatted correctly
