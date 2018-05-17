using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Garage;
using static Ex03.GarageLogic.Enums;
using static Ex03.ConsoleUI.Menues;
using static Ex03.ConsoleUI.Menues.MainMenu;


namespace Ex03.ConsoleUI
{
    public class UI
    {

        /* Public Methods */

        public static string GetMainMenuOption()
        {
            int numOfOptions = Enum.GetNames(typeof(eMainMenuOptions)).Length;               
            return getVehicleDetails(DisplayMenu(), numOfOptions);           // May be need to change the name or wrap it in another method
        }

        public static string GetVehicleType()
        {
            int numOfTypes = Enum.GetNames(typeof(eVehicleType)).Length - 1;        
            return getVehicleDetails(DisplayVehicleTypes(), numOfTypes);
        }

        public static string GetColorType()
        {
            int numOfTypes = Enum.GetNames(typeof(eColorType)).Length - 1; 
            return getVehicleDetails(DisplayColorTypes(), numOfTypes);
        }

        public static string GetWheelsAirPressure()
        {
            return getVehicleDetails(DisplayWheelsAirPressure(), int.MaxValue); 
        }

        public static string GetFuelAmount()
        {
            return getVehicleDetails(DisplayFuelAmount(), int.MaxValue); 
        }

        public static string GetRemainingBatteryLife()
        {
            return getVehicleDetails(DisplayBstteryLife(), int.MaxValue); 
        }

        public static string GetLicenseType()
        {
            int numOfTypes = Enum.GetNames(typeof(eLicenseType)).Length - 1; 
            return getVehicleDetails(DisplayLicenseType(), numOfTypes);
        }

        public static string GetEngineVolume()
        {
            return getVehicleDetails(DisplayEngineVolume(), int.MaxValue); 
        }

        public static string GetNumbersOfDoors()
        {
            int numOfTypes = Enum.GetNames(typeof(eNumOfDoors)).Length - 1; 
            return getVehicleDetails(DisplayNumbersOfDoors(), numOfTypes);
        }

         public static string GetFuelType()
        {
            int numOfTypes = Enum.GetNames(typeof(eFuelType)).Length - 1; 
            return getVehicleDetails(DisplayFuelTypes(), numOfTypes);   
        }

        public static string GetVehicleStatus()
        {
            int numOfTypes = Enum.GetNames(typeof(eVehicleStatus)).Length - 1;
            return getVehicleDetails(DisplayVehicleStatus(), numOfTypes);
        }

        public static string GetCooled()
        {
            return getVehicleDetails(DisplayIsCooles(), int.MaxValue); 
        }

        public static string GetVolumeOfCargo()
        {
            return getVehicleDetails(DisplayVolumeOfCargo(), int.MaxValue); 
        }

        public static string GetOwnerName()
        {
            getOwnerDetail(out string name, DisplayOwnerName());
            return name;
        }

        public static string GetOwnerPhoneNumber()
        {
            getOwnerDetail(out string phoneNumber, DisplayOwnerPhoneNumber());
            return phoneNumber;
        }

        public static string GetLicenseNumber()
        {
            getOwnerDetail(out string licenseNumber, DisplayOwnerLicenseNumber());
            return licenseNumber;
        }

        public static string GetModelName()
        {
            getOwnerDetail(out string modelName, DisplayModelName());
            return modelName;
        }

         public static string GetCurrentBatteryLife()
        {
            return getVehicleDetails(DisplayCurrentBatteryLife(), int.MaxValue); ;
        }

        public static string GetCurrentAmountOfFuel()
        {
            return getVehicleDetails(DisplaycurrentAmountOfFuel(), int.MaxValue); ;

        }
        public static string GetAmountOfMinsToCharge()         
        {
            throw new NotImplementedException();
        }

        /* Private Methods */

        private static string getVehicleDetails(string i_AppMessage, int i_MaxValue)
        {
            string userAnswer = "";
            int result = -1;

            try
            {
                while (result <= 0 || result > i_MaxValue)
                {
                    Console.WriteLine(i_AppMessage);
                    userAnswer = Console.In.ReadLine();
                    if (!int.TryParse(userAnswer, out result))
                    {
                        result = -1;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Catching FormatException");
                Console.WriteLine(ex.Message);
            }

            return userAnswer;
        }

        private static string getOwnerDetail(out string o_Detail, string i_AppMessage)
        {
            o_Detail = "";

            try
            {
                while (o_Detail.Equals(""))
                {
                    Console.WriteLine(i_AppMessage);
                    o_Detail = Console.In.ReadLine();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Catching FormatException");
                Console.WriteLine(ex.Message);
            }

            return o_Detail;
        }     
    }
}