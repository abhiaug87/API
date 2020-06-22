using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using TechTalk.SpecFlow;
using System.IO;

namespace InvoicerAPI.Steps
{
    [Binding]
   public class Stepdefinition
    {

        [Given(@"I have the invoices URL")]
        public void GivenIHaveTheInvoicesURL()
        {
            RestApiHelper.Url();
        }

        [When(@"I call the endpoint for (.*)")]
        public void WhenICallTheEndpoint(int invoiceid)
        {
            RestApiHelper.GetInvoiceId(invoiceid);
        }

        [Given(@"I call then endpoint for token generation")]
        public void GivenICallThenEndpointForTokenGeneration()
        {
            RestApiHelper.GetToken();
        }

        [When(@"I call the post method for (.*), (.*) and (.*)")]
        public void WhenICallThePostMethodForAnd(string clientid, string clientsecret, string granttype)
        {
            RestApiHelper.CreateRequest(clientid, clientsecret, granttype);
        }

        [Then(@"I am able to generate the access token (.*), (.*) and (.*)")]
        public void ThenIAmAbleToGenerateTheAccessTokenAnd(string clientid, string clientsecret, string granttype)
        {
            var response = RestApiHelper.GetResponse(clientid, clientsecret, granttype);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
        }


        [Then(@"all the invoices should be retrieved with (.*)")]
        public void ThenAllTheInvoicesShouldBeRetrieved(int invoiceid)
        {
            var response = RestApiHelper.GetInvoiceResponse(invoiceid);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "The response has failed");
        }

        [When(@"I call the incorrect endpoint with (.*)")]
        public void WhenICallTheIncorrectEndpointWith(int invoiceid)
        {
            RestApiHelper.GetincorrectInvoiceId(invoiceid);
        }

        [When(@"I call the endpoint for number with (.*)")]
        public void WhenICallTheEndpointForNumberWith()
        {
           // RestApiHelper.
        }
        

        [Then(@"all the appropriate error for (.*)")]
       public void ThenAllTheAppropriateErrorFor(int invoiceid)
        {
          var response = RestApiHelper.GetIncorrectInvoiceResponse(invoiceid);
         Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "The response has failed");
        }

        [Then(@"the invoices should be retrieved for (.*)")]
        public void ThenTheInvoicesShouldBeRetrievedFor(string invoicenumber)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the error message should appear for (.*)")]
        public void ThenTheErrorMessageShouldAppearFor(string invoicenumber)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
