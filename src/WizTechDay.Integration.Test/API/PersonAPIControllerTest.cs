using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
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
        public async Task ListPerson_HttpStatusOkTest()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("api/v1/persons");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
