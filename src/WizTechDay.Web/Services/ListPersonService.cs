using System.Collections.Generic;
using System.Threading.Tasks;
using WizTechDay.Domain.Interfaces.Repositorys;
using WizTechDay.Domain.Models;
using WizTechDay.Web.Services.Interfaces;

namespace WizTechDay.Web.Services
{
    public class ListPersonService : IListPersonService
    {
        private readonly IPersonRepository _personRepository;

        public ListPersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<PersonModel>> ListPersonAsync()
        {
            return await _personRepository.ListPersonAsync();
        }
    }
}
