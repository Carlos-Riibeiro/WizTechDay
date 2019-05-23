using System.Threading.Tasks;
using WizTechDay.Domain.Interfaces.Repositorys;
using WizTechDay.Domain.Models;
using WizTechDay.Domain.Util;
using WizTechDay.Web.Services.Interfaces;
using WizTechDay.Web.ViewModels;

namespace WizTechDay.Web.Services
{
    public class InsertPerson : IInsertPerson
    {

        private readonly IPersonRepository _personRepository;

        public InsertPerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task InsertAsync(PersonViewModel personViewModel)
        {
            var personWithSameCpf = _personRepository.GetbyCpfAsync(personViewModel.Cpf);

            ValidatorRule.New()
                .With(personWithSameCpf != null, Resource.CpfExist)
                .ThrowExceptionIfExist();

            var person = new PersonModel(personViewModel.Name, personViewModel.Cpf, personViewModel.Email);

            await _personRepository.InsertAsync(person);
        }
    }
}
