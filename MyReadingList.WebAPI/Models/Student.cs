using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.WebAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int  DepartmentID { get; set; }
        public string Group  { get; set; }
        public string BookID { get; set; }

    }
}
