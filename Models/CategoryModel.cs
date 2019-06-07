using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobApplicationSiteVtwo.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="نوع الوظيفة")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "وصف الوظيفة")]
        public string CategoryDescription { get; set; }
    }
}