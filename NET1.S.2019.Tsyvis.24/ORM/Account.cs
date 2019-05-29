namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [Key]
        [StringLength(200)]
        public string Iban { get; set; }

        public int OwnerId { get; set; }

        public decimal Balance { get; set; }

        public decimal BonusPoints { get; set; }

        public int AccountTypeId { get; set; }

        public bool IsClosed { get; set; }

        public virtual AccountOwner AccountOwner { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
