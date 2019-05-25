using System.Threading.Tasks;
using WizTechDay.Domain.Interfaces.Repositorys;
using WizTechDay.Domain.Models;
using WizTechDay.Web.Services.Interfaces;
using WizTechDay.Web.ViewModels;

namespace WizTechDay.Web.Services
{
    public class EditPersonService : IEditPersonService
    {
        private readonly IPersonRepository _personRepository;

        public EditPersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task EditAsync(PersonViewModel personViewModel)
        {
             var model = await _personRepository.GetByIdAsync(personViewModel.Id);

            model.AlterName(personViewModel.Name);
            model.AlterCpf(personViewModel.Cpf);
            model.AlterEmail(personViewModel.Email);

            await _personRepository.UpdateAsync(model);
        }
    }
}
