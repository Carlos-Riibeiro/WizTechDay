using Bogus;
using Bogus.Extensions.Brazil;
using ExpectedObjects;
using WizTechDay.Domain.Models;
using WizTechDay.Domain.Test.Builders;
using WizTechDay.Domain.Test.Util;
using WizTechDay.Domain.Util;
using Xunit;

namespace WizTechDay.Domain.Test.Pessoa
{
    public class PessoaTest
    {
        private readonly Faker _faker;
        private readonly string _name;
        private readonly string _email;
        private readonly string _cpf;

        public PessoaTest()
        {
            _faker = new Faker("pt_BR");

            _name = _faker.Person.FullName;
            _email = _faker.Person.Email;
            _cpf = _faker.Person.Cpf();
        }

        [Fact]
        public void MustCreatePerson_ReturnsSamePerson()
        {
            var personExpected = new
            {
                Name = _name,
                Cpf = _cpf,
                Email = _email
            };

            var person = new PersonModel(personExpected.Name, personExpected.Cpf, personExpected.Email);

            personExpected.ToExpectedObject().ShouldMatch(person);
        }

        [Fact]
        public void MustAlterName_ReturnNewName()
        {
            var nameEsperado = _faker.Person.FirstName;
            var person = PersonBuilder.New().Build();

            person.AlterName(nameEsperado);

            Assert.Equal(nameEsperado, person.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NotMustCreatePersonWithNameInvalid_ReturnException(string nameInvalid)
        {
            Assert.Throws<ExceptionDomain>(() => 
                PersonBuilder.New().WithFirstName(nameInvalid).Build())
                .WithMessage(Resource.NameInvalid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("teste@teste")]
        [InlineData("teste.teste")]
        public void NotMustCreatePersonWithEmailInvalid_ReturnException(string emailInvalid)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PersonBuilder.New().WithEmail(emailInvalid).Build())
                .WithMessage(Resource.EmailInvalid);
        }

        [Theory]
        [InlineData("99999999999")]
        [InlineData("999.999.999-99")]
        public void NotMustCreatePersonWithCpfInvalid_ReturnException(string cpfInvalid)
        {
            Assert.Throws<ExceptionDomain>(() =>
                PersonBuilder.New().WithCpf(cpfInvalid).Build())
                .WithMessage(Resource.CpfInvalid);
        }
    }
}
