namespace DAL.Interface.DTO
{
    public class Account
    {
        public string Iban { get; }

        public string OwnerName { get; set; }

        public string OwnerSurname { get; set; }

        public string OwnerEmail { get; set; }

        public double Sum { get; set; }

        public double Points { get; set; }

        public string AccountType { get; set; }
    }
}
