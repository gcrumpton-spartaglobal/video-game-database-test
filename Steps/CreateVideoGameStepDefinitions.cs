using System;
using NUnit.Framework;
using Reqnroll;
using RestSharp;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class CreateVideoGameStepDefinitions : BaseStepDefinitions
    {
        [Given("I create a POST request with authorisation")]
        public void GivenICreateAPOSTRequestWithAuthorisation()
        {
            Client = new RestClient(ClientOptions);

            Request = new RestRequest("/api/v2/videogame")
                .AddQueryParameter("token", Token);
        }

        [Given("my request content is formatted correctly")]
        public void GivenMyRequestContentIsFormattedCorrectly()
        {
            string newGameJsonString = 
                "{" +
                    "\"category\": \"Platform\"," +
                    "\"name\": \"Mario\"," +
                    "\"rating\": \"Mature\"," +
                    "\"releaseDate\": \"2012-05-04\"," +
                    "\"reviewScore\": 85" +
                "}";

            Request.AddStringBody(newGameJsonString, ContentType.Json);
        }

        [When("I send the request to the specified endpoint")]
        public void WhenISendTheRequestToTheSpecifiedEndpoint()
        {
            Response = Client.Post(Request);
        }

        [Then("I receive a {int} OK response code")]
        public void ThenIReceiveAOKResponseCode(int p0)
        {
            Assert.That((int)Response.StatusCode, Is.EqualTo(p0) );
        }
    }
}
