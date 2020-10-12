using SubjectsDAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectsDAL.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<SubjectEntities>
    {
        protected override void Seed(SubjectEntities context)
        {
            List<Human> humans = new List<Human>()
            {
                new Human() { FirstName = "Marian", LastName = "Pazdzioch" },
                new Human() { FirstName = "Ferdek", LastName = "Kiepski" }
            };

            humans.ForEach(x => context.Humans.Add(x));

            List<Android> androids = new List<Android>()
            {
                new Android() { FirstName = "Robo", LastName = "Cop" }
            };

            context.Androids.AddRange(androids);

            context.SaveChanges();
        }
    }
}
