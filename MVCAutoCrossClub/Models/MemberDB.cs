using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace MVCAutoCrossClub.Models
{
    public class MemberDB
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
        public MemberDB(MemberVM vm)
        {
            this.id = vm.id;
            this.lastName = vm.lastName;
            this.firstName = vm.firstName;
            this.street = vm.street;
            this.city = vm.city;
            this.state = vm.state;
            this.zip = vm.zip;
            this.email = vm.email;
            this.phone = vm.phone;
        }
        public MemberDB()
            
        {


        }
    }
}