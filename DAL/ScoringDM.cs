using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ScoringDM
    {
        public int id { get; set; }
        public int DateID { get; set; }
        public int memberID { get; set; }
        public int carNumberID { get; set; }
        public int autoClassID { get; set; }
        public string run { get; set; }
        public decimal runTime { get; set; }
    }
}
