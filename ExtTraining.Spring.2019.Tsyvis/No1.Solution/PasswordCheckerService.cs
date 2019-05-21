namespace No1.Solution
{
    using System;
    using System.Linq;

    using No1.Solution.Interfaces;
    using No1.Solution.Repositories;

    public class PasswordCheckerService
    {
        private IRepository repository;

        private IVerifyer verifyer;

        public PasswordCheckerService(IRepository repository, IVerifyer verifyer)
        {
            this.repository = repository;
            this.verifyer = verifyer;
        }

        public (bool, string) VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (password == string.Empty)
                return (false, $"{password} is empty ");

            if (this.verifyer.VerifyPassword(password))
            {
                this.repository.Create(password);

                return (true, "Password is Ok. User was created");
            }

            return (false, this.verifyer.ErrorMessage);
        }
    }
}
