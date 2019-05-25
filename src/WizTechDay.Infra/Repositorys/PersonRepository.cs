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
            var query = @"SELECT Id, Name, Cpf, Email FROM dbo.Person
                            WHERE Cpf = @Cpf";

            return await _dapperContext.WizTechDayConnection.QueryFirstOrDefaultAsync<PersonModel>(query, new { Cpf = cpf });
        }

        public async Task<PersonModel> GetByIdAsync(int id)
        {
            var query = @"SELECT Id, Name, Cpf, Email FROM dbo.Person
                            WHERE Id = @Id";

            return await _dapperContext.WizTechDayConnection.QueryFirstOrDefaultAsync<PersonModel>(query, new { Id = id });
        }

        public async Task InsertAsync(PersonModel person)
        {
            var query = @"INSERT INTO dbo.Person
                          VALUES(@Name, @Cpf, @Email)";

            await _dapperContext.WizTechDayConnection.ExecuteAsync(query, new { Name = person.Name, Cpf = person.Cpf, Email = person.Email });
        }

        public async Task<IEnumerable<PersonModel>> ListPersonAsync()
        {
            var query = @"SELECT Id, Name, Cpf, Email FROM dbo.Person";

            return await _dapperContext.WizTechDayConnection.QueryAsync<PersonModel>(query);
        }

        public async Task UpdateAsync(PersonModel model)
        {
            var query = @"UPDATE dbo.Person
                            SET Name = @Name, Cpf = @Cpf, Email = @Email
                            WHERE Id = @Id";

            await _dapperContext.WizTechDayConnection.ExecuteAsync(query, new { Name = model.Name, Cpf = model.Cpf, Email = model.Email, Id = model.Id });
        }

        public async Task DeleteAsync(int id)
        {
            var query = @"DELETE FROM dbo.Person
                            WHERE Id = @Id";

            await _dapperContext.WizTechDayConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
