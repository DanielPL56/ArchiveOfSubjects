using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

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
            return $"{FullName} {TimeAdded}";
        }
    }
}
