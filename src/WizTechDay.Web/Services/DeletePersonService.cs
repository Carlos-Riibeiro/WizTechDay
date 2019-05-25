using System.Threading.Tasks;
using WizTechDay.Domain.Interfaces.Repositorys;
using WizTechDay.Web.Services.Interfaces;

namespace WizTechDay.Web.Services
{
    public class DeletePersonService : IDeletePersonService
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task DeleteAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
        }
    }
}
