using System;
using NUnit.Framework;
using System.Net;
using Reqnroll;
using RestSharp;

namespace VideoGameDatabaseTest.Steps
{
    [Binding]
    public class GetVideoGameByIdStepDefinitions
    {
        private static IRestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        [Given("I am creating a GET request for the specified endpoint with an ID of {int}")]
        public void GivenIAmCreatingAGETRequestForTheSpecifiedEndpointWithAnIDOf(int p0)
        {
            var options = new RestClientOptions("https://videogamedb.uk");

            _client = new RestClient(options);
            _request = new RestRequest("/api/v2/videogame/" + p0);
        }

        [When("I send the GET request and receive a response")]
        public void WhenISendTheGETRequestAndReceiveAResponse()
        {
            _response = _client.Get(_request);
        }

        [Then("I receive a status code of {int} OK")]
        public void ThenIReceiveAStatusCodeOfOK(int p0)
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(200));
        }

        [Then("I receive a status code of {int} NotFound")]
        public void ThenIReceiveAStatusCodeOfNotFound(int p0)
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(404));
        }

    }
}
