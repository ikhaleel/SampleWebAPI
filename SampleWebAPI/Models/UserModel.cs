using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Models
{
    public class UserModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }


    }
}