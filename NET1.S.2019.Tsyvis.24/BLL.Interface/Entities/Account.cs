namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        private double sum;

        public string Iban { get; }

        public string OwnerName { get; protected set; }

        public string OwnerSurname { get; protected set; }

        public string OwnerEmail { get; protected set; }

        public double Sum
        {
            get => this.sum;

            protected set
            {
                this.RecountPoints(this.sum);
                this.sum = value;
            }
        }

        public double Points { get; protected set; }

        public AccountType Type { get; protected set; }

        public abstract int WithdrawCost { get; }

        public abstract int DepositCost { get; }

        protected abstract void RecountPoints(double oldSumValue);
    }
}
