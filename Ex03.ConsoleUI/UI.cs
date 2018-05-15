using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Garage;
using static Ex03.ConsoleUI.Menues;


namespace Ex03.ConsoleUI
{
    public class UI
    {
        /* Const Members */

        public const int k_TypeVehicleMinIndex = 1;
        public const int k_TypeVehicleMaxIndex = 5;
        public const int k_ColorVehicleMinIndex = 1;
        public const int k_ColorVehicleMaxIndex = 4;
        public const int k_MinAirPressure = 0;      
        public const int k_MaxAirPressure = 32;     
        public const int k_MinFuelAmount = 0;       
        public const int k_MaxFuelAmount = 115;     
        public const int k_MinBatteryLife = 0;      
        public const int k_MaxBatteryLife = 100;    
        public const int k_TypeLicenseMinIndex = 1;
        public const int k_TypeLicenseMaxIndex = 4;
        public const int k_MinEngineVolume = 0;
        public const int k_MaxEngineVolume = 5000;  // <--- ?!?!?!?!
        public const int k_MinNumOfDoors = 1;
        public const int k_MaxNumOfDoors = 4;
        public const int k_MinIndexIsCooled = 1;
        public const int k_MaxIndexIsCooled = 2;
        public const int k_MinVolumeOfCargo = 0;
        public const int k_MaxVolumeOfCargo = 8000;  // <--- ?!?!?!?

        /* Public Methods */

        public static string GetVehicleType()   
        {
            return getVehicleDetails(
                k_TypeVehicleMinIndex,
                k_TypeVehicleMaxIndex,
                DisplayVehicleTypes());
        }

        public static string GetColorType()
        {
            return getVehicleDetails(
                k_ColorVehicleMinIndex,
                k_ColorVehicleMaxIndex,
                DisplayColorTypes());
        }

        public static string GetWheelsAirPressure()
        {
            return getVehicleDetails(
                k_MinAirPressure, 
                k_MaxAirPressure, 
                DisplayWheelsAirPressure());        
        }

        public static string GetFuelAmount()       
        {
            return getVehicleDetails(
                k_MinFuelAmount,
                k_MaxFuelAmount,
                DisplayWheelsAirPressure());
        }

        public static string GetRemainingBatteryLife()
        {
            return getVehicleDetails(
                k_MinBatteryLife,
                k_MaxBatteryLife,
                DisplayBstteryLife());
        }

        public static string GetLicenseType()
        {
            return getVehicleDetails(
                k_TypeLicenseMinIndex,
                k_TypeLicenseMaxIndex,
                DisplayLicenseType());
        }

        public static string GetEngineVolume()    
        {
            return getVehicleDetails(
                k_MinEngineVolume,
                k_MaxEngineVolume,
                DisplayEngineVolume());
        }

        public static string GetNumbersOfDoors()  
        {
            return getVehicleDetails(
                k_MinNumOfDoors,
                k_MaxNumOfDoors,
                DisplayNumbersOfDoors());
        }

        public static string GetCooled()  // <--- name ?
        {
            return getVehicleDetails(
                k_MinIndexIsCooled,
                k_MaxIndexIsCooled,
                DisplayIsCooles());
        }

        public static string GetVolumeOfCargo()  
        {
            return getVehicleDetails(
                k_MinVolumeOfCargo, 
                k_MaxVolumeOfCargo, 
                DisplayVolumeOfCargo());
        }

        public static string GetOwnerName()
        {
            string name = "";
            getOwnerDetail(name, DisplayOwnerName());
            return name;
        }

        public static string GetOwnerPhoneNumber()
        {
            string phoneNumber = "";
            getOwnerDetail(phoneNumber, DisplayOwnerPhoneNumber());
            return phoneNumber;
        }

        public static string GetLicenseNumber()
        {
            string licenseNumber = "";
            getOwnerDetail(licenseNumber, DisplayOwnerLicenseNumber());
            return licenseNumber;
        }

        /* Private Methods */

        private static string getVehicleDetails(int i_MinValue, int i_MaxVal, string i_AppMessage)
        {
            string userAnswer = "";
            int result = -1;

            try
            {
                while (result < i_MinValue || result > i_MaxVal)
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

        private static string getOwnerDetail(string i_Detail, string i_AppMessage)
        {
            try
            {
                while (i_Detail.Equals(""))
                {
                    Console.WriteLine(i_AppMessage);
                    i_Detail = Console.In.ReadLine();
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Catching FormatException");
                Console.WriteLine(ex.Message);

                // throw ex; //?????????????????????????
            }

            return i_Detail;
        }
    }
}
