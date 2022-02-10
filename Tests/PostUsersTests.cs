using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestMaxima.models;

namespace TestMaxima
{


    public class PostUsersTests
    {
        private const string Host = "https://reqres.in/api";
        private const string Api = "/users";

        [Test]
        public async Task CheckPostUsersTesting()
        {
            var baseAddress = Host + Api;
            var client = new HttpClient();
            var strBody = "{\"name\": \"morpheus\" }";
            var contentBody = new StringContent(strBody, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(baseAddress, contentBody);

            var statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, statusCode, $"Ответ от api {Api} не соответствует ожидаемому");
        }

        [Test]
        public async Task CheckPostUsersByJsonTesting()
        {
            var baseAddress = Host + Api;
            var client = new HttpClient();
            var request = new UsersRequest()
            {
                Name = "morpheus"
            };
            var response = await client.PostAsJsonAsync(baseAddress, request);

            var statusCode = response.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, statusCode, $"Ответ от api {Api} не соответствует ожидаемому");
        }


    }

}
