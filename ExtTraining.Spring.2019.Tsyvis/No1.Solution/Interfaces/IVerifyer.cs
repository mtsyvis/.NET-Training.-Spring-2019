using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution.Interfaces
{
    public interface IVerifyer
    {
        string ErrorMessage { get;}

        bool VerifyPassword(string password);
    }
}
