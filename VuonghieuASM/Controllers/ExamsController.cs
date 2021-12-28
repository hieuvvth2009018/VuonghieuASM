using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VuonghieuASM.Data;
using VuonghieuASM.Models;

namespace VuonghieuASM.Controllers
{
    public class ExamsController : Controller
    {
        private VuonghieuASMContext db = new VuonghieuASMContext();

        // GET: Exams
        public ActionResult Index()
        {
            return View(db.Exams.ToList());
        }


        // GET: Exams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamSubject,StartTime,ExamDate,ExamDuration,ClassRoom,Faculty,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam);
        }
    }
}
