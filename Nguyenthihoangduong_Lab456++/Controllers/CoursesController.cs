﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nguyenthihoangduong_Lab456__.Models;
using Nguyenthihoangduong_Lab456__.ViewModels;



namespace Nguyenthihoangduong_Lab456__.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerID = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryID = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("index", "Home");
        }
        //[Authorize]
        //public ActionResult Edit(int id)
        //{
        //    var userId = User.Identity.GetUserId();
        //    var courses = _dbContext.Courses.Single(c => c.Id == id && c.LecturerID == userId);
        //    var viewModel = new CourseViewModel
        //    {
        //        Categories = _dbContext.Categories.ToList(),
        //        Date = course.DateTime.ToString("dd/M/yyyy"),
        //        Time = course.DateTime.ToString("HH:mm"),
        //        Category = course.CategoryID,
        //        Place = course.Place
        //    };
        //    return View("Create", viewModel);
        //}
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var courses = _dbContext.Attendances
            .Where(a => a.AttendeeId == userId)
            .Select(a => a.Course)
            .Include(l => l.Lecturer)
            .Include(l => l.Category)
            .ToList();

            var viewModel = new CourseViewModel
            {
                UpcommingCourse = courses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Mine() {
            var userīd = User.Identity.GetUserId();
            var courses = _dbContext.Courses
            .Where(c=>c.LecturerID == userīd && c.DateTime > DateTime.Now)
            .Include(c=>c.Lecturer)
            .Include(c => c.Category)
            .ToList();
            return View(courses);    
        }
        }
}