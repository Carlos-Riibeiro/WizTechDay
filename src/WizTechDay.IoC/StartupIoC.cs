using Microsoft.Extensions.DependencyInjection;
using WizTechDay.Domain.Interfaces.Repositorys;
using WizTechDay.Infra.Context;
using WizTechDay.Infra.Repositorys;

namespace WizTechDay.IoC
{
    public class StartupIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Infra

            #region Context

            services.AddScoped<DapperContext>();

            #endregion

            #region Repository

            services.AddScoped<IPersonRepository, PersonRepository>();

            #endregion

            #endregion
        }
    }
}
