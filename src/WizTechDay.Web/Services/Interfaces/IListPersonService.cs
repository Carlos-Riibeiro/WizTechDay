using System.Collections.Generic;
using System.Threading.Tasks;
using WizTechDay.Domain.Models;

namespace WizTechDay.Web.Services.Interfaces
{
    public interface IListPersonService
    {
        Task<IEnumerable<PersonModel>> ListPersonAsync();
        Task<PersonModel> GetByIdAsync(int id);
    }
}
