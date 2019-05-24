using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizTechDay.Domain.Interfaces.Repositorys;
using WizTechDay.Domain.Models;
using WizTechDay.Infra.Context;

namespace WizTechDay.Infra.Repositorys
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DapperContext _dapperContext;

        public PersonRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<PersonModel> GetbyCpfAsync(object cpf)
        {
            var query = @"SELECT Name, Cpf, Email FROM dbo.Person
                            WHERE Cpf = @Cpf";

            return await _dapperContext.WizTechDayConnection.QueryFirstOrDefaultAsync(query, new { Cpf = cpf });
        }

        public async Task InsertAsync(PersonModel person)
        {
            var query = @"INSERT INTO dbo.Person
                          VALUES(@Name, @Cpf, @Email)";

            await _dapperContext.WizTechDayConnection.ExecuteAsync(query, new { Name = person.Name, Cpf = person.Cpf, Email = person.Email });
        }

        public async Task<IEnumerable<PersonModel>> ListPersonAsync()
        {
            var query = @"SELECT Name, Cpf, Email FROM dbo.Person";

            return await _dapperContext.WizTechDayConnection.QueryAsync<PersonModel>(query);
        }
    }
}
