namespace No1.Solution.Verifyers
{
    using No1.Solution.Interfaces;

    public class PasswordLengthTooLongVerifyer : IVerifyer
    {
        private readonly string errorMessage = "length too long";

        public string ErrorMessage => this.errorMessage;

        bool IVerifyer.VerifyPassword(string password)
        {
            return password.Length >= 15;
        }
    }
}
