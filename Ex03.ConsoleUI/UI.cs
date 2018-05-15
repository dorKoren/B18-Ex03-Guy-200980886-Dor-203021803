using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Garage;


namespace Ex03.ConsoleUI
{
    public class UI
    {
        /* Const Members */
        public const int k_TypeVehicleMinIndex = 0;
        public const int k_TypeVehicleMaxIndex = 5;
        public const int k_ColorVehicleMinIndex = 0;
        public const int k_ColorVehicleMaxIndex = 4;

        /* Public Methods */
        public static string GetVehicleType() // Try catch ???  
        {
            string choice = "";
            int result = -1;

            // Display a list of supported vehicles
            while (result < k_TypeVehicleMinIndex || result > k_TypeVehicleMaxIndex) 
            {
                Console.Out.WriteLine(string.Format(
@"Please select a desired type of Vehicle out of the following:
1.   Electric Motorcycle
2.   Electric Car
3.   Fuel Based Motorcycle
4.   Fuel Based Car
5.   Fuel Based Truck"));

                choice = Console.In.ReadLine();
                int.TryParse(choice, out result);
            }

            // return user input
            return choice;
        }


        public static string GetColorType()
        {

            string choice = "";
            int result = -1;

            // Display a list of supported vehicles
            while (result < k_ColorVehicleMinIndex || result > k_ColorVehicleMaxIndex)
            {
                Console.Out.WriteLine(string.Format(
@"Please select a desired color of Vehicle out of the following:
1.   Gray
2.   Blue
3.   White
4.   Black"));

                choice = Console.In.ReadLine();
                int.TryParse(choice, out result);
            }

            // return user input
            return choice;
        }

        public static string GetWheelsAirPressure()
        {
            return "";
        }

        public static float GetFuelAmount()       // <-- float.TryParse
        {
            return 0;
        }

        public static float GetRemainingBatteryLife() // <-- float.TryParse
        {
            return 0;
        }

        public static string GetLicenseType()
        {
            return "";
        }

        public static int GetEngineVolume()    // <-- int.TryParse  for  motorcycle
        {
            return 0;
        }

        public static int GetNumbersOfDoors()  // <-- int.TryParse
        {
            return 0;
        }

        public static bool IsCooled()
        {
            return true;
        }

        public static float GetVolumeOfCargo()  // <-- float.TryParse  for trunk...
        {
            return 0;
        }

        public static string GetOwnerName()
        {
            return "";
        }

        public static string GetOwnerPhoneNumber()
        {
            return "";
        }

        public static string GetLicenseNumber()
        {
            return "";
        }

        public static string GetVehicleStatus()                 // Guy addition 15.05
        {
            throw new NotImplementedException();
        }

        public static string GetFuelType()                      // Guy addition 15.05
        {
            throw new NotImplementedException();
        }

        public static string GetAmountOfMinsToCharge()          // Guy addition 15.05
        {
            throw new NotImplementedException();
        }
    }
}
