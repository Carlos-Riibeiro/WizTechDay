using System;
using System.Collections.Generic;

namespace WizTechDay.Domain.Util
{
    public class ExceptionDomain : ArgumentException
    {
        public List<string> MessageError { get; set; }

        public ExceptionDomain(List<string> messageErrors)
        {
            MessageError = messageErrors;
        }
    }
}
