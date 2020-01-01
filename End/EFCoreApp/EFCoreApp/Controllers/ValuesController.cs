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
    }
}