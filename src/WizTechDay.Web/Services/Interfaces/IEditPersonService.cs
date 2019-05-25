using System.Threading.Tasks;
using WizTechDay.Web.ViewModels;

namespace WizTechDay.Web.Services.Interfaces
{
    public interface IEditPersonService
    {
        Task EditAsync(PersonViewModel personViewModel);
    }
}
