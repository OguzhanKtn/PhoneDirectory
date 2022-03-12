using System;
using System.Collections.Generic;
using System.Linq;
namespace TelephoneDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, long> phoneDirectory = new Dictionary<string, long>()
            {
                {"OGUZHAN KOTAN",987654321},
                {"NURAN KOTAN",23456789},
                {"ERCAN KOTAN",0123456},
                {"MEHMET KOTAN",456123789},
                {"ALI ESEN KOTAN",532222645},
            };

            MainMenu();

            void MainMenu()
            {
                Console.WriteLine("Please select the action you want to do :");
                Console.WriteLine("****************************************");
                Console.WriteLine("(1) Save New Number ");
                Console.WriteLine("(2) Remove Existing Number");
                Console.WriteLine("(3) Update Existing Number");
                Console.WriteLine("(4) List Directory");
                Console.WriteLine("(5) Search in Directory");

                int actionNumber = int.Parse(Console.ReadLine());
                switch (actionNumber)
                {
                    case 1:
                        SavePhoneNumber();
                        break;
                    case 2:
                        RemovePhoneNumber();
                        break;
                    case 3:
                        UpdatePhoneNumber();
                        break;
                    case 4:
                        ListDirectory();
                        break;
                    case 5:
                        SearchDirectory();
                        break;

                }
            }
            void SavePhoneNumber()
            {
                Console.Write("Please enter a name and surname :");
                String nameAndSurname = Console.ReadLine();

                Console.Write("Please enter a phone number :");
                long phoneNumber = long.Parse(Console.ReadLine());

                phoneDirectory.Add(nameAndSurname, phoneNumber);
                Console.WriteLine("The person has saved. You're redirected to main menu..");
                MainMenu();
            }
            void RemovePhoneNumber()
            {
                Console.WriteLine("Please enter the name and surname of person you want to remove :");
                String input = Console.ReadLine();

                if (phoneDirectory.ContainsKey(input))
                {
                    Console.WriteLine("{0} is about to be removed from directory, do you confirm ?(y/n)", input);
                    String operation = Console.ReadLine();
                    if (operation == "y")
                    {
                        phoneDirectory.Remove(input);
                    }
                    else
                    {
                        Console.WriteLine("Operation has terminated.You're redirected to main menu..");
                        MainMenu();
                    }

                }
                else
                {
                    Console.WriteLine("The person's name you entered couldn't found in directory. Please select an action :");
                    Console.WriteLine("* For cancel the removing action : (1)");
                    Console.WriteLine("* For try again : (2)");
                    int n = int.Parse(Console.ReadLine());
                    if (n == 1)
                    {
                        MainMenu();
                    }
                    else
                    {
                        RemovePhoneNumber();
                    }
                }

            }
            void UpdatePhoneNumber()
            {
                Console.WriteLine("Please enter the name and surname of person you want to update :");
                String input = Console.ReadLine().ToUpper();

                if (phoneDirectory.ContainsKey(input))
                {
                    Console.WriteLine("Please enter a new number :");
                    long newNumber = long.Parse(Console.ReadLine());
                    phoneDirectory[input] = newNumber;
                    Console.WriteLine("The number has updated.");
                    foreach (var item in phoneDirectory)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("You're redirected to main menu..");
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("The person's name you entered couldn't found in directory. Please select an action :");
                    Console.WriteLine("* For terminate the action : (1)");
                    Console.WriteLine("* For try again : (2)");
                }
                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Console.WriteLine("Operation has terminated.You're redirected to main menu..");
                    MainMenu();
                }
                else if (n == 2)
                {
                    UpdatePhoneNumber();
                }
            }
            void ListDirectory()
            {
                Console.WriteLine("Phone Directory");
                Console.WriteLine("**********************");
                Console.WriteLine("For list the directory as A-Z : (1)");
                Console.WriteLine("For list the directory as Z-A : (2)");
                int n = int.Parse(Console.ReadLine());

                if (n == 1)
                {
                    var list = phoneDirectory.OrderByDescending(i => i.Key);
                    var newList = list.Reverse();
                    foreach (var item in newList)
                    {
                        Console.WriteLine("Name and surname : " + item.Key);
                        Console.WriteLine("Phone Number : " + item.Value);
                        Console.WriteLine("---------------------------");
                    }
                }
                else if (n == 2)
                {
                    var list2 = phoneDirectory.OrderByDescending(i => i.Key);
                    foreach (var item in list2)
                    {
                        Console.WriteLine("Name and surname : " + item.Key);
                        Console.WriteLine("Phone Number : " + item.Value);
                        Console.WriteLine("---------------------------");
                    }
                }
                MainMenu();
            }
            void SearchDirectory()
            {
                Console.WriteLine("Select the action you want to do :");
                Console.WriteLine("**********************************");
                Console.WriteLine("For search by name and surname : (1)");
                Console.WriteLine("For search by phone number : (2)");

                int n = int.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Console.WriteLine("Enter the name and surname :");
                    String input = Console.ReadLine();
                    if (phoneDirectory.ContainsKey(input))
                    {
                        int index = 0;
                        foreach (var item in phoneDirectory)
                        {
                            if (item.Key == input)
                            {
                                Console.WriteLine("Your search results : ");
                                Console.WriteLine("*************************");
                                Console.WriteLine("Name and surname : " + item.Key);
                                Console.WriteLine("Phone number : " + item.Value);
                            }
                            index++;
                        }
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("The person you searched is not in the directory.");
                        SearchDirectory();
                    }
                    MainMenu();
                }
                else if (n == 2)
                {
                    Console.WriteLine("Enter the phone number :");
                    long phoneNumber = long.Parse(Console.ReadLine());
                    if (phoneDirectory.ContainsValue(phoneNumber))
                    {
                        int index = 0;
                        foreach (var item in phoneDirectory)
                        {
                            if (item.Value == phoneNumber)
                            {
                                Console.WriteLine("Your search results : ");
                                Console.WriteLine("*************************");
                                Console.WriteLine("Name and surname : " + item.Key);
                                Console.WriteLine("Phone number : " + item.Value);
                            }
                            index++;
                        }
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("The number you searched is not in the directory.");
                        SearchDirectory();
                    }
                    MainMenu();
                }
            }

        }
    }
}