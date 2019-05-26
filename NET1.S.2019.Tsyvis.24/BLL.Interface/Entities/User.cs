﻿using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public IEnumerable<Account> Accounts { get; set; } 
    }
}
