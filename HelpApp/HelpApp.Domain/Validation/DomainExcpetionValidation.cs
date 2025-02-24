using System;

namespace HelpApp.Domain.Validation
{
    public class DomainExcpetionValidation : Exception
    {
        public DomainExcpetionValidation(string error) : base(error) { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExcpetionValidation(error);
            }
        }
    }
}
