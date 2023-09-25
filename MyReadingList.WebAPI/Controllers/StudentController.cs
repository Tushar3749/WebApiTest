using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyReadingList.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyReadingList.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyReadingApiContext dbContext;
        public StudentController(MyReadingApiContext context)
        {
            dbContext = context;
        }
        [HttpGet]
        [Route("api/get/student/list/by/ID")]
        public IEnumerable<Student> GetStudentListbyID(int id)
        {
            var studentsWithMatchingId = dbContext.Students.Where(x => x.Id == id);
            return studentsWithMatchingId.ToList();
        }
        [HttpGet]
        [Route("api/get/all/studentss")]
        public IEnumerable<Student> GetAllStudents()
        {
            return dbContext.Students.ToList();
        }
    }
}
