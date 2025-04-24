using System;
using NUnit.Framework;
using Reqnroll;
using RestSharp;
using RestSharp.Authenticators;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class DeleteVideoGameStepDefinitions : BaseStepDefinitions
    {
        [Given("I create a DELETE request with valid authorisation with an ID of {int}")]
        public void GivenICreateADELETERequestWithValidAuthorisationWithAnIDOf(int p0)
        {
            Client = new RestClient(ClientOptions);

            Request = new RestRequest("/api/v2/videogame/" + p0)
                .AddQueryParameter("token", Token)
                .AddHeader("Accept", "text/plain");
        }

        [Given("I create a DELETE request with valid authorisation with an ID of {int} for the {string} API version")]
        public void GivenICreateADELETERequestWithValidAuthorisationWithAnIDOfForTheAPIVersion(int p0, string p1)
        {
            Client = new RestClient(ClientOptions);

            if (p1 == "V1")
            {
                Request = new RestRequest("/api/videogame/" + p0)
                    .AddQueryParameter("token", Token)
                    .AddHeader("Accept", "text/plain");
            }
            else
            {
                Request = new RestRequest("/api/v2/videogame/" + p0)
                    .AddQueryParameter("token", Token)
                    .AddHeader("Accept", "text/plain");
            }
        }

        [Given("I create a DELETE request with invalid authorisation with an ID of {int} for the {string} API version")]
        public void GivenICreateADELETERequestWithInvalidAuthorisationWithAnIDOfForTheAPIVersion(int p0, string p1)
        {
            var invalidClientOptions = new RestClientOptions("https://videogamedb.uk:443")
            {
                Authenticator = new JwtAuthenticator("invalid_token")
            };

            Client = new RestClient(invalidClientOptions);

            if (p1 == "V1")
            {
                Request = new RestRequest("/api/videogame/" + p0)
                    .AddQueryParameter("token", "invalid_token")
                    .AddHeader("Accept", "text/plain");
            }
            else
            {
                Request = new RestRequest("/api/v2/videogame/" + p0)
                    .AddQueryParameter("token", "invalid_token")
                    .AddHeader("Accept", "text/plain");
            }
        }

        [When("I send the DELETE request to the specified endpoint")]
        public void WhenISendTheDELETERequestToTheSpecifiedEndpoint()
        {
            Response = Client.ExecuteDelete(Request);
        }

        [Given("I create a DELETE request with invalid authorisation with an ID of {int}")]
        public void GivenICreateADELETERequestWithInvalidAuthorisationWithAnIDOf(int p0)
        {
            Client = new RestClient(ClientOptions);

            Request = new RestRequest("/api/v2/videogame/" + p0)
                .AddQueryParameter("token", "invalid_token")
                .AddHeader("Accept", "text/plain");
        }

        [Then("I receive a status code of {int} from the DELETE request")]
        public void ThenIReceiveAStatusCodeOfFromTheDELETERequest(int p0)
        {
            Assert.That((int)Response.StatusCode, Is.EqualTo(p0));
        }

    }
}
