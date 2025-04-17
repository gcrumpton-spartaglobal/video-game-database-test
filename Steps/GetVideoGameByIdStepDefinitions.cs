using System;
using NUnit.Framework;
using System.Net;
using Reqnroll;
using RestSharp;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class GetVideoGameByIdStepDefinitions : BaseStepDefinitions
    {
        [Given("I am creating a GET request for the specified endpoint with an ID of {int}")]
        public void GivenIAmCreatingAGETRequestForTheSpecifiedEndpointWithAnIDOf(int p0)
        {
            Client = new RestClient(ClientOptions);
            Request = new RestRequest("/api/v2/videogame/" + p0);
        }

        [Given("I am creating a GET request for the specified endpoint with an ID of {int} for the {string} API version")]
        public void GivenIAmCreatingAGETRequestForTheSpecifiedEndpointWithAnIDOfForTheAPIVersion(int p0, string p1)
        {
            Client = new RestClient(ClientOptions);

            if (p1 == "V1")
            {
                Request = new RestRequest("/api/videogame/" + p0);
            }
            else
            {
                Request = new RestRequest("/api/v2/videogame/" + p0);
            }
        }

        [When("I send the GET request and receive a response")]
        public void WhenISendTheGETRequestAndReceiveAResponse()
        {
            Response = Client.Get(Request);
        }

        [Then("I receive a status code of {int} OK")]
        public void ThenIReceiveAStatusCodeOfOK(int p0)
        {
            Assert.That((int)Response.StatusCode, Is.EqualTo(200));
        }

        [Then("I receive a status code of {int} NotFound")]
        public void ThenIReceiveAStatusCodeOfNotFound(int p0)
        {
            Assert.That((int)Response.StatusCode, Is.EqualTo(404));
        }

    }
}
