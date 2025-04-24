using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using Reqnroll;
using RestSharp;
using RestSharp.Authenticators;

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

        [Given("I create a PUT request with valid authorisation with an ID of {int} to the {string} API version")]
        public void GivenICreateAPUTRequestWithValidAuthorisationWithAnIDOfToTheAPIVersion(int p0, string p1)
        {
            Client = new RestClient(ClientOptions);

            if (p1 == "V1")
            {
                Request = new RestRequest("/api/videogame/" + p0)
                    .AddQueryParameter("token", Token);
            }
            else
            {
                Request = new RestRequest("/api/v2/videogame/" + p0)
                    .AddQueryParameter("token", Token);
            }
        }

        [Given("I create a PUT request with invalid authorisation with an ID of {int} to the {string} API version")]
        public void GivenICreateAPUTRequestWithInvalidAuthorisationWithAnIDOfToTheAPIVersion(int p0, string p1)
        {
            var invalidClientOptions = new RestClientOptions("https://videogamedb.uk:443")
            {
                Authenticator = new JwtAuthenticator("invalid_token")
            };

            Client = new RestClient(invalidClientOptions);

            if (p1 == "V1")
            {
                Request = new RestRequest("/api/videogame/" + p0)
                    .AddQueryParameter("token", "invalid_token");
            }
            else
            {
                Request = new RestRequest("/api/v2/videogame/" + p0)
                    .AddQueryParameter("token", "invalid_token");
            }
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
            //  Comma has been removed after the 85 to simulate invalid JSON
            string newGameJsonString =
                "{" +
                    "\"category\": \"Platform\"," +
                    "\"name\": \"Mario\"," +
                    "\"rating\": \"Mature\"," +
                    "\"releaseDate\": \"2012-05-04\"," +
                    "\"reviewScore\": 85" +
                    "\"wonAwards\": true" +
                "}";

            Request.AddStringBody(newGameJsonString, ContentType.Json);
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
                .ReadAllText($"{Directory.GetParent("../../../")}/Resources/Schemas/update_video_game.json"
                ));

            Assert.That(responseContent.IsValid(jsonSchema), Is.True);
        }

        [Then("I receive a response with a {int} Bad Request error code")]
        public void ThenIReceiveAResponseWithABadRequestErrorCode(int p0)
        {
            Assert.That((int)Response.StatusCode, Is.EqualTo(p0));
        }
    }
}
