namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        protected double balance;

        public string Iban { get; set; }

        public User Owner { get; set; }

        public double Balance
        {
            get => this.balance;

            set
            {
                this.RecountPoints(this.balance);
                this.balance = value;
            }
        }

        public double Points { get;  set; }

        public bool IsClosed { get;  set; }

        public abstract AccountType Type { get; }

        protected abstract int WithdrawCost { get; }

        protected abstract int DepositCost { get; }

        protected abstract void RecountPoints(double oldSumValue);
    }
}
