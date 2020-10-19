using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubjectsDAL.Models
{
    public abstract class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime TimeAdded { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public Person()
        {
            TimeAdded = DateTime.Now;
        }

        public override string ToString()
        {
            return $"({GetType().Name}) {FullName} {TimeAdded}";
        }
    }
}
