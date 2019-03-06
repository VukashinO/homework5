using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeweork5
{


    class Program
    {
        static void Main(string[] args)
        {

            var users = new List<User>();

            while (true)
            {
                Console.Clear();

                string name;
                bool checkName;
                (name, checkName) = ReadNameFromConsole("enter name:");
                if (!checkName)
                {
                    Console.WriteLine("You need to enter characters!");
                    return;
                }
                string lastName;
                bool checkLastName;
                (lastName, checkLastName) = ReadLastNameFromConsole("enter last name:");
                if (!checkLastName)
                {
                    Console.WriteLine("You need to enter characters!");
                    return;
                }
                var fullName = $"{name} {lastName}".ToLower();


                int age;
                bool check;
                (age, check) = CalcAge("enter your birthday?  --with 'dot' example: 13.02.2005");
                if (!check)
                {
                    Console.WriteLine("you have eneted invalid birthday format please check the pattern and you cant enter more days than 31, moths than 12");
                    return;
                }

                users.Add(new User() { Name = fullName, Age = age });

                Console.WriteLine("enter new user Y/n");
                var inputQuit = Console.ReadLine();
                if (inputQuit == "n")
                {
                    break;
                }
            }


            // find youngest user:
            int youngest = int.MaxValue;
            string youngestUser = "";
            foreach (var user in users)
            {

                if (user.Age < youngest)
                    youngest = user.Age;
                youngestUser = user.Name;
            }

            // find largest fullname:
            int longestLength = int.MinValue;
            string longestUser = "";
            foreach (var user in users)
            {
                if (user.Name.Length > longestLength)
                {
                    longestLength = user.Name.Length;
                    longestUser = user.Name;

                }

            }
            // find shortest fullname:
            int shortestLength = int.MaxValue;
            string shortestUser = "";
            foreach (var user in users)
            {
                if (user.Name.Length < shortestLength)
                {
                    shortestLength = user.Name.Length;
                    shortestUser = user.Name;
                }

            }

            // count the users:
            var sumUsers = users.Count;

            // average length od user fullName:

            int averageLength = 0;
            foreach (var user in users)
            {
                averageLength += (user.Name.Length - 1);
            }

            Console.WriteLine($"Youngest user: {youngestUser} with {youngest} years.");
            Console.WriteLine($"User with longest name: {longestUser} with {longestLength - 1} characters.");
            Console.WriteLine($"User with shortest name: {shortestUser} with {shortestLength - 1} characters.");
            Console.WriteLine($"Total users: {sumUsers} users.");
            Console.WriteLine($"Average user Length: {averageLength / sumUsers} characters.");
        }

        static (string, bool) ReadNameFromConsole(string message = "")
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
            }
            var name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name))
            {
                return ("\x0", false);
            }
            return (name, true);
        }
        static (string, bool) ReadLastNameFromConsole(string message = "")
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
            }

            var lastName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(lastName))
            {
                return ("\x0", false);
            }
            return (lastName, true);
        }

        static (int, bool) CalcAge(string message = "")
        {
            if (!String.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
            }
            var input = Console.ReadLine().Split('.');
            var arr = new List<int>();
            foreach (var stringNum in input)
            {
                var parsed = int.TryParse(stringNum, out int result);
                if (!parsed)
                {
                    return (0, false);
                }
                arr.Add(result);
            }

            var year = arr[2];
            var month = arr[1];
            var days = arr[0];
            if(year < 1920 || month > 12 || days > 31)
            {
                return (0, false);
            }
            var today = DateTime.Now;
            var birthday = new DateTime(year, month, days);

            var age = today.Year - birthday.Year;
            if (birthday.Month > today.Month)
            {
                age -= 1;
            }
            return (age, true);
        }
    }
}
