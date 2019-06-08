using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobApplicationSiteVtwo.Models
{
    public class Job_Model
    {
        //After adding the controller you have to enable migrations again
        //Add-migration Addcategorytable
        //update-database
        public int Id { get; set; }

        [Display(Name = "اسم الوظيفة")]
        public string JobTitle { get; set; }

     
        [Display(Name = "وصف الوظيفة")]
        public string JobContent { get; set; }

        [Display(Name = "صورة الوظيفة")]
        public string JobImage { get; set; }

        //Creating foreign key
        [Display(Name = "تصنيف الوظيفة")]
        public int Categories_Model_Id { get; set; }
        public Categories_Model Categories_Model { get; set; }
    }
}