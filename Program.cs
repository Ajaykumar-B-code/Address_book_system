using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook customer1 = new AddressBook();
            customer1.display();
            Console.ReadLine();
        }
        public class AddressBook
        {
            public string first_name;
            public string last_name;
            public string address;
            public string city;
            public string state;
            public string zip;
            public long phone_number;
            public string email;

            public void display()
            {
                Console.WriteLine("Welcome to Address Book");
            }
        }
    }
}
