using System;
using System.Collections.Generic;

namespace RaceCalendar
{
    public class Race
    {
        // Attributes
        string name;
        DateTime date;
        string track;
        List<Driver> drivers;
        Queue<Driver> driversWaitList;

        // Constructor
        public Race(string name, DateTime date, string track)
        {
            this.name = name;
            this.date = date;
            this.track = track;
            this.drivers = new List<Driver>();
            this.driversWaitList = new Queue<Driver>();
        }

        // Methods
        public void addDriverToRace(Driver driver)
        {
            if (drivers.Count < 5)
            {
                drivers.Add(driver);
                Console.WriteLine($"Driver {driver.Name} was successfuly added to the race.");
            }
            else
            {
                Console.WriteLine($"The grid is already full. The driver {driver.Name} will be added to the waiting list.");
                addDriverToQueue(driver);
            }
        }

        public void addDriverToQueue(Driver driver)
        {
            driversWaitList.Enqueue(driver);
        }

        public void addDriverFromTheQueue()
        {
            if (drivers.Count < 5)
            {
                addDriverToRace(driversWaitList.Dequeue());
            }
        }

        public void removeDriverFromRace(Driver driver)
        {
            drivers.Remove(driver);
            addDriverFromTheQueue();
        }

        public void printAll()
        {
            Console.WriteLine("");
            Console.WriteLine($"Name: {name}, Date: {date.ToString("yyyy-MM-dd")}, Track: {track}");
            if (drivers.Count == 0)
            {
                Console.WriteLine("No drivers were added to the race");
            }
            else
            {
                Console.WriteLine("Drivers: ");
                foreach (Driver driver in drivers)
                {
                    Console.WriteLine($"Name: {driver.Name}, Age: {driver.Age}");
                }
            }
        }
    }
}
