using System;
using NUnit.Framework;
using Reqnroll;
using RestSharp;

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
