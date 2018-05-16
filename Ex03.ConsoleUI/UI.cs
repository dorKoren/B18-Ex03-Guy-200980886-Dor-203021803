﻿using System;
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
            int numOfOptions = Enum.GetNames(typeof(eMainMenuOptions)).Length;                 // find out the number of options (Enum values).
            return getVehicleDetails(DisplayMenu(), numOfOptions);           // Maybe need to change the name or wrap it in another method
        }

        public static string GetVehicleType()
        {
            int numOfTypes = Enum.GetNames(typeof(eVehicleType)).Length - 1; //  len - 1           
            return getVehicleDetails(DisplayVehicleTypes(), numOfTypes);
        }

        public static string GetColorType()
        {
            int numOfTypes = Enum.GetNames(typeof(eColorType)).Length - 1; //  len - 1
            return getVehicleDetails(DisplayColorTypes(), numOfTypes);
        }

        public static string GetWheelsAirPressure()
        {
            return getVehicleDetails(DisplayWheelsAirPressure(), int.MaxValue); // <--- ?
        }

        public static string GetFuelAmount()
        {
            return getVehicleDetails(DisplayWheelsAirPressure(), int.MaxValue); // <--- ?
        }

        public static string GetRemainingBatteryLife()
        {
            return getVehicleDetails(DisplayBstteryLife(), int.MaxValue); // <--- ?
        }

        public static string GetLicenseType()
        {
            int numOfTypes = Enum.GetNames(typeof(eLicenseType)).Length - 1; //  len - 1
            return getVehicleDetails(DisplayLicenseType(), numOfTypes);
        }

        public static string GetEngineVolume()
        {
            return getVehicleDetails(DisplayEngineVolume(), int.MaxValue); // <--- ?
        }

        public static string GetNumbersOfDoors()
        {
            int numOfTypes = Enum.GetNames(typeof(eNumOfDoors)).Length - 1; //  len - 1
            return getVehicleDetails(DisplayNumbersOfDoors(), numOfTypes);
        }

        public static string GetCooled()
        {
            return getVehicleDetails(DisplayIsCooles(), int.MaxValue); // <---
        }

        public static string GetVolumeOfCargo()
        {
            return getVehicleDetails(DisplayVolumeOfCargo(), int.MaxValue); // <---
        }

        public static string GetOwnerName()
        {
            string name = "";
            getOwnerDetail(out name, DisplayOwnerName());
            return name;
        }

        public static string GetOwnerPhoneNumber()
        {
            string phoneNumber = "";
            getOwnerDetail(out phoneNumber, DisplayOwnerPhoneNumber());
            return phoneNumber;
        }

        public static string GetLicenseNumber()
        {
            string licenseNumber;
            getOwnerDetail(out licenseNumber, DisplayOwnerLicenseNumber());
            return licenseNumber;

        }

        public static string GetVehicleStatus()
        {

            throw new NotImplementedException();
        }

        public static string GetFuelType()
        {
            throw new NotImplementedException();
        }

        public static string GetAmountOfMinsToCharge()          // Guy addition 15.05
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