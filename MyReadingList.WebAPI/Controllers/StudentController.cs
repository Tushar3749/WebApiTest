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

        [HttpPost]
        [Route ("api/create/student") ]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {

            string name = student.StudentName;
            int department = student.DepartmentID;
            List <Student> s  =  dbContext.Students.ToList();

            var findStudent = s.Where(x => x.StudentName == name && x.DepartmentID == department).ToList();


            if (findStudent == null)
            {

                await dbContext.Students.AddAsync(student);
                dbContext.SaveChanges();
                return student;

            }
            else {

                return NotFound("Student already exists");

            }



            
        }


        [HttpPut]
        [Route("api/update/student/{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student updatedStudent)
        {
            var existingStudent = await dbContext.Students.FindAsync(id);

            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }

         
            existingStudent.StudentName = updatedStudent.StudentName;
            existingStudent.DepartmentID = updatedStudent.DepartmentID;
            existingStudent.Group = updatedStudent.Group;
            existingStudent.BookID = updatedStudent.BookID;

            dbContext.Students.Update(existingStudent);
            await dbContext.SaveChangesAsync();

            return Ok(existingStudent);
        }


        [HttpDelete]
        [Route("api/Delete/student/{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id, Student deleteStudent)

        {

            var existingStudent = await dbContext.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }


            dbContext.Students.Remove(existingStudent);
            await dbContext.SaveChangesAsync();
            return Ok(deleteStudent );


        }


    }
}
