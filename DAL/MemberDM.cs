using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MemberDM
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
    }
}
