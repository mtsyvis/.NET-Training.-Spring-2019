namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        public string Iban { get; }

        public string OwnerName { get; protected set; }

        public string OwnerSurname { get; protected set; }

        public string OwnerEmail { get; protected set; }

        public double Sum { get; protected set; }

        public double Points { get; protected set; }

        public abstract int BalanceValue { get; }

        public abstract int DepositeCost { get; }
    }
}
