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




        public List<EventDateVM> GetAllEventDates()
        {
            List<EventDateVM> dateVmList = new List<EventDateVM>();
            List<EventDateDM> dateDmList = new List<EventDateDM>();
            EventDateDAO dao = new EventDateDAO();
            dateDmList = dao.GetAllEventDates();
            foreach (EventDateDM dateDm in dateDmList)
            {
                dateVmList.Add(ConvertEventDate(dateDm));
            }
            return dateVmList;
        }
        public EventDateVM ConvertEventDate(EventDateDM dateDm)
        {
            EventDateVM dateVM = new EventDateVM();
            if (dateDm != null)
            {
                EventDateDAO dao = new EventDateDAO();
                dateVM.id = dateDm.id;
                dateVM.Date = dateDm.Date;
            }
            return dateVM;
        }
        public EventDateDM ConvertEventDate(EventDateVM vm)
        {
            EventDateDM dm = new EventDateDM();
            if (vm != null)
            {
                EventDateDAO dao = new EventDateDAO();
                dm.id = vm.id;
                dm.Date = vm.Date;
            }
            return dm;
        }
        public void CreateEventDate(EventDateVM vm)
        {
            EventDateDAO dao = new EventDateDAO();
            dao.CreateEventDate(ConvertEventDate(vm));
        }
        public int GetDateId(EventDateVM vm)
        {
            EventDateDAO dao = new EventDateDAO();
            EventDateDM Date = dao.GetEventDate(ConvertEventDate(vm));
            if (Date == null)
            {
                CreateEventDate(vm);
            }
            return dao.GetEventDate(ConvertEventDate(vm)).id;
        }
        public void DeleteEventDate(int id)
        {
            EventDateDAO dao = new EventDateDAO();
            dao.DeleteEventDate(id);
        }
        public void UpdateEventDate(EventDateVM Date)
        {
            EventDateDM DateDm = ConvertEventDate(Date);
            EventDateDAO dao = new EventDateDAO();
            dao.UpdateEventDateDB(DateDm);
        }
        public EventDateVM GetEventDateById(int id)
        {
            EventDateDAO dao = new EventDateDAO();
            EventDateDM dm = dao.GetEventDateById(id);
            return ConvertEventDate(dm);
        }

    }
}
 

