using WizTechDay.Domain.Models;

namespace WizTechDay.Domain.Test.Builders
{
    public class PersonBuilder
    {
        private string _name = "Carlos Ribeiro";
        private string _email = "carlos@carlos.com";
        private string _cpf = "14512042059";

        public static PersonBuilder New()
        {
            return new PersonBuilder();
        }

        public PersonBuilder WithFirstName(string name)
        {
            _name = name;
            return this;
        }

        public PersonBuilder WithEmail(string Email)
        {
            _email = Email;
            return this;
        }

        public PersonBuilder WithCpf(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public PersonModel Build()
        {
            return new PersonModel(_name, _cpf, _email);
        }
    }
}
