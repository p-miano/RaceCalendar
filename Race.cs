using System;
using System.Collections.Generic;

namespace RaceCalendar
{
    public class Race
    {
        // Properties and fields
        public string Name { get; set; }        
        public DateTime Date { get; set; }
        public string Track { get; set; }
        public List<Driver> Drivers { get; set; }
        public Queue<Driver> DriversWaitList { get; set; }
        private const int maxDrivers = 3;

        // Constructor
        public Race(string name, DateTime date, string track)
        {
            Name = name;
            Date = date;
            Track = track;
            Drivers = new List<Driver>();
            DriversWaitList = new Queue<Driver>();
        }

        // Methods
        public void addDriverToRace(Driver driver)
        {
            if (Drivers.Count < maxDrivers)
            {
                Drivers.Add(driver);
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
            DriversWaitList.Enqueue(driver);
        }

        public void addDriverFromTheQueue()
        {
            if (DriversWaitList.Count > 0 && Drivers.Count < maxDrivers)
            {
                Driver driver = DriversWaitList.Dequeue();
                Drivers.Add(driver);
                Console.WriteLine($"Driver {driver.Name} from the waiting list has been added to the race.");
            }
        }

        public void removeDriverFromRace(Driver driver)
        {
            if (Drivers.Remove(driver))
            {
                Console.WriteLine($"Driver {driver.Name} has been removed from the race.");
                addDriverFromTheQueue();
            }
            else
            {
                Console.WriteLine("Driver not found in the race.");
            }
        }

        public void printAll()
        {
            Console.WriteLine("");
            Console.WriteLine($"Name: {Name}, Date: {Date.ToString("yyyy-MM-dd")}, Track: {Track}");
            if (Drivers.Count == 0)
            {
                Console.WriteLine("No drivers were added to the race.");
            }
            else
            {
                Console.WriteLine("Drivers in the race:");
                foreach (Driver driver in Drivers)
                {
                    Console.WriteLine($"Name: {driver.Name}, Age: {driver.Age}");
                }
            }

            if (DriversWaitList.Count > 0)
            {
                Console.WriteLine("Drivers on the waiting list:");
                foreach (Driver driver in DriversWaitList)
                {
                    Console.WriteLine($"Name: {driver.Name}, Age: {driver.Age}");
                }
            }
            else
            {
                Console.WriteLine("No drivers are on the waiting list.");
            }
        }
    }
}
