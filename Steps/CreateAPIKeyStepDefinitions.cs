using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using Reqnroll;
using Reqnroll.UnitTestProvider;
using RestSharp;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class CreateAPIKeyStepDefinitions : BaseStepDefinitions
    {
        private readonly IUnitTestRuntimeProvider _unitTestRuntimeProvider;

        public CreateAPIKeyStepDefinitions(IUnitTestRuntimeProvider unitTestRuntimeProvider)
        {
            _unitTestRuntimeProvider = unitTestRuntimeProvider;
        }

        [Given("I create a POST request with a given username and password")]
        public void GivenICreateAPOSTRequestWithAGivenUsernameAndPassword()
        {
            _unitTestRuntimeProvider.TestIgnore("This scenario is always skipped");

            Client = new RestClient(ClientOptions);

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
                .ReadAllText($"{Directory.GetParent("../../../")}/Resources/Schemas/create_video_game.json"
                ));

            Assert.That(responseContent.IsValid(jsonSchema), Is.True);
        }

        [Then("I save the API key to use with other features")]
        public void ThenISaveTheAPIKeyToUseWithOtherFeatures()
        {
            var responseContent = JToken.Parse(Response.Content);
            Token = responseContent["token"].ToString();
        }

    }
}
