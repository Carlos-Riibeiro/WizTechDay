using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizTechDay.Domain.Models;
using WizTechDay.Web.Services.Interfaces;
using WizTechDay.Web.ViewModels;

namespace WizTechDay.Web.Controllers.API
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/persons")]
    public class PersonAPIController : ControllerBase
    {
        private readonly IListPersonService _listPersonService;
        private readonly IInsertPerson _insertPerson;

        public PersonAPIController(IListPersonService listPersonService, IInsertPerson insertPerson)
        {
            _listPersonService = listPersonService;
            _insertPerson = insertPerson;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonModel>>> List()
        {
            return Ok(await _listPersonService.ListPersonAsync());
        }

        [HttpPost]
        public async Task<ActionResult<PersonModel>> Post([FromBody] PersonViewModel person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            await _insertPerson.InsertAsync(person);

            return Created("/", person);
        }
    }
}
