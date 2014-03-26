using BLL;
using MVCAutoCrossClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAutoCrossClub.Controllers
{
    public class AutoCrossController : Controller
    {
        public ActionResult Members()
        {
            Logic log = new Logic();
            List<BLL.MemberVM> members = log.GetAllMembers();
            return View("Members", members);
        }

       //  GET: /Member/Create
        public ActionResult Create()
        {
            return View();
        }
     //    POST: /Member/Create
        [HttpPost]
        public ActionResult Create(MemberDB member)
        {
            Logic logic = new Logic();
            MemberVM mo = new MemberVM();
            mo.id = member.id;
            mo.lastName = member.lastName ?? "";
            mo.firstName = member.firstName;
            mo.street = member.street;
            mo.city = member.city;
            mo.state = member.state;
            mo.zip = member.zip;
            mo.phone = member.phone;
            mo.email = member.email;
            logic.CreateMember(mo);
            return RedirectToAction("Members");
       }
         //GET: /Member/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Logic log = new Logic();
            MemberVM member = log.GetMemberById(id);
            MemberDB db = new MemberDB(member);
            return View(db);
        }
         // POST: /Member/Edit/5
        [HttpPost]
        public ActionResult Edit(MemberDB member, FormCollection collection)
        {
            Logic log = new Logic();
            MemberVM mo = new MemberVM();
            
            mo.id = member.id;
            mo.lastName = member.lastName ?? "";
            mo.firstName = member.firstName;
            mo.street = member.street;
            mo.city = member.city;
            mo.state = member.state;
            mo.zip = member.zip;
            mo.phone = member.phone;
            mo.email = member.email;
            log.UpdateMember(mo);
            return RedirectToAction("Members");
        }
    //  GET: /Member/Delete/5
        public ActionResult Delete(int id)
        {
            Logic log = new Logic();
            MemberVM member = log.GetMemberById(id);
            MemberDB db = new MemberDB(member);
            return View(db);
        }
    //  POST: /Member/Delete/5
        [HttpPost]
        public ActionResult Delete(MemberDB member, FormCollection collection)
        {
            List<MemberVM> newMember = new List<MemberVM>();
            Logic logic = new Logic();
            newMember = logic.GetAllMembers();
            foreach (MemberVM mo in newMember)
            {
                if (mo.id == member.id)
                {
                    logic.DeleteMember(mo.id);
                }
            }
            return RedirectToAction("Members");
        }
        public MemberVM ConvertMemberVmToMember(MemberVM memberVm)
        {
            MemberVM member = new MemberVM();
            if (memberVm != null)
            {
                member.id = memberVm.id;
                member.lastName = memberVm.lastName;
                member.firstName = memberVm.firstName;
                member.street = memberVm.street;
                member.city = memberVm.city;
                member.state = memberVm.state;
                member.zip = memberVm.zip;
                member.phone = memberVm.phone;
                member.email = memberVm.email;
            }
            return member;
        }
    }
}
