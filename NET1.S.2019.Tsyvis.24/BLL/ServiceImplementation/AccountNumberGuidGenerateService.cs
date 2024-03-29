﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    using BLL.Interface.Interfaces;

    public class AccountNumberGuidGenerateService : IAccountNumberGenerateService
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
