﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Nguyenthihoangduong_Lab456__.Models;
using Nguyenthihoangduong_Lab456__.ViewModels;

namespace Nguyenthihoangduong_Lab456__.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Course> UpcommingCourse { get; set; }
        public bool ShowAction { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}