using WizTechDay.Domain.Util;

namespace WizTechDay.Domain.Models
{
    public class PersonModel
    {
        private PersonModel() { }

        public PersonModel(string name, string cpf, string email)
        {
            ValidatorRule.New()
                .With(!string.IsNullOrEmpty(name), Resource.NameInvalid)
                .With(Validators.IsCpf(cpf), Resource.CpfInvalid)
                .With(Validators.IsEmail(email), Resource.EmailInvalid)
                .ThrowExceptionIfExist();

            Name = name;
            Cpf = cpf;
            Email = email;
        }

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        public void AlterName(string name)
        {
            ValidatorRule.New()
                .With(!string.IsNullOrEmpty(name), Resource.NameInvalid)
                .ThrowExceptionIfExist();

            Name = name;
        }
    }
}
