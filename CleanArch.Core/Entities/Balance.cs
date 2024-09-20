using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Core.Entities
{
    public class Balance
    {
        public string Username { get; set; }
        public int UserId { get; set; } 
        public decimal UserBalance { get; set; }
        public string BalanceType { get; set; }
    }
}
