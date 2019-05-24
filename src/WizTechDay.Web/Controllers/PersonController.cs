using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizTechDay.Web.Services.Interfaces;
using WizTechDay.Web.ViewModels;

namespace WizTechDay.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IListPersonService _listPersonService;
        private readonly IInsertPerson _insertPerson;

        public PersonController(IListPersonService listPersonService, IInsertPerson insertPerson)
        {
            _listPersonService = listPersonService;
            _insertPerson = insertPerson;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _listPersonService.ListPersonAsync());
        }
        
        public ActionResult Create()
        {
            return View("Create", new PersonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(PersonViewModel model)
        {
            await _insertPerson.InsertAsync(model);

            return Ok();
        }
    }
}