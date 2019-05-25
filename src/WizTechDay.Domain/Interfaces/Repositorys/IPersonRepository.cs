using System.Collections.Generic;
using System.Threading.Tasks;
using WizTechDay.Domain.Models;

namespace WizTechDay.Domain.Interfaces.Repositorys
{
    public interface IPersonRepository
    {
        Task InsertAsync(PersonModel person);
        Task<PersonModel> GetbyCpfAsync(object cpf);
        Task<IEnumerable<PersonModel>> ListPersonAsync();
        Task<PersonModel> GetByIdAsync(int id);
        Task UpdateAsync(PersonModel model);
        Task DeleteAsync(int id);
    }
}
