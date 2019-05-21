using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Verifyers
{
    using No1.Solution.Interfaces;

    public class PasswordLengthTooShortVeryfier : IVerifyer
    {
        private readonly string errorMessage = "length too short";

        public string ErrorMessage => this.errorMessage;

        bool IVerifyer.VerifyPassword(string password)
        {
            return password.Length <= 7;
        }
    }
}
