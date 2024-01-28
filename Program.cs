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
            string first_name, last_name, address, city, state, zip, email;
            long phone_number;
            Console.WriteLine("Enter the details to add in Address Book");
            Console.Write("first name: ");
            first_name = Console.ReadLine();
            Console.Write("lastname: ");
            last_name = Console.ReadLine();
            Console.Write("address: ");
            address = Console.ReadLine();
            Console.Write("city: ");
            city = Console.ReadLine();
            Console.Write("state: ");
            state = Console.ReadLine();
            Console.Write("zip: ");
            zip = Console.ReadLine();
            Console.Write("email: ");
            email = Console.ReadLine();
            Console.Write("Phone number: ");
            phone_number = Convert.ToInt64(Console.ReadLine());
            AddressBook contact1 = new AddressBook(first_name, last_name, address, city, state, zip, phone_number, email);
            contact1.display();
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

            public AddressBook(string first_name, string last_name, string address, string city, string state, string zip, long phone_number, string email)
            {
                this.first_name = first_name;
                this.last_name = last_name;
                this.address = address;
                this.city = city;
                this.state = state;
                this.zip = zip;
                this.phone_number = phone_number;
                this.email = email;
            }
            public void display()
            {
                Console.WriteLine("Welcome to Address Book");
            }
        }
    }
}

