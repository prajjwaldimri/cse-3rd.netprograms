//Q. Create a program to store and search a phonebook.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PhoneBook
{
    public class Program
    {
        /* TODO: Make the dictionary data persistent.
        Also the Dictionary is not a very good data structure for a phonebook as it
        should always have unique keys.
        Can create a new structure with two string values to solve this problem.         
        */
        private static Dictionary<string,string> _phoneBook;
        public static void Main()
        {
            _phoneBook = new Dictionary<string,string>();
            Starter();            
        }

        /// <summary>
        /// Provides options to navigate the program.
        /// </summary>
        private static void Starter()
        {
            Console.WriteLine("\n Navigation \n 1: Add Entries to PhoneBook"
             + "\n 2: Search PhoneBook \n 3: Exit Program");
            var chosenOption = Console.ReadLine();
            switch(chosenOption)
            {
                case "1":
                AddToDictionary();
                break;
                case "2":
                SearchDictionary();
                break;
                case "3":
                Environment.Exit(0);
                break;
                case "":
                Console.WriteLine("You didn't enter any option!");
                break;
                default:
                Console.WriteLine("Wrong option chosen");
                break;
            }
            Starter();
        }

        /// <summary>
        /// Takes input from user and adds to {_phoneBook}
        /// </summary>
        private static void AddToDictionary()
        {
            string exitLoop = "";
            while(!exitLoop.Equals("N"))
            {
                Debug.WriteLine("Data Entry Loop Entered");
                Console.WriteLine("Enter Name:");
                var name = Console.ReadLine();
                Console.WriteLine("Enter Phone-Number:");
                var number = Console.ReadLine();
                _phoneBook.Add(name,number);
                Console.WriteLine("Do you want to keep entering data? Y/N");
                exitLoop = Console.ReadLine().ToUpper();
            }
            Debug.WriteLine("Data Entry Loop Exited");
            Starter();
        }

        /// <summary>
        /// Searches _phoneBook
        /// </summary>
        private static void SearchDictionary()
        {
            if(_phoneBook.Count == 0){
                Console.WriteLine("No Data found in the phonebook. Please try again!");
                return;
            }
            Console.WriteLine("Enter search term:");
            var searchTerm = Console.ReadLine();
            if(_phoneBook.ContainsKey(searchTerm)){
                Console.WriteLine($"\n The phone number for {searchTerm} is: \t " 
                + _phoneBook[searchTerm]);
            }
            else{
                Console.WriteLine($"{searchTerm} not found in the PhoneBook");
            }
            Starter();
        }        
    }
}