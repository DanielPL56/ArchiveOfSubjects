using System;
using SubjectsDAL.EF;
using System.Data.Entity;
using SubjectsDAL.Repository;

namespace TestingDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());

            using (var humanRepository = new HumanRepository())
            {
                foreach (var human in humanRepository.GetAll())
                {
                    Console.WriteLine(human.ToString());
                }
            }

            using (var androidRepository = new AndroidRepository())
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
