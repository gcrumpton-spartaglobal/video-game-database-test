using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using Reqnroll;
using RestSharp;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class CreateAPIKeyStepDefinitions : BaseStepDefinitions
    {
        [Given("I create a POST request with a given username and password")]
        public void GivenICreateAPOSTRequestWithAGivenUsernameAndPassword()
        {
            var options = new RestClientOptions("https://videogamedb.uk");

            Client = new RestClient(options);

            string username = "admin";
            string password = "admin";

            Request = new RestRequest("/api/authenticate")
                .AddJsonBody(new Dictionary<string, string> { 
                    {"username", username }, {"password", password } 
                });
        }

        [When("I send the POST request")]
        public void WhenISendThePOSTRequest()
        {
            Response = Client.Post(Request);
        }

        [Then("I receive a response with a {int} OK status code")]
        public void ThenIReceiveAResponseWithAOKStatusCode(int p0)
        {
            Assert.That((int)Response.StatusCode, Is.EqualTo(p0));
        }

        [Then("The response JSON content is formatted correctly")]
        public void ThenTheResponseJSONContentIsFormattedCorrectly()
        {
            var responseContent = JToken.Parse(Response.Content);
            var jsonSchema = JSchema.Parse(File
                .ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/create_api_key.json"
                ));

            Assert.That(responseContent.IsValid(jsonSchema), Is.True);
        }
    }
}
