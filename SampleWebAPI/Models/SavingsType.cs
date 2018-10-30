using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Models
{
    public class SavingsType
    {
        [Required]
        public int ID { get; set; }
        [StringLength(200)]
        public string Savings_Type { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

    }

    public class SavingsDetails
    {
        [Required]
        public int ID { get; set; }


        public decimal Amount { get; set; }
        
        public int Savings_Type { get; set; }

        [ForeignKey("Savings_Type")]
        public virtual SavingsType SavingsType { get; set; }

        public DateTime Transaction_Date { get; set; }

        public DateTime CreatedDate { get; set; }
        
    }


}