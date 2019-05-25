using System.Threading.Tasks;

namespace WizTechDay.Web.Services.Interfaces
{
    public interface IDeletePersonService
    {
        Task DeleteAsync(int id);
    }
}
