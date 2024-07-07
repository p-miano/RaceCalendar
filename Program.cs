using System;
using System.Collections.Generic;

namespace RaceCalendar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the list of all drivers
            Driver paula = new Driver("Paula", 38);
            Driver anne = new Driver("Anne", 35);
            Driver john = new Driver("John", 40);
            Driver mike = new Driver("Mike", 45);
            Driver luke = new Driver("Luke", 30);
            Driver mary = new Driver("Mary", 25);
            Driver jessica = new Driver("Jessica", 28);

            // Create race
            Race race1 = new Race("New Years", new DateTime(2024, 1, 1), "Interlagos");

            // Add drivers to race
            race1.addDriverToRace(paula);
            race1.addDriverToRace(anne);
            race1.addDriverToRace(john);
            race1.addDriverToRace(mike);
            race1.addDriverToRace(luke);
            race1.addDriverToRace(mary);
            race1.addDriverToRace(jessica);

            // Create the list of races
            List<Race> races = new List<Race>();

            // Add race to the list
            races.Add(race1);

            Race race2 = new Race("Carnaval", new DateTime(2024, 2, 25), "Interlagos");
            races.Add(race2);

            foreach (Race race in races)
            {
                race.printAll();
            }

            // Remove driver from Race
            race1.removeDriverFromRace(paula);

            foreach (Race race in races)
            {
                race.printAll();
            }

            Console.ReadKey();
        }
    }
}
