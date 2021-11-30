using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}