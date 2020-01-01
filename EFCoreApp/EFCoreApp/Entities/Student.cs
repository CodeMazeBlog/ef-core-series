using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreApp.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
    }
}
