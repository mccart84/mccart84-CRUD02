using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCRUD.Models;

namespace SimpleCRUD.DAL
{
    public class data
    {
        public static void InitializeDGCourses()
        {
            //
            // Create a temporary list of breweries
            //
            List<DGCourse> dgCourse = new List<DGCourse>();

            dgCourse.Add(new DGCourse
            {
                ID = 1,
                Name = "Log Lake",
                Address = "2475 Log Lake Rd NE",
                City = "Kalkaska",
                State = AppEnum.StateAbrv.MI,
                Zip = "49646",
                Open = true
            });

            dgCourse.Add(new DGCourse
            {
                ID = 2,
                Name = "Hickory Hills",
                Address = "Hickory Hills Rd",
                City = "Traverse City",
                State = AppEnum.StateAbrv.MI,
                Zip = "49684",
                Open = true
            });

            //
            // Store the list of breweries in a session variable
            //
            HttpContext.Current.Session["DGCourse"] = dgCourse;

        }
    }
}