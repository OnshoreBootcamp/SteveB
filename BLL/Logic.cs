using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Logic
    {
        public List<MemberVM> GetAllMembers()
        {
            List<MemberVM> memberVmList = new List<MemberVM>();
            List<MemberDM> memberDmList = new List<MemberDM>();
            MemberDAO dao = new MemberDAO();
            memberDmList = dao.GetAllMembers();
            foreach (MemberDM memberDm in memberDmList)
            {
                memberVmList.Add(ConvertMemberDmToVm(memberDm));
            }
            return memberVmList;
        }


        private MemberVM ConvertMemberDmToVm(MemberDM memberDm)
        {
            MemberVM memberVM = new MemberVM();
            if (memberDm != null)
            {
                MemberDAO dao = new MemberDAO();
                memberVM.id = memberDm.id;
                memberVM.lastName = memberDm.lastName;
                memberVM.firstName = memberDm.firstName;
                memberVM.street = memberDm.street;
                memberVM.city = memberDm.city;
                memberVM.state = memberDm.state;
                memberVM.zip = memberDm.zip;
                memberVM.phone = memberDm.phone;
                memberVM.email = memberDm.email;
            }
            return memberVM;
        }


        public void CreateMember(string lastName, string firstName, string street, string city,
                            string state, int zip, int phone, string email)
        {
            MemberDAO dao = new MemberDAO();
            dao.CreateMember(lastName, firstName, street, city, state, zip, phone, email);
        }
        public void GetmemberId(string lastName, string firstName, string street, string city,
                           string state, int zip, int phone, string email)
        {
            MemberDAO dao = new MemberDAO();
            MemberDM movie = dao.GetMember(lastName, firstName, street, city, state, zip, phone, email);
            if (movie == null)
            {
                CreateMember(lastName, firstName, street, city, state, zip, phone, email);
                movie.id = dao.GetMember(lastName, firstName, street, city, state, zip, phone, email).id;
            }
        }
        public void DeleteMember(int id)
        {
            MemberDAO dao = new MemberDAO();
            dao.DeleteMember(id);
         }

        public void UpdateMember(int id, string lastName, string firstName, string street, string city,
                           string state, int zip, int phone, string email)
        {
            MemberDM memberDm = new MemberDM();
            MemberDAO dao = new MemberDAO();
            dao.UpdateMemberDB(id, lastName, firstName, street, city, state, zip, phone, email);
        }
    }
}
 

