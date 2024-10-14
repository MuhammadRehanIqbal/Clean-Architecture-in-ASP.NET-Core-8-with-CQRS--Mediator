using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Core.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public int PhoneCode { get; set; }


    }
}
