namespace DAL.Interface.DTO
{
    public class DtoAccount
    {
        public string Iban { get; set; }

        public double Balance { get; set; }

        public double Points { get; set; }

        public string AccountType { get; set; }

        public bool IsClosed { get; set; }

        public int OwnerId { get; set; }
    }
}
