using System;
using System.Collections.Generic;
using System.Globalization;

namespace RaceCalendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Race> races = new List<Race>();
            Console.WriteLine("Welcome to the Racing Calendar System!");

            bool addMoreRaces = true;
            while (addMoreRaces)
            {
                // Gather information for a new race
                Console.Write("Name of the race: ");
                string raceName = Console.ReadLine();

                Console.Write("Date of the race (example: 2024-01-26): ");
                DateTime raceDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);

                Console.Write("Track name: ");
                string trackName = Console.ReadLine();

                Race race = new Race(raceName, raceDate, trackName);
                races.Add(race);

                // Adding drivers to the race
                Console.WriteLine("Enter drivers for this race:");
                while (true)
                {
                    Console.Write("Enter driver's name and age (name, age) or type 'done' to finish): ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "done") break;

                    string[] parts = input.Split(',');
                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Invalid format. Please use 'Name, Age'.");
                        continue;
                    }

                    string driverName = parts[0].Trim();
                    int driverAge;
                    if (!int.TryParse(parts[1].Trim(), out driverAge))
                    {
                        Console.WriteLine("Invalid age. Please enter a valid number.");
                        continue;
                    }

                    Driver driver = new Driver(driverName, driverAge);
                    race.addDriverToRace(driver);
                }

                // Ask if the user wants to add another race
                Console.WriteLine("Do you want to add another race? (y/n)");
                string response = Console.ReadLine();
                if (response.ToLower() != "y")
                {
                    addMoreRaces = false;
                }
            }

            // Display all races and their drivers
            foreach (Race race in races)
            {
                race.printAll();
            }

            // Option to continuously remove drivers and manage waiting list
            bool removeMoreDrivers = true;
            while (removeMoreDrivers && races.Count > 0)
            {
                Console.WriteLine("Would you like to remove any drivers from a race? (y/n)");
                string removeResponse = Console.ReadLine();
                if (removeResponse.ToLower() != "y")
                {
                    break;
                }

                Console.WriteLine("Enter the name of the race from which to remove a driver:");
                string raceName = Console.ReadLine();
                Race selectedRace = races.Find(r => r.Name.Equals(raceName, StringComparison.OrdinalIgnoreCase));

                if (selectedRace != null)
                {
                    Console.WriteLine("Enter the name of the driver to remove:");
                    string driverName = Console.ReadLine();
                    Driver driverToRemove = selectedRace.Drivers.Find(d => d.Name.Equals(driverName, StringComparison.OrdinalIgnoreCase));
                    if (driverToRemove != null)
                    {
                        selectedRace.removeDriverFromRace(driverToRemove);
                        selectedRace.printAll();
                    }
                    else
                    {
                        Console.WriteLine("Driver not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Race not found.");
                }
            }

            // Display all races and their drivers
            foreach (Race race in races)
            {
                race.printAll();
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
