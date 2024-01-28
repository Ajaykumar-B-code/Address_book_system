using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first_name, last_name, address, city, state, zip, email;
            long phone_number;
            int op;
            AddressBook obj= new AddressBook();
            List<AddressBook> contact =new List<AddressBook>();
            do
            {
                Console.WriteLine("Enter the operation to perform");
                Console.WriteLine("1.To Add the contact in Address_Book");
                Console.WriteLine("2.To Display the contact in Address Book");
                Console.WriteLine("3.TO Edit the contact in Address Book");
                Console.WriteLine("4.TO remove the contact in Address Book");
                Console.WriteLine("5.TO Exit from the Address Book");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
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
                        AddressBook obj1= new AddressBook();
                        obj1.add(first_name, last_name, address, city, state, zip, phone_number, email);
                        contact.Add(obj1);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        obj.display(contact);
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the email of the contact to edit:");
                        string emailToEdit= Console.ReadLine();
                        obj.edit(contact,emailToEdit);
                        Thread.Sleep(2000);
                        Console.Clear() ;
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter the email of the contact to edit:");
                        string emailToRemove = Console.ReadLine();
                        obj.remove(contact,emailToRemove);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            } while (op != 5);
        }
        public class AddressBook
        {
            private string first_name;
            private string last_name;
            private string address;
            private string city;
            private string state;
            private string zip;
            private long phone_number;
            private string email;

            public void add(string first_name, string last_name, string address, string city, string state, string zip, long phone_number, string email)
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
            public void display(List<AddressBook> contact)
            {
                foreach(var con in contact)
                {
                   
                    Console.WriteLine($"FirstName: {con.first_name}");
                    Console.WriteLine($"lastname: {con.last_name}");
                    Console.WriteLine($"address: {con.address}");                
                    Console.WriteLine($"city: {con.city}");                   
                    Console.WriteLine($"state: {con.state}"); 
                    Console.WriteLine($"zip: {con.zip}");
                    Console.WriteLine($"email: {con.email}");
                    Console.WriteLine($"Phone number: {con.phone_number}");
                    Console.WriteLine("----------------------------------------");

                }
            }
            public void edit(List<AddressBook> contact,string email) {
                string field = "",new_value="";
                int num = 0;
                int flag = 0;
                foreach(var con in contact)
                {
                    if (con.email == email)
                    {
                        flag = 1;
                        Console.WriteLine("Enter the field name you want to edit");
                        field=Console.ReadLine();
                        Console.Write($"Enter the new value of the {field}:");
                        if (field == "number")
                        {
                            num=Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            new_value = Console.ReadLine();   
                        }
                        switch(field)
                        {
                            case "firstname":
                                con.first_name = new_value;
                            break;
                            case "lastname":
                                con.last_name = new_value;
                            break;
                            case "address":
                                con.address = new_value;
                            break;
                            case "city":
                                con.city = new_value;
                            break;
                            case "state":
                                con.state = new_value;
                            break;
                            case "zip":
                                con.zip = new_value;
                            break;
                            case "phone Number":
                                con.phone_number = num;
                            break;
                            case "email":
                                con.email = new_value;
                            break;                   }
                    }
                 
                }
                if(flag == 0)
                {
                    Console.WriteLine("Contact is not present in the AddressBook");
                   
                }
              
            }
            public void remove(List<AddressBook> contact,string email) {
                int flag = 0;
                foreach(AddressBook con in contact)
                { if (con.email == email)
                    {
                        flag = 1;
                        contact.Remove(con);
                        Console.WriteLine("The Contact is removed");
                        break;
                    }

                 }
                if(flag == 0)
                {
                    Console.WriteLine("Contact is not there in the addressBook");
                }
                
            }
        }
    }
}

