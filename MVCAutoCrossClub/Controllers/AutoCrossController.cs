﻿using BLL;
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

    //    static List<Member> members = new List<Member>();
    //    static List<Member> finalMembers = new List<Member>();
    //    //
    //    // GET: /Member/
    //    public ActionResult Index()
    //    {
    //        List<Member> memberIndexList = GetAllMembers();
    //        return View(memberIndexList);
    //    }

    //    public List<Member> GetAllMembers()
    //    {
    //        List<Member> memberList = new List<Member>();
    //        List<MemberVM> newMember = new List<MemberVM>();
    //        Logic logic = new Logic();
    //        Member member = new Member();
    //        newMember = logic.GetAllMembers();
    //        foreach (MemberVM memberVm in newMember)
    //        {
    //            member = ConvertMemberVmToMember(memberVm);
    //            bool x = memberList.Contains(member);
    //            if (x == false)
    //            {
    //                memberList.Add(member);
    //            }
    //        }
    //        return memberList;
    //    }

    //    //
    //    // GET: /Member/Details/5
    //    public ActionResult Details(Member member)
    //    {
    //        return View(member);
    //    }

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
            //if (!ModelState.IsValid)
            //{
            //    return View("Create", member);
            //}
            logic.CreateMember(member.lastName, member.firstName, member.street, member.city,
                member.state, member.zip, member.phone, member. email);
            return RedirectToAction("Members");
       }

    //    //
    //    // GET: /Member/Edit/5

        //[HttpGet]
        //    public ActionResult Edit(int id)
        //{
        //    Logic log = new Logic();
        //    MemberDB member = log.GetMemberById(id);
        //    return View(member);
        //}

    //    //
    //    // POST: /Member/Edit/5
        [HttpPost]
        public ActionResult Edit(MemberDB member, FormCollection collection)
        {
            Logic log = new Logic();
            List<MemberVM> memberList = log.GetAllMembers();
            Logic logic = new Logic();
            if (!ModelState.IsValid)
            {
                return View("Edit", member);
            }
            foreach (MemberVM mo in memberList)
            {
                if (mo.id == member.id)
                {
                    mo.id = member.id;
                    mo.lastName = member.lastName ?? "";
                    mo.firstName = member.firstName;
                    mo.street = member.street;
                    mo.city = member.city;
                    mo.state = member.state;
                    mo.zip = member.zip;
                    mo.phone = member.phone;
                    mo.email = member.email;
                    logic.UpdateMember(mo.id, mo.lastName, mo.firstName, mo.street, mo.city,
                                         mo.state, mo.zip, mo.phone, mo.email);
                }
            }
            return RedirectToAction("Members");
        }

        
    //  GET: /Member/Delete/5
        public ActionResult Delete(MemberDB member)
        {
            return View(member);
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
