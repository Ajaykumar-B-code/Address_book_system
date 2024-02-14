using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;  
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{

    public class fileop
    {
        public void SaveAddressBook(Dictionary<string, AddressBook> addressBooks)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\91767\Desktop\workspace\day_10\Address_book_system\AddressBookSystem\AddressBookSystem\csvcontact.xlsx"))
                {
                    foreach (var entry in addressBooks)
                    {
                        writer.WriteLine($"Address Book for: {entry.Key}");
                        foreach (var contact in entry.Value.all())
                        {
                            writer.WriteLine($"First Name: {contact.Fname}");
                            writer.WriteLine($"Last Name: {contact.lastname}");
                            writer.WriteLine($"Address: {contact.Addres}");
                            writer.WriteLine($"City: {contact.City}");
                            writer.WriteLine($"State: {contact.State}");
                            writer.WriteLine($"Phone: {contact.PhoneNumber}");
                            writer.WriteLine($"Email: {contact.Email}");
                            writer.WriteLine($"Zipcode: {contact.ZipCode}");
                            writer.WriteLine();
                        }
                        writer.WriteLine();
                    }
                }
                Console.WriteLine("Address book data has been saved to sucessfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while saving address book data: {ex.Message}");
            }
        }
        public Dictionary<string, AddressBook> LoadAddressBook()
        {
            Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();
            try
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\91767\Desktop\workspace\day_10\Address_book_system\AddressBookSystem\AddressBookSystem\csvcontact.xlsx"))
                {
                    string line;
                    string currentName = "";
                    AddressBook currentAddressBook = null;

                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] data = line.Split(',');
                        if (data.Length >= 8)
                        {
                            Contact contact = new Contact
                            {
                                Fname = data[0],
                                lastname = data[1],
                                Addres = data[2],
                                City = data[3],
                                State = data[4],
                                ZipCode = data[5],
                                PhoneNumber = Convert.ToInt32(data[6]),
                                Email = data[7]
                            };
                        }
                        Console.WriteLine(line);
                    }
                    if (currentAddressBook != null)
                    {
                        addressBooks.Add(currentName, currentAddressBook);
                    }
                }
                Console.WriteLine("Address book data has been loaded from 'contacts.txt'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while loading address book data: {ex.Message}");
            }
            return addressBooks;
        }
        public void WriteCSV(Dictionary<string, AddressBook> addressBooks)
        {
            string file1 = "sheets.csv";
           // var SampleTextFileLocation = @"C:\Users\91767\Desktop\workspace\day_10\Address_book_system\AddressBookSystem\AddressBookSystem\csvcontact.xlsx";
            using (StreamWriter file = new StreamWriter(file1))
            {
                foreach (var UserNames in addressBooks)
                {
                    // FirstLine
                    string username = UserNames.Key;
                    file.WriteLine($"UserName, {username}:");
                    foreach (var dataEntry in UserNames.Value.all())
                    {
                        file.Write($"{dataEntry.Fname}{dataEntry.lastname},{dataEntry.Addres},{dataEntry.City},{dataEntry.State},{dataEntry.ZipCode},{dataEntry.PhoneNumber},{dataEntry.Email}");
                        file.WriteLine();
                    }
                    file.WriteLine();
                }
                file.Close();
            }
        }
        public void ReadCSV()
        {
            //var Sampletxt = @"C:\Users\91767\Desktop\workspace\day_10\Address_book_system\AddressBookSystem\AddressBookSystem\csvcontact.xlsx";
            string file2 = "sheets.csv";
            StreamReader FileReader = new StreamReader(file2);
            string line = "";
            while (line != null)
            {
                line = FileReader.ReadLine();
                if (line != null)
                    Console.WriteLine(line);
            }
            FileReader.Close();
            Console.ReadLine();
        }
    }
}
