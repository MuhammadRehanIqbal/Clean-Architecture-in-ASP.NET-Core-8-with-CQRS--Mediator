using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Authentication.Queries.Balance
{
    public class BalanceResponse
    { 
        public string Type { get; set; }
        public decimal UserBalance {  get; set; }

    }
}
