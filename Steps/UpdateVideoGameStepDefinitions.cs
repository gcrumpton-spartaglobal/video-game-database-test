using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using Reqnroll;
using RestSharp;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class UpdateVideoGameStepDefinitions : BaseStepDefinitions
    {
        [Given("I create a PUT request with valid authorisation with an ID of {int}")]
        public void GivenICreateAPUTRequestWithValidAuthorisationWithAnIDOf(int p0)
        {
            Client = new RestClient(ClientOptions);

            Request = new RestRequest("/api/v2/videogame/" + p0)
                .AddQueryParameter("token", Token);
        }

        [Given("I create a PUT request with invalid authorisation with an ID of {int}")]
        public void GivenICreateAPUTRequestWithInvalidAuthorisationWithAnIDOf(int p0)
        {
            Client = new RestClient(ClientOptions);

            Request = new RestRequest("/api/v2/videogame/" + p0)
                .AddQueryParameter("token", "invalid_token");
        }


        [Given("my PUT request content is formatted correctly")]
        public void GivenMyPUTRequestContentIsFormattedCorrectly()
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

        [Given("my PUT request content is formatted incorrectly")]
        public void GivenMyPUTRequestContentIsFormattedIncorrectly()
        {
            throw new PendingStepException();
        }

        [When("I send the PUT request to the specified endpoint")]
        public void WhenISendThePUTRequestToTheSpecifiedEndpoint()
        {
            Response = Client.ExecutePut(Request);
        }

        [Then("I receive a status code of {int}")]
        public void ThenIReceiveAStatusCodeOf(int p0)
        {
            Assert.That((int)Response.StatusCode, Is.EqualTo(p0));
        }

        [Then("The PUT request response JSON content is formatted correctly")]
        public void ThenThePUTRequestResponseJSONContentIsFormattedCorrectly()
        {
            var responseContent = JToken.Parse(Response.Content);
            var jsonSchema = JSchema.Parse(File
                .ReadAllText($"{System.IO.Directory.GetParent("../../../")}/Resources/Schemas/update_video_game.json"
                ));

            Assert.That(responseContent.IsValid(jsonSchema), Is.True);
        }

        [Then("I receive a response with a {int} Bad Request error code")]
        public void ThenIReceiveAResponseWithABadRequestErrorCode(int p0)
        {
            throw new PendingStepException();
        }
    }
}
