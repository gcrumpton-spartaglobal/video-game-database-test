using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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

        [Given("I create a POST request with invalid authorisation")]
        public void GivenICreateAPOSTRequestWithInvalidAuthorisation()
        {
            throw new PendingStepException();
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

        [Then("the response JSON content is formatted correctly")]
        public void ThenTheResponseJSONContentIsFormattedCorrectly()
        {
            var responseContent = JToken.Parse(Response.Content);
            var jsonSchema = JSchema.Parse(File
                .ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/create_api_key.json"
                ));

            Assert.That(responseContent.IsValid(jsonSchema), Is.True);
        }

        [Then("I receive a {int} Unauthorized error code")]
        public void ThenIReceiveAUnauthorizedErrorCode(int p0)
        {
            throw new PendingStepException();
        }
    }
}
