using System;
using SubjectsDAL.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubjectsDAL.Repos;

namespace TestingDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());

            using (HumanRepo repository = new HumanRepo())
            {
                foreach (var human in repository.GetAll())
                {
                    Console.WriteLine(human.ToString());
                }
            }

            using (AndroidRepo androidRepository = new AndroidRepo())
            {
                foreach (var android in androidRepository.GetAll())
                {
                    Console.WriteLine(android.ToString());
                }
            }

            Console.ReadLine();
        }
    }
}
