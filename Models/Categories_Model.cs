using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobApplicationSiteVtwo.Models
{
    public class Categories_Model
    {
        //After adding the controller you have to enable migrations again
        //Add-migration Addcategorytable
        //update-database
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم تصنيف الوظيفة")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "وصف تصنيف الوظيفة")]
        public string CategoryDescription { get; set; }

        //Adding the many relationship 
        public ICollection<Job_Model> Job_Model { get; set; }
    }
}