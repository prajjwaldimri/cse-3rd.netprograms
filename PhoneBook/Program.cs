//Q. Create a program to store and search a phonebook.

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace PhoneBook
{
    public class Program
    {
        private static List<PhoneBookEntry> _phoneBook;
        private static string _filePath = $"{Directory.GetCurrentDirectory()}/PhoneBook.json";
        public static void Main() {
            Starter();
        }

        /// <summary>
        /// Provides options to navigate the program.
        /// </summary>
        private static void Starter() {
            _phoneBook = ReadPhoneBook();
            Console.WriteLine($"Phonebook currently has {_phoneBook.Count} entries");
            WriteLine("\n Navigation \n 1: Add Entries to PhoneBook"
             + "\n 2: Search PhoneBook \n 3: Save changes to database \n 4: Exit Program",
             ConsoleColor.DarkGreen);
            var chosenOption = Console.ReadLine();
            switch(chosenOption)
            {
                case "1":
                AddToPhoneBook();
                break;
                case "2":
                SearchPhoneBook();
                break;
                case "3":
                WritePhoneBook();
                break;
                case "4":
                Environment.Exit(0);
                break;
                case "":
                WriteLine("You didn't enter any option!", ConsoleColor.Red);
                break;
                default:
                WriteLine("Wrong option chosen", ConsoleColor.Red);
                break;
            }
            Starter();
        }

        private static void AddToPhoneBook() {
            string exitLoop = "";
            while(!exitLoop.Equals("N"))
            {
                WriteLine("Enter Name:");
                var name = Console.ReadLine();
                WriteLine("Enter Phone-Number:");
                var number = Console.ReadLine();
                WriteLine("Enter Address");
                var address = Console.ReadLine();
                if(_phoneBook == null) {
                    _phoneBook = new List<PhoneBookEntry>();
                }
                _phoneBook.Add(new PhoneBookEntry {
                    Name = name,
                    PhoneNumber = number,
                    Address = address
                });
                WriteLine("Do you want to keep entering data? Y/N");
                exitLoop = Console.ReadLine().ToUpper();
            }
            WriteLine("Do you want to save the added entries to the database? Y/N");
            if(Console.ReadLine().ToUpper().Equals("Y")) {
                WritePhoneBook();
            }
            Starter();
        }

        private static void SearchPhoneBook() {
            if(_phoneBook == null || _phoneBook.Count == 0){
                Console.ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("No Data found in the phonebook. Try again!", ConsoleColor.Red);
                return;
            }
            WriteLine("Enter search term:");
            var searchTerm = Console.ReadLine();
            List<PhoneBookEntry> contacts;
            contacts = _phoneBook.FindAll(entry => entry.Name.Equals(searchTerm) 
            || entry.PhoneNumber.Equals(searchTerm)
            || entry.Address.Equals(searchTerm));

            if(contacts.Count == 0) {
                WriteLine("Nothing found!", ConsoleColor.DarkCyan);
                return;
            }

            WriteLine("\n Printing matched entries!");

            foreach (var entry in contacts) {
                WriteLine("|NAME| |PHONE NUMBER| |ADDRESS|");
                WriteLine($"|{entry.Name}| |{entry.PhoneNumber}| |{entry.Address}|", ConsoleColor.DarkCyan);
            }
            Starter();
        }

        private static List<PhoneBookEntry> ReadPhoneBook() {
            WriteLine("\nSearching for existing phonebook database...");
            if(File.Exists(_filePath)){
                WriteLine("Database found. Reading...");
                var rawPhoneBookData = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<PhoneBookEntry>>(rawPhoneBookData);
            }
            WriteLine("Database not found. It will be created automatically. Please continue;");
            return new List<PhoneBookEntry>();
        }

        private static void WritePhoneBook() {
            if(!File.Exists(_filePath)) {
                File.Create(_filePath);
            }
            try {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_phoneBook));
            WriteLine("Data saved successfully", ConsoleColor.DarkGreen);
            }
            catch(Exception e) {
                WriteLine(e.ToString(),ConsoleColor.DarkYellow);
                WriteLine("Cannot save data", ConsoleColor.DarkRed);
            }
        }

        /// <summary>
        /// A Little helper method to display text in color inside console
        /// </summary>
        /// <param name="text">Text you want to print to console</param>
        /// <param name="foregroundColor">Color of the printed text</param>
        private static void WriteLine(string text, ConsoleColor? foregroundColor = null) {
            if(foregroundColor != null) {
                Console.ForegroundColor = foregroundColor.Value;
            }
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    public class PhoneBookEntry {
        public string Name;
        public string PhoneNumber;
        public string Address;
    }
}
