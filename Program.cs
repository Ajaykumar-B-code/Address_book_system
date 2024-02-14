using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            AddressBook obj1 = new AddressBook();
            fileop file = new fileop();

            bool flag = true;
            do
            {
                Console.WriteLine("Enter the operation to perform by the user");
                Console.WriteLine("1.To add name of the AddressBook ");
                Console.WriteLine("2.To perform operation in the AddressBook");
                Console.WriteLine("3.To display name of AddressBook");
                Console.WriteLine("4 To seach by name");
                Console.WriteLine("5 To search by city");
                Console.WriteLine("6 To search by state");
                Console.WriteLine("7.To count the contacts by city");
                Console.WriteLine("8.To count the contacts by state");
                Console.WriteLine("9 to sort the contacts");
                Console.WriteLine("10.To write in the file");
                Console.WriteLine("11 To read from the file");
                Console.WriteLine("12.To write in the csv file");
                Console.WriteLine("13.To Read in the csv file");
                Console.WriteLine("14 To exit");
                int operation = Convert.ToInt16(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the username");
                        string name = Console.ReadLine();
                        user.add_user(name);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2:
                        int op;
                        Console.Clear();
                        Console.WriteLine("Enter the name of the AddressBook: ");
                        string fname = Console.ReadLine();
                        do
                        {
                            if (user.GetPersons().ContainsKey(fname))
                            {
                                AddressBook obj = user.GetAddressBook(fname);
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
                                        obj.add_contact();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        obj.display();
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        obj.edit();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        obj.remove();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("user is not there in the AddressBook");
                                op = 5;
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;

                            }

                        } while (op != 5);
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Display the name of AddressBook");
                        user.Display();
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        List<Contact> clist = new List<Contact>();
                        Console.WriteLine("Enter the name of the person");
                        string searchname = Console.ReadLine();
                        clist = user.SearchPersonsInName(searchname);
                        obj1.displaybyname(clist);
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        List<Contact> citylist = new List<Contact>();
                        Console.WriteLine("Enter the name of the city");
                        string searchcity = Console.ReadLine();
                        citylist = user.SearchPersonsInCity(searchcity);
                        obj1.displaybycityorstate(citylist);
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        List<Contact> statelist = new List<Contact>();
                        Console.WriteLine("Enter the name of the state");
                        string searchstate = Console.ReadLine();
                        statelist = user.SearchPersonsInState(searchstate);
                        obj1.displaybycityorstate(statelist);
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        List<Contact> cityCountlist = new List<Contact>();
                        Console.WriteLine("Enter the name of the city");
                        string searchcitytocount = Console.ReadLine();
                        citylist = user.SearchPersonsInState(searchcitytocount);
                        Console.WriteLine($"The number of contact in the city {searchcitytocount} is {citylist.Count}");
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        List<Contact> stateCountlist = new List<Contact>();
                        Console.WriteLine("Enter the name of the state");
                        string searchstatetocount = Console.ReadLine();
                        statelist = user.SearchPersonsInState(searchstatetocount);
                        Console.WriteLine($"The number of contact in the state {searchstatetocount} is {statelist.Count}");
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 9:
                        Console.Clear();
                        Console.WriteLine("Enter an option to sort contacts: ");
                        Console.WriteLine("1. Sort by Name\n2. Sort by City\n3. Sort by State\n4. Sort by Zip\n5. Exit");
                        int sortChoice = Convert.ToInt32(Console.ReadLine());
                        switch (sortChoice)
                        {
                            case 1:
                                Console.Clear();
                                List<Contact> sortedByName = user.SortAllContactsByName();
                                obj1.displaybycityorstate(sortedByName);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                List<Contact> sortedbyCity = user.SortAllContactsByCity();
                                obj1.displaybycityorstate(sortedbyCity);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                List<Contact> sortedbyState = user.SortAllContactsByState();
                                obj1.displaybycityorstate(sortedbyState);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                List<Contact> sortedbyZip = user.SortAllContactsByZip();
                                obj1.displaybycityorstate(sortedbyZip);
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Invalid Choice! Exit");
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;
                        }
                        break;
                    case 10:
                        Console.Clear();
                        file.SaveAddressBook(user.GetPersons());
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 11:
                        Console.Clear();
                        file.LoadAddressBook();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 12:
                        Console.Clear();
                        file.WriteCSV(user.GetPersons());
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 13:
                        Console.Clear();
                        file.ReadCSV();
                        Thread.Sleep(4000);
                        Console.Clear();
                        break;
                    case 14:
                        flag = false;
                        break;
                }
            } while (flag);
        }
        
    }
}