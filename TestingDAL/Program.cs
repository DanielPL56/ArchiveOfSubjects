using System;
using SubjectsDAL.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());

            SubjectEntities context = new SubjectEntities();

            foreach (var human in context.Humans)
            {
                Console.WriteLine(human.ToString());
            }

            Console.ReadLine();
        }
    }
}
