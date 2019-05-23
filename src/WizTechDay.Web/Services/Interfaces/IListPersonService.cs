using System.Collections.Generic;
using System.Threading.Tasks;
using WizTechDay.Domain.Models;
using WizTechDay.Web.ViewModels;

namespace WizTechDay.Web.Services.Interfaces
{
    public interface IListPersonService
    {
        Task<IEnumerable<PersonModel>> ListPersonAsync();
    }
}
