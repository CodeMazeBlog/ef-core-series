using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class StudentDetails
    {
        [Column("StudentDetailsId")]
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string AdditionalInformation { get; set; }

        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
