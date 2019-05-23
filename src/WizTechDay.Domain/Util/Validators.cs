using Caelum.Stella.CSharp.Validation;
using System.Text.RegularExpressions;

namespace WizTechDay.Domain.Util
{
    public class Validators
    {

        public static bool IsCpf(string cpf)
        {
            return new CPFValidator().IsValid(cpf);
        }

        public static bool IsEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(email))
                return true;

            return false;
        }
    }
}
