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
            AddressBook obj = new AddressBook();
            obj.display();
            Console.ReadLine();
        }
    }

    class AddressBook
    {
        public void display()
        {
            Console.WriteLine("Welcome to Address Book");
        }
    }
}
