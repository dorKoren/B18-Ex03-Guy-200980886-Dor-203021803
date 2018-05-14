using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Garage;




namespace Ex03.ConsoleUI
{
    public class UI
    {

        public static string GetVehicleType()
        {
            string choice = "";
            int result = -1;
            // Display a list of supported vehicles
            while (result < 0 || result > 5) // we should define this values as a consts!
            {
                Console.Out.WriteLine("Please select a desired type of Vehicle out of the following:");
                Console.Out.WriteLine("1.   Electric Motorcycle");
                Console.Out.WriteLine("2.   Electric Car");
                Console.Out.WriteLine("3.   Fuel Based Motorcycle");
                Console.Out.WriteLine("4.   Fuel Based Car");
                Console.Out.WriteLine("5.   Fuel Based Truck");
                choice = Console.In.ReadLine();
                int.TryParse(choice, out result);
            }

            // return user input
            return choice;
        }
    }
}
