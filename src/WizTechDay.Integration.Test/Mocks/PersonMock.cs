using Bogus;
using Bogus.Extensions.Brazil;
using WizTechDay.Web.ViewModels;

namespace WizTechDay.Integration.Test.Mocks
{
    public static class PersonMock
    {
        public static Faker<PersonViewModel> PersonViewModelFaker =>
            new Faker<PersonViewModel>("pt_BR")
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Cpf, f => f.Person.Cpf()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty))
            .RuleFor(x => x.Email, f => f.Person.Email);

        public static Faker<PersonViewModel> PersonViewModelFakerError =>
            new Faker<PersonViewModel>("pt_BR")
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Cpf, f => f.Person.Cpf())
            .RuleFor(x => x.Email, f => f.Person.Email);
    }
}
