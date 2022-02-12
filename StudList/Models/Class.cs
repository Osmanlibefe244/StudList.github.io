using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudList.Models;

namespace StudList.Models
{
    public class StudentViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
      
    }
}