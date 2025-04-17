using System;
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
            throw new PendingStepException();
        }

        [When("I send the PUT request to the specified endpoint")]
        public void WhenISendThePUTRequestToTheSpecifiedEndpoint()
        {
            throw new PendingStepException();
        }

        [Then("I receive a status code of {int}")]
        public void ThenIReceiveAStatusCodeOf(int p0)
        {
            throw new PendingStepException();
        }
    }
}
