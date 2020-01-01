using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ValuesController(ApplicationContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Get()
        {
            //var students = _context.Students
            //    .AsNoTracking()
            //    .Where(s => s.Age > 25)
            //    .ToList();

            //var students = _context.Students
            //    .Include(e => e.Evaluations)
            //    .FirstOrDefault();

            //var students = _context.Students
            //    .Include(e => e.Evaluations)
            //    .Include(ss => ss.StudentSubjects)
            //    .ThenInclude(s => s.Subject)
            //    .FirstOrDefault();

            //var student = _context.Students.FirstOrDefault();
            //_context.Entry(student)
            //    .Collection(e => e.Evaluations)
            //    .Load();

            //_context.Entry(student)
            //    .Collection(ss => ss.StudentSubjects)
            //    .Load();

            //foreach (var studentSubject in student.StudentSubjects)
            //{
            //    _context.Entry(studentSubject)
            //        .Reference(s => s.Subject)
            //        .Load();
            //}

            //var student = _context.Students.FirstOrDefault();

            //var evaluationsCount = _context.Entry(student)
            //    .Collection(e => e.Evaluations)
            //    .Query()
            //    .Count();

            //var gradesPerStudent = _context.Entry(student)
            //    .Collection(e => e.Evaluations)
            //    .Query()
            //    .Select(e => e.Grade)
            //    .ToList();

            //var student = _context.Students
            //    .Select(s => new 
            //    {
            //        s.Name, 
            //        s.Age, 
            //        NumberOfEvaluations = s.Evaluations.Count 
            //    })
            //    .ToList();

            //var student = _context.Students
            //    .Where(s => s.Name.Equals("John Doe"))
            //    .Select(s => new
            //    {
            //        s.Name,
            //        s.Age,
            //        Explanations = string.Join(",", s.Evaluations
            //            .Select(e => e.AdditionalExplanation))
            //    })
            //    .FirstOrDefault();

            //var student = _context.Students
            //    .FromSqlRaw("SELECT * FROM Student WHERE Name = 'John Doe'")
            //    .Include(e => e.Evaluations)
            //    .FirstOrDefault();

            //var student = _context.Students
            //    .FromSqlRaw("EXECUTE dbo.MyCustomProcedure")
            //    .ToList();

            var studentForUpdate = _context.Students
                 .FirstOrDefault(s => s.Name.Equals("Mike Miles"));
            var age = 28;

            var rowsAffected = _context.Database
                .ExecuteSqlRaw(@"UPDATE Student 
                                  SET Age = {0} 
                                  WHERE Name = {1}", age, studentForUpdate.Name);

            _context.Entry(studentForUpdate).Reload();

            return Ok(new { RowsAffected = rowsAffected});
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] Student student)
        //{
        //    if (student == null)
        //        return BadRequest();

        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var stateBeforeAdd = _context.Entry(student).State;

        //    _context.Add(student);

        //    var stateAfterAdd = _context.Entry(student).State;

        //    _context.SaveChanges();

        //    var stateAfterSaveChanges = _context.Entry(student).State;

        //    return Created("URI of the created entity", student);
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            //validation code goes here

            student.StudentDetails = new StudentDetails
            {
                Address = "Added Address",
                AdditionalInformation = "Additional information added"
            };

            _context.Add(student);
            _context.SaveChanges();

            return Created("URI of the created entity", student);
        }

        [HttpPost("postrange")]
        public IActionResult PostRange([FromBody] IEnumerable<Student> students)
        {
            //additional checks

            _context.AddRange(students);
            _context.SaveChanges();

            return Created("URI is going here", students);
        }

        [HttpPut("{id}")]
        public IActionResult PUT(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));

            dbStudent.Age = student.Age;
            dbStudent.Name = student.Name;
            dbStudent.IsRegularStudent = student.IsRegularStudent;

            var isAgeModified = _context.Entry(dbStudent).Property("Age").IsModified;
            var isNameModified = _context.Entry(dbStudent).Property("Name").IsModified;
            var isIsRegularStudentModified = _context.Entry(dbStudent).Property("IsRegularStudent").IsModified;

            _context.SaveChanges();

            return NoContent();
        }

        //[HttpPut("{id}/relationship")]
        //public IActionResult UpdateRelationhip(Guid id, [FromBody] Student student)
        //{
        //    var dbStudent = _context.Students
        //        .Include(s => s.StudentDetails)
        //        .FirstOrDefault(s => s.Id.Equals(id));

        //    dbStudent.Age = student.Age;
        //    dbStudent.Name = student.Name;
        //    dbStudent.IsRegularStudent = student.IsRegularStudent;
        //    dbStudent.StudentDetails.AdditionalInformation = "Additional information updated";

        //    _context.SaveChanges();

        //    return NoContent();
        //}

        [HttpPut("{id}/relationship")]
        public IActionResult UpdateRelationhip(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));

            dbStudent.StudentDetails = new StudentDetails
            {
                Id = new Guid("e2a3c45d-d19a-4603-b983-7f63e2b86f14"),
                Address = "added address",
                AdditionalInformation = "Additional information for student 2"
            };

            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("disconnected")]
        public IActionResult UpdateDisconnected([FromBody] Student student)
        {
            _context.Update(student);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id.Equals(id));

            if (student == null)
                return BadRequest();

            //student.Deleted = true;
            _context.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}/relationship")]
        public IActionResult DeleteRelationships(Guid id)
        {
            var student = _context.Students
                .Include(s => s.StudentDetails)
                .FirstOrDefault(s => s.Id.Equals(id));

            if (student == null)
                return BadRequest();

            _context.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }
    }
}