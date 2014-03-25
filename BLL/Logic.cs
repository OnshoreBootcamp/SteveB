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
                memberVmList.Add(ConvertMember(memberDm));
            }
            return memberVmList;
        }


        private MemberVM ConvertMember(MemberDM memberDm)
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
        private MemberDM ConvertMember(MemberVM vm)
        {
            MemberDM dm = new MemberDM();
            if (vm != null)
            {
                MemberDAO dao = new MemberDAO();
                dm.id = vm.id;
                dm.lastName = vm.lastName;
                dm.firstName = vm.firstName;
                dm.street = vm.street;
                dm.city = vm.city;
                dm.state = vm.state;
                dm.zip = vm.zip;
                dm.phone = vm.phone;
                dm.email = vm.email;
            }
            return dm;
        }



        public void CreateMember(MemberVM vm)
        {
            MemberDAO dao = new MemberDAO();
            dao.CreateMember(ConvertMember(vm));
        }
        public int GetmemberId(MemberVM vm)
        {
            MemberDAO dao = new MemberDAO();
            MemberDM member = dao.GetMember(ConvertMember(vm));
            if (member == null)
            {
                CreateMember(vm);
            }
            return dao.GetMember(ConvertMember(vm)).id;
        }
        public void DeleteMember(int id)
        {
            MemberDAO dao = new MemberDAO();
            dao.DeleteMember(id);
         }

        public void UpdateMember(MemberVM member)
        {
            MemberDM memberDm = ConvertMember(member);
            MemberDAO dao = new MemberDAO();

            dao.UpdateMemberDB(memberDm);
        }
        public MemberVM GetMemberById(int id)
        {
            MemberDAO dao = new MemberDAO();
            MemberDM dm = dao.GetMemberById(id);
            return ConvertMember(dm);
        }
    }
}
 

