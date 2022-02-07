using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository repository;
        public CourseController(ICourseRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            var courses = repository.GetCoursesByActive(true);
            ViewBag.CourseCount = courses.Count();
            return View(courses);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.ActionMode = "Edit";
            return View(repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Course entity)
        {
            repository.UpdateCourse(entity);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewBag.ActionMode = "Create";
            return View("Edit",new Course());
        }

        [HttpPost]
        public IActionResult Create(Course newCourse)
        {
            repository.CreateCourse(newCourse);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            repository.DeleteCourse(id);
            return RedirectToAction("Index");
           
        }


    }
}
