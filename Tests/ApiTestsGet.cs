using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace TestMaxima
{

    public class GetUsersTests
    {
        private const string Host = "https://reqres.in/api";
        private const string Api = "/users";


        [Test]
        public async Task CheckUsersTesting()
        {
            var restClient = new RestClient(Host);
            RestRequest request = new RestRequest(Api, Method.Get);
            var response = await restClient.ExecuteAsync(request);
            var r = JObject.Parse(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "полученный код некорректен");


        }
    }
}



