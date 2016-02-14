using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCRUD.Models;
using SimpleCRUD.DAL;

namespace SimpleCRUD.Controllers
{
    public class DGCourseController : Controller
    {
        // GET: DGCourse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTable()
        {
            List<DGCourse> dgCourse = (List<DGCourse>)Session["DGCourse"];

            Session["dgCourse"] = dgCourse;

            return View(dgCourse);
        }

        public ActionResult ShowDetail(int id)
        {
            List<DGCourse> dgCourses = (List<DGCourse>)Session["dgCourse"];

            int index = dgCourses.FindIndex(a => a.ID == id);

            DGCourse dgCourse = dgCourses[index];

            return View(dgCourse);
        }


        public ActionResult DeleteDGCourse(int id)
        {
            List<DGCourse> dgCourses = (List<DGCourse>)Session["dgCourse"];
            DGCourse dgCourseToDelete = null;

            foreach (DGCourse dgCourse in dgCourses)
            {
                if (dgCourse.ID == id)
                {
                    dgCourseToDelete = dgCourse;
                }
            }

            return View(dgCourseToDelete);
        }

        [HttpPost]
        public ActionResult DeleteDGCourse(FormCollection form)
        {
            if (form["operation"] == "Delete")
            {
                List<DGCourse> dgCourses = (List<DGCourse>)Session["dgCourse"];

                int index = dgCourses.FindIndex(a => a.ID == Convert.ToInt32(form["ID"]));

                dgCourses.RemoveAt(index);

                Session["dgCourse"] = dgCourses;

            }

            return Redirect("/DGCourse/ShowTable");
        }

        public ActionResult CreateDGCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDGCourse(FormCollection form)
        {
            if (form["operation"] == "Add")
            {
                List<DGCourse> dgCourses = (List<DGCourse>)Session["dgCourses"];

                DGCourse newDGCourse = new DGCourse()
                {
                    ID = GetNextID(),
                    Name = form["name"],
                    Address = form["address"],
                    City = form["city"],
                    State = (AppEnum.StateAbrv)Enum.Parse(typeof(AppEnum.StateAbrv), form["state"]),
                    Zip = form["zip"],
                    Status = form["Status"]
                };

                dgCourses.Add(newDGCourse);

                Session["dgCourses"] = dgCourses;

            }

            return Redirect("/DGCourse/ShowTable");
        }

        public ActionResult UpdateDGCourse(int id)
        {
            List<DGCourse> DGCourse = (List<DGCourse>)Session["dgCourse"];
            DGCourse dgCourseToUpdate = null;

            foreach (DGCourse dgCourse in DGCourse)
            {
                if (dgCourse.ID == id)
                {
                    dgCourseToUpdate = dgCourse;
                }
            }

            return View(dgCourseToUpdate);
        }

        [HttpPost]
        public ActionResult UpdateDGCourse(FormCollection form)
        {
            if (form["operation"] == "Edit")
            {
                List<DGCourse> dgCourse = (List<DGCourse>)Session["dgCourse"];

                int index = dgCourse.FindIndex(a => a.ID == Convert.ToInt32(form["ID"]));

                dgCourse[index].Name = form["Name"];
                dgCourse[index].Address = form["Address"];
                dgCourse[index].City = form["City"];
                dgCourse[index].State = (AppEnum.StateAbrv)Enum.Parse(typeof(AppEnum.StateAbrv), form["State"]);
                dgCourse[index].Zip = form["Zip"];
                dgCourse[index].Status = form["Status"];

                Session["dgCourse"] = dgCourse;

            }

            return Redirect("/DGCourse/ShowTable");
        }

        public ActionResult ReloadData()
        {
            data.InitializeDGCourses();

            return Redirect("/DGCourse/ShowTable");
        }

        private int GetNextID()
        {
            List<DGCourse> dgCourse = (List<DGCourse>)Session["dgCourse"];

            return dgCourse.Max(x => x.ID) + 1;
        }
    }
}