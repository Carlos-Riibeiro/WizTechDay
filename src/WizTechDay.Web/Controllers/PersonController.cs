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
        private readonly IEditPersonService _editPerson;
        private readonly IDeletePersonService _deletePersonService;

        public PersonController(IListPersonService listPersonService, IInsertPerson insertPerson, IEditPersonService editPerson, IDeletePersonService deletePersonService)
        {
            _listPersonService = listPersonService;
            _insertPerson = insertPerson;
            _editPerson = editPerson;
            _deletePersonService = deletePersonService;
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

        public async Task<IActionResult> Edit(int id)
        {
            return View("Edit", await _listPersonService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditConfirm(PersonViewModel model)
        {
            await _editPerson.EditAsync(model);

            return View("Index", await _listPersonService.ListPersonAsync());
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _listPersonService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _deletePersonService.DeleteAsync(id);

            return View("Index", await _listPersonService.ListPersonAsync());
        }
    }
}