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
    public static class RestApiHelper
    {
        public static RestClient rc;
        public static RestRequest rq;
        public static string baseurl = "https://oc-cert.debitsuccess.com/";
        public static string certurl = "https://oc-lte-hq.debitsuccess.com/";

        public static RestClient Url()
        {
            var url = "https://oc-lte.debitsuccess.com/";
            return rc = new RestClient(url);
        }

        public static RestRequest GetInvoiceId(int invoiceid)
        {
            StreamReader reader = new StreamReader("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\InvoicerAPI\\Output\\outfile.txt");
            string authTOken = reader.ReadToEnd();
            JObject json = JObject.Parse(authTOken);
            rc = new RestClient(certurl);            
            rq = new RestRequest($"Invoicer/v2/invoices/{invoiceid}", Method.GET);
            rq.AddHeader("Content-Type", "application/json");
            rq.AddHeader("Authorization", "Bearer " + json.GetValue("access_token"));
            rq.AddHeader("invoiceId", "invoiceid");
            rq.AddParameter(new Parameter("invoiceId", invoiceid, ParameterType.GetOrPost));
            return rq;
        }

        public static RestRequest GetToken()
        {
            rc = new RestClient(baseurl);
            rq = new RestRequest("identity/connect/token", Method.POST);
            return rq;
        }

        public static RestRequest CreateRequest(string clientid, string clientsecret, string granttype)
        {
            rc = new RestClient(baseurl);
            rq = new RestRequest("identity/connect/token", Method.POST);
            rq.AddParameter(new Parameter("client_id", clientid, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("client_secret", clientsecret, ParameterType.GetOrPost));
            rq.AddParameter(new Parameter("grant_type", granttype, ParameterType.GetOrPost));
            return rq;
        }

        public static RestRequest GetincorrectInvoiceId(int invoiceid)
        {
            rc = new RestClient(baseurl);
            rq = new RestRequest("v1/invoice", Method.GET);
            rq.AddParameter(new Parameter("invoiceId", invoiceid, ParameterType.GetOrPost));
            return rq;
        }
        public static RestRequest GetInvoiceNumber(string invoiceNumber)
        {
            rc = new RestClient(baseurl);
            rq = new RestRequest("v1/invoices", Method.GET);
            rq.AddParameter(new Parameter("invoiceNumber", invoiceNumber, ParameterType.GetOrPost));
            return rq;
        }

        public static IRestResponse GetInvoiceResponse(int invoiceid)
        {
            var response = rc.Execute(rq);
            return response;
        }
        public static IRestResponse GetIncorrectInvoiceResponse(int invoiceid)
        {
            var response = rc.Execute(rq);
            return response;
        }
        public static IRestResponse GetInvoiceNumberResponse(string invoiceNumber)
        {
            var response = rc.Execute(rq);
            return response;
        }
        public static IRestResponse GetResponse(string clientid, string clientsecret, string granttype)
        {
            StreamWriter outfile = new StreamWriter("C:\\Users\\abhishek.k\\source\\repos\\DS_Automation\\InvoicerAPI\\Output\\outfile.txt");
            var response = rc.Execute(rq);
            outfile.Write(response.Content.ToString());
            outfile.Close();
            return response;
        }
    }
}
