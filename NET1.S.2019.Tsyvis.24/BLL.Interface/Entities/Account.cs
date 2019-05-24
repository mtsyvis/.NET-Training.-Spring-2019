namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        protected double sum;

        public string Iban { get; set; }

        public string OwnerName { get; set; }

        public string OwnerSurname { get; set; }

        public string OwnerEmail { get; set; }

        public double Sum
        {
            get => this.sum;

            set
            {
                this.RecountPoints(this.sum);
                this.sum = value;
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
