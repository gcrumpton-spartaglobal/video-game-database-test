using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using VideoGameDatabaseTest.Resources.Config;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class GetAllVideoGamesSteps : BaseStepDefinitions
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            SetupConfig();
        }

        [Given("I create a new GET request for the specified endpoint")]
        public void GivenICreateANewGETRequestForTheSpecifiedEndpoint()
        {
            Client = new RestClient(ClientOptions);
            Request = new RestRequest("/api/v2/videogame");
        }

        [When("I send a GET request to that endpoint")]
        public void GetEndpoint()
        {
            Response = Client.Get(Request);
        }

        [Then("I receive a success code of 200 OK")]
        public void Receive200OK()
        {
            Assert.That(Response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
