using WizTechDay.Domain.Util;
using Xunit;

namespace WizTechDay.Domain.Test.Util
{
    public static class AssertExtension
    {
        public static void WithMessage(this ExceptionDomain exception, string message)
        {
            if (exception.MessageError.Contains(message))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{message}'");
        }
    }
}
