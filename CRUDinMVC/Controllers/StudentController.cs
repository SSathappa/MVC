using CRUDinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDinMVC.Controllers
{
    public class StudentController : Controller
    {
        // READ ALL
        // GET: /Student/
        public ActionResult Index()
        {
            ViewBag.Title = "Create <new Student> | edit | view detail | delete <Student>";
            StudentDBHandle dbhandle = new StudentDBHandle();
            ModelState.Clear();
            return View(dbhandle.ReadStudent());
        }

        // READ INDIVIDUAL
        // GET: /Student/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Title = "Student Detail";
            StudentDBHandle dbhandle = new StudentDBHandle();
            return View(dbhandle.ReadStudent().Find(smodel => smodel.Id == id));
        }

        // CREATE (basic load)
        // GET: /Student/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create Student";
            return View();
        }

        // CREATE POST
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    StudentDBHandle dbhandle = new StudentDBHandle();
                    if (dbhandle.CreateStudent(smodel))
                    {
                        ViewBag.Message = "Student detail created successfully.";
                        ModelState.Clear();
                    }
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // UPDATE (load base view)
        // GET: /Student/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Student detail";
            StudentDBHandle dbhandle = new StudentDBHandle();
            return View(dbhandle.ReadStudent().Find(smodel => smodel.Id == id));
        }

        // UPDATE POST
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentDBHandle dbhandle = new StudentDBHandle();
                    if(dbhandle.UpdateStudent(smodel))
                    {
                        ViewBag.Message = "Student details updated Successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // DELETE (load base view)
        // GET: /Student/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete Student detail";
            StudentDBHandle dbhandle = new StudentDBHandle();
            return View(dbhandle.ReadStudent().Find(smodel => smodel.Id == id));
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentModel smodel)
        {
            try
            {
                //* No ModelState.IsValid check is required (returns false)
                //if (ModelState.IsValid)
                //{
                    StudentDBHandle dbhandle = new StudentDBHandle();
                    if (dbhandle.DeletStudent(smodel))
                    {
                        ViewBag.Message = "Student detail is deleted successfully";
                    }
                //}

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
