using WizTechDay.Domain.Util;

namespace WizTechDay.Domain.Models
{
    public class PersonModel
    {
        private PersonModel() { }

        public PersonModel(string name, string cpf, string email)
        {
            ValidatorRule.New()
                .With(string.IsNullOrEmpty(name), Resource.NameInvalid)
                .With(string.IsNullOrEmpty(cpf) || !Validators.IsCpf(cpf), Resource.CpfInvalid)
                .With(string.IsNullOrEmpty(email) || !Validators.IsEmail(email), Resource.EmailInvalid)
                .ThrowExceptionIfExist();

            Name = name;
            Cpf = cpf;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }

        public void AlterName(string name)
        {
            ValidatorRule.New()
                .With(string.IsNullOrEmpty(name), Resource.NameInvalid)
                .ThrowExceptionIfExist();

            Name = name;
        }

        public void AlterCpf(string cpf)
        {
            ValidatorRule.New()
                .With(string.IsNullOrEmpty(cpf) || !Validators.IsCpf(cpf), Resource.CpfInvalid)
                .ThrowExceptionIfExist();

            Cpf = cpf;
        }

        public void AlterEmail(string email)
        {
            ValidatorRule.New()
                .With(string.IsNullOrEmpty(email) || !Validators.IsEmail(email), Resource.EmailInvalid)
                .ThrowExceptionIfExist();

            Email = email;
        }
    }
}
