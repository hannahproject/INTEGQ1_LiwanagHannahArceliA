using System;
using System.Collections.Generic;
using BL;
using DL;

namespace UI
{
    class Program
    {
        static List <string> userOptions = new List<string>() {"A - VIEW PENDING DELIVERIES" , "B - SEARCH PARCEL ID" , "C - LOGOUT"};
        static void Main(string[] args)
        {
            Login();
        }

        static void Login()
        {
            User user1 = new User();

            Console.WriteLine("\nLogin to your account now!");
            Console.Write("USERNAME: ");
            string getUsername = Console.ReadLine();
            Console.Write("PASSWORD: ");
            string getPassword = Console.ReadLine();

            user1._username = getUsername;
            user1._password = getPassword;

            if(user1.IsUsernameAndPasswordCorrect())
            {
                Dashboard();
            }

            else
            {
                IfLoginFailed();
            }
        }

        static void IfLoginFailed()
        {
            Console.WriteLine("\nInvalid username or password. Press 'Y' to try again OR 'X' to exit.");
            char tryAgain = Convert.ToChar(Console.ReadLine());
            tryAgain = Char.ToUpper(tryAgain);

            switch(tryAgain)
            {
                case 'Y':
                    Login();
                break;

                case 'X':
                    Console.WriteLine("Program Closing...");
                    Environment.Exit(0);
                break;

                default:
                    Console.WriteLine($"Invalid input. Program closing...");
                break;
            }
        }

        static void Dashboard()
        {
            User user1 = new User();

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Welcome! What feature/s would you like to use?\n");
            foreach (var option in userOptions)
            {
                Console.WriteLine(option);   
            }
            ValidateUserChoice(GetUserChoice());
        }

        static void ValidateUserChoice(char _choice)
        {
            MyDB db = new MyDB();
            switch(_choice)
            {
                case 'A':
                    db.DisplayPendingDeliveries();
                    Dashboard();
                break;

                case 'B':
                    FindThisParcelID();
                    Dashboard();
                break;

                case 'C':
                    Logout();
                break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    Dashboard();
                break;
            }
        }

        static char GetUserChoice()
        {
            Console.Write("INPUT: ");
            char choice = Convert.ToChar(Console.ReadLine());
            choice = Char.ToUpper(choice);
            return choice;
        }

        static void FindThisParcelID()
        {
            User user1 = new User();
            Console.WriteLine("-------------------------------------------------");
            Console.Write("SEARCH PARCEL ID: ");
            string find = Console.ReadLine().ToUpper();

            Parcel parcel = new Parcel();
            parcel._find = find;

            Console.WriteLine($"\nSEARCH RESULT: ");
            if(parcel.DoesThisParcelIDExists())
            {
                Console.WriteLine($"{find} FOUND IN THE DATABASE!");
            }

            else
            {
                Console.WriteLine($"{find} NOT FOUND IN THE DATABASE!");
            }
        }

        static void Logout()
        {
            Console.WriteLine("\nLOGGING OUT...");
            Environment.Exit(0);
        }
    }
}
