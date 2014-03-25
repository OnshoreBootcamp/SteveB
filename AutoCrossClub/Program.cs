using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCrossClub
{
    class Program
    {
       public static List<Members> members = new List<Members>();
        static void Main(string[] args)
        {
            bool isRunning = true;
            string reply = "";
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n\n" + "Autocross Club of South West Georgia" + "\n\n");
                reply = Prompt(
                 "Press '0' Check if Already Registered:\n\n" +
                 "Press '1' Member Information:\n\n" +
 //                               A ) Add member
 //                               B ) Delete member
 //                               C ) Update member
 //                               D ) Display by Last Name
                 "Press '2' Event Registration Information:\n\n" +
                       //            A ) Collect Registration Information from database
                       //            B ) Assign drivers Car Numbers
                       //            C ) Get information on Classes driver is running
                       //            D ) Calculate run times and work scedules.
                       //
                 "Press '3' Display All Members:\n\n" +
                 "Press '4' Display All Drivers for season:\n\n" +
                 "Press '5' Display Drivers for current event:\n\n" +
                 "Press '6' Display ALL Classes for season:\n\n" +
                 "Press '7' Display Classes for current event:\n\n" +
                 "Press '8' Display Race Classes and Work Times for current event:\n\n" +
                 "Press '9' Display Statistics for current event:\n\n" +
                 "Press '10' Display Statistics for season:\n\n" +
                 "Press '11' to Quit");

                switch (reply)
                {
                    case "0":
                        CheckForMembership();
                        break;
                    case "1":
                        RegisterMembers();
                        break;
                    case "2":
                        RegisterForThisEventDrivers();
                        break;
                    case "3":
                        ListAllMembers();
                        break;
                    case "4":
                        ListAllDriversThisSeason();
                        break;
                    case "5":
                        ListDriversForThisEvent();
                        break;
                    case "6":
                        ListAllClassesForSeason();
                        break;
                    case "7":
                        ListClassesForThisEvent();
                        break;
                    case "8":
                        ListRunTimeAndWorkSceduleForEvent();
                        break;
                    case "9":
                        isRunning = false;
                        break;
                }
            }

        }
        static string Prompt(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        static void CheckForMembership()
        {
            Console.Clear();
            Console.WriteLine("\n\n Here's where I check for registration information. \n Press 'Enter' to continue.");
            Console.ReadLine();
        }
        static void RegisterMembers()
        {
            Console.Clear();
            List<Members> members = new List<Members>();
            Members member = new Members();
            member.id = members.Count;
            member.lastName = Prompt("Last Mame:");
            member.firstName = Prompt("First Name:");
            member.street = Prompt("Street 1:");
            member.city = Prompt("City:");
            member.state = Prompt("State:");
            member.zipCode = Prompt("Zipcode:");
            member.email = Prompt("Email:");
            member.phone = Prompt("Home Phone:");
        }

        static void RegisterForThisEventDrivers()
        {
            Console.Clear();
            Console.WriteLine("\n\n Here's where I enter the event driver information. \n Press 'Enter' to continue.");
            Console.ReadLine();
        }
        static void ListAllMembers()
        {

            foreach (Members member in Members)
            {
                DisplayMembers(members);
            }

           // Console.WriteLine("\n\n Here's were I create a method to 'List' all the club members \n Press 'Enter to continue.");
           // Console.ReadLine();
        }
        static void ListAllDriversThisSeason()
        {
            Console.Clear();
            Console.WriteLine("\n\n Here's were I create a method to 'List' all the ' Drivers this season.' \n Press 'Enter to continue.");
            Console.ReadLine();
        }
        static void ListDriversForThisEvent()
        {
            Console.Clear();
            Console.WriteLine("\n\n Here's were I create a method to 'List' all the 'Event Drivers.' \n Press 'Enter to continue.");
            Console.ReadLine();
        }
        static void ListAllClassesForSeason()
        {
            Console.Clear();
            Console.WriteLine("\n\n Here's were I create a method to 'List' all the registered classes for the current event. \n Press 'Enter to continue.");
            Console.ReadLine();
        }
        static void ListClassesForThisEvent()
        {
            Console.Clear();
            Console.WriteLine("\n\n Here is where I create a method to 'List' the classes running in this event");
            Console.ReadLine();
        }
        static void ListRunTimeAndWorkSceduleForEvent()
        {
            Console.Clear();
            Console.WriteLine("\n\n Here is where I create a method to 'Update' the 'Run' and 'Work' schedule");
            Console.ReadLine();
        }
       private void DisplayMembers(Members membersList)
             {
                Console.WriteLine(
                " \nMember ID: " +(membersList.id).ToString() +
                "\n Last Name: " + membersList.lastName +
                "\n First Name: " + membersList.firstName +
                "\n Street 1: " + membersList.street +
                "\n City: " + membersList.city+
                "\n State: " + membersList.state +
                "\n Zip Code: " + membersList.zip +
                "\n Home Phone: " + membersList.phone +
             }
        }
    }


