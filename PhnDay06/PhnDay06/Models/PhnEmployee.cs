using System;
using System.ComponentModel.DataAnnotations;

namespace PhnLab06.Models
{
    public class PhnEmployee
    {
        public int PhnId { get; set; }

        [Required]
        public string PhnName { get; set; }

        [DataType(DataType.Date)]
        public DateTime PhnBirthDay { get; set; }

        [EmailAddress]
        public string PhnEmail { get; set; }

        public string PhnPhone { get; set; }

        public decimal PhnSalary { get; set; }

        public string PhnStatus { get; set; }
    }
}