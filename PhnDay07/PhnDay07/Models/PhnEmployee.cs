using Microsoft.AspNetCore.Mvc;

namespace PhnDay07.Models
{
    public class PhnEmployee
    {
        public int PhnId { get; set; }
        public string PhnName { get; set; }
        public DateTime PhnBirthDay { get; set; }
        public string PhnEmail { get; set; }
        public string PhnPhone { get; set; }
        public decimal PhnSalary { get; set; }
        public bool PhnStatus { get; set; }
    }
}
