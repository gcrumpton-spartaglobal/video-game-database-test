using NUnit.Framework;
using RestSharp.Authenticators;
using RestSharp;
using System.Threading;
using System.Net;

namespace VideoGameDatabaseTest
{
    public class SimpleTest
    {
        private static IRestClient _client;

        [SetUp]
        public void Setup()
        {
            var options = new RestClientOptions("https://videogamedb.uk");

            _client = new RestClient(options);

        }

        [Test]
        public void CheckGetAllVideoGamesAsync()
        {
            var request = new RestRequest("/api/v2/videogame");
            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}