using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WizTechDay.Integration.Test.Mocks;
using WizTechDay.Web;
using Xunit;

namespace WizTechDay.Integration.Test.API
{
    public class PersonAPIControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PersonAPIControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ListPerson_SuccessTest()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/v1/persons");
            var stringResponse = response.Content.ReadAsStringAsync();

            var personJson = JsonConvert.SerializeObject(stringResponse);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEmpty(personJson);
        }

        [Fact]
        public async Task CreatePerson_SuccessTest()
        {
            var client = _factory.CreateClient();

            var person = PersonMock.PersonViewModelFaker.Generate();

            var response = await client.PostAsync("/api/v1/persons", new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CreatePerson_ErroTest()
        {
            var client = _factory.CreateClient();

            var person = PersonMock.PersonViewModelFakerError.Generate();

            var response = await client.PostAsync("/api/v1/persons", new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
