using System.Collections.Generic;
using System.Linq;

namespace WizTechDay.Domain.Util
{
    public class ValidatorRule
    {
        private readonly List<string> _messageErrors;

        private ValidatorRule()
        {
            _messageErrors = new List<string>();
        }

        public static ValidatorRule New()
        {
            return new ValidatorRule();
        }

        public ValidatorRule With(bool isErro, string messageError)
        {
            if (!isErro)
                _messageErrors.Add(messageError);

            return this;
        }

        public void ThrowExceptionIfExist()
        {
            if (_messageErrors.Any())
                throw new ExceptionDomain(_messageErrors);
        }
    }
}
