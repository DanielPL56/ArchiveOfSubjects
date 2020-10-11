using LittleDatabaseApp.Enums;
using SubjectsDAL.EF;
using SubjectsDAL.Models;
using SubjectsDAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDatabaseApp
{
    class Program
    {
        public static bool exitApp;

        public static List<Human> humans = new List<Human>();
        public static List<Android> androids = new List<Android>();

        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());

            while (!exitApp)
            {
                DisplayMenu();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine($"Choose option\n1) Add Person\n2) Show peoples in memory\n3) Add people to database\n4) Database\n5) Exit App");

            string userInput = Console.ReadLine();

            if (userInput == "5")
            {
                exitApp = true;
                return;
            }

            RecognizeUserInput(userInput);

            Console.ReadLine();
            Console.Clear();
        }

        private static void RecognizeUserInput(string userInput)
        {
            MenuOptions MenuChoosen = new MenuOptions();

            if (!int.TryParse(userInput, out int userNumberInput))
            {
                    Console.WriteLine("Can't recognize answer");
            }

            if (userNumberInput == 1 || userNumberInput == 2 || userNumberInput == 3 || userNumberInput == 4)
            {
                MenuChoosen = (MenuOptions)userNumberInput - 1;
                ChooseRightMenu(MenuChoosen);
            }
            else
            {
                Console.WriteLine("Choose the correct number");
            }
        }

        private static void ChooseRightMenu(MenuOptions menu)
        {
            switch (menu)
            {
                case MenuOptions.addHuman:
                    Console.Clear();
                    AddHumanMenu();
                    break;
                case MenuOptions.memory:
                    Console.Clear();
                    PeopleInMemoryMenu();
                    break;
                case MenuOptions.addPeopleToDatabase:
                    Console.Clear();
                    AddPeopleToDatabaseMenu();
                    break;
                case MenuOptions.database:
                    Console.Clear();
                    ShowDatabaseMenu();
                    break;
                default:
                    break;
            }
        }

        private static void AddHumanMenu()
        {
            string firstName;
            string lastName;

            Console.Write("First Name: ");
            firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            lastName = Console.ReadLine();

            try
            {
                Human person = new Human() { FirstName = firstName, LastName = lastName};
                humans.Add(person);
                Console.WriteLine(person.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PeopleInMemoryMenu()
        {
            int positionInList = 0;

            foreach (Human person in humans)
            {
                positionInList++;
                Console.WriteLine($"({positionInList}) {person.ToString()}");
            }

            if (humans.Count > 0)
            {
                Console.WriteLine("Do you want to delete someone from memory? 1) Yes 2) No");

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Choose number to delete");
                    if (!int.TryParse(Console.ReadLine(), out int positionToDelete))
                    {
                        Console.WriteLine("Invalid data");
                        return;
                    };
                    if (positionToDelete <= humans.Count && positionToDelete > 0)
                    {
                        Human personToDelete = humans.ElementAt(positionToDelete - 1);
                        humans.Remove(personToDelete);
                    }
                }
                else return;
            }
            else Console.WriteLine("No one here!");
        }

        private static void AddPeopleToDatabaseMenu()
        {
            using (HumanRepo humanRepository = new HumanRepo())
            {
                humans.ForEach(x => humanRepository.Add(x));
                humans = new List<Human>();
            }

            Console.WriteLine("Done");
        }

        private static void ShowDatabaseMenu()
        {
            Console.WriteLine("Wait....");

            try
            {
                using (HumanRepo humanRepository = new HumanRepo())
                {
                    foreach (Human human in humanRepository.GetAll())
                    {
                        Console.WriteLine(human.ToString());
                    }
                }

                Console.WriteLine("-------------------------------------------------");

                using (AndroidRepo androidRepository = new AndroidRepo())
                {
                    foreach (Android android in androidRepository.GetAll())
                    {
                        Console.WriteLine(android.ToString());
                    }
                }
                Console.WriteLine("\nThat's all");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
