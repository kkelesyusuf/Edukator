using Edukator.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edukator.PresentationLayer.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.totalCategory = context.Categories.Count();
            ViewBag.totalCourse = context.Courses.Count();
            ViewBag.totalCoursePrice = context.Courses.Sum(x => x.Price);
            ViewBag.getAlgoritmaProgramlamaCoursePrice = context.Courses.Where(x => x.Title == "SQL Veri Tabanı").Select(y => y.Price).FirstOrDefault();


            ViewBag.avgReview = context.Courses.Average(x => x.Review);
            ViewBag.getOver30Price = context.Courses.Where(x => x.Price > 30).Count();
            ViewBag.lastCoursePrice = context.Courses.Where(x => x.CourseID == 5).Select(y => y.Price).FirstOrDefault();
            ViewBag.getTitleByCourseID2 = context.Courses.Where(x => x.CategoryID == 2).Select(y => y.Title).FirstOrDefault();

            
            return View();
        }
    }
}
