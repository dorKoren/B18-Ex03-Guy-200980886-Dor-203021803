using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Enums;
using static Ex03.GarageLogic.VehicleMaker;

namespace Ex03.ConsoleUI
{
    public class Engine
    {
        private Garage m_Garage;

        /*  Constructor  */
        public Engine()
        {
            this.m_Garage = new Garage();
        }

        /* Properties */
        public Garage Garage
        {
            get { return this.m_Garage; }
            set { this.m_Garage = value; }
        }

        /* Public Methods */
        public static void Run()
        {

            Console.WriteLine(DisplayMenu());

        }
















        /* Private Methods */
        private static string DisplayMenu()
        {
            return string.Format(
@"
 _______________________________________________________________
| Please choose from the following operations:                  |
|---------------------------------------------------------------|
| 1. Insert a Vehicle into the garage.                          |
| 2. Display a list of license numbers currently in the garage. |
| 3. Change a certain vehicle’s status.                         |
| 4. Inflate tires to maximum.                                  |
| 5. Refuel vehicle.                                            |
| 6. Charge vehicle.                                            |
| 7. Display vehicle information.                               |
|_______________________________________________________________| ");
        }

        private static string DisplayLisenceNumbersMenu()
        {
            return string.Format(
@"
 _______________________________________________________________
| Please select a ststus to filter the list by:                 |
|---------------------------------------------------------------|
| 1. None (display all)                                         |
| 2. Waiting                                                    |
| 3. In repair                                                  |
| 4. Repaired                                                   |
| 5. Payed                                                      |
|_______________________________________________________________| ");
        }

        /// <summary>
        /// This method deals with insertion of a Vehicle into the garage.
        /// 
        /// </summary>
        private void insertVehicleToGarage()
        {

        }

        /// <summary>
        /// This method creates a new vehicle by the user demands (communication via UI)
        /// 
        /// </summary>
        /// <returns></returns>
        private Vehicle creatNewVehicle()
        {
            return null;
        }

        /// <summary>
        /// This method deals with the display of the license-numbers list, by status (Waiting, InRepair etc).
        /// </summary>
        private void displayLicenseNumberByStatus()
        {
            string userChoice = "";

            while (userChoice == "")
            {
                DisplayLisenceNumbersMenu();                        // I think it should display it in the UI.GetVehicleStatus()
                userChoice = UI.GetVehicleStatus();
            }

            eVehicleStatus status = parseVehicleStatus(userChoice);
            Garage.DisplayLicenseNumbersList(status);
        }

        /// <summary>
        /// This method deals with changing a certain vehicle’s status.
        /// </summary>
        private void changeVehicleStatus()
        {
            string licenseNumber = "";
            string newStatus = "";

            if (licenseNumber == "" || newStatus == "")
            {
                while (licenseNumber == "") { licenseNumber = UI.GetLicenseNumber(); }
                while (newStatus == "") { newStatus = UI.GetVehicleStatus(); }
            }

            if (Garage.VehicleList.TryGetValue(licenseNumber, out Vehicle vehicle))
            {
                eVehicleStatus status = parseVehicleStatus(newStatus);
            }
            else
            {
                // throw new VehicleIsNotInGarage();
            }
        }


        /// <summary>
        /// This method deals with inflating a certain vehicle’s wheels to max PSI.
        /// </summary>
        private void inflateAllWheelsToMax()
        {
            string licenseNumber = "";
            while (licenseNumber == "")
            {
                licenseNumber = UI.GetLicenseNumber();
            }

            if (Garage.VehicleList.TryGetValue(licenseNumber, out Vehicle vehicle))
            {
                if (vehicle.hasAnyWheels())
                {
                    float maxPSI = vehicle.Wheels[0].MaxAirPressure;
                    vehicle.InflateAllWheels(maxPSI);
                }
            }
            else
            {
                // throw new VehicleIsNotInGarage();
            }
        }

        /// <summary>
        /// This method deals with refuling a certain Vehicle.
        /// </summary>
        private void refuleVehicle()
        {
            string licenseNumber = "";
            string fuelType = "";
            string amountOfFuel = "";
            eFuelType fuel = eFuelType.Unknown;
            float amount = -1F;

            if (licenseNumber == "" || fuelType == "" || amountOfFuel == "")
            {
                while (licenseNumber == "") { licenseNumber = UI.GetLicenseNumber(); }
                while (fuelType == "") { fuelType = UI.GetFuelType(); }
                while (amountOfFuel == "")
                {
                    amount = UI.GetFuelAmount();
                    amountOfFuel = amount.ToString(); 
                }
            }

            if (Garage.VehicleList.TryGetValue(licenseNumber, out Vehicle vehicle))
            {
                if (vehicle is FuelBasedVehicle)
                {
                    FuelBasedVehicle fuelVehicle = (FuelBasedVehicle)vehicle;
                    fuel = parseFuelType(fuelType);
                    fuelVehicle.Refuel(amount, fuel);
                }
            }
            else
            {
                // throw new VehicleIsNotInGarage();
            }

        }

        /// <summary>
        /// This method deals with recharging a certain Vehicle.
        /// </summary>
        private void rechargeVehicle()
        {
            string licenseNumber = "";
            string amountOfMins = "";
            float amount = -1F;

            if (licenseNumber == "" || amountOfMins == "")
            {
                while (licenseNumber == "") { licenseNumber = UI.GetLicenseNumber(); }
                while (amountOfMins == "")
                {
                    amountOfMins = UI.GetAmountOfMinsToCharge();
                }
            }

            if (Garage.VehicleList.TryGetValue(licenseNumber, out Vehicle vehicle))
            {
                if (vehicle is ElectricBasedVehicle)
                {
                    ElectricBasedVehicle electricVehicle = (ElectricBasedVehicle)vehicle;
                    if(float.TryParse(amountOfMins, out amount))
                    {
                        electricVehicle.Charge(amount);
                    }
                }
            }
            else
            {
                // throw new VehicleIsNotInGarage();
            }
        }

        private void displayVehicleDetails()
        {

        }

        /// <summary>
        /// This method parses the Vehicle status from string to eVehicleStatus
        /// </summary>
        /// <param name="i_NewStatus"></param>
        /// <returns></returns>
        private eVehicleStatus parseVehicleStatus(string i_NewStatus)             // Guy addition 15.05
        {
            eVehicleStatus status = eVehicleStatus.None;

            foreach (eVehicleStatus current in Enum.GetValues(typeof(eVehicleStatus)))
            {
                if(Enum.GetName(typeof(eVehicleStatus), current).Equals(i_NewStatus))
                {
                    status = current;
                    break;
                }
            }

            return status;
        }

        private eFuelType parseFuelType(string i_FuelType)
        {
            eFuelType fuel = eFuelType.Unknown;

            foreach (eFuelType current in Enum.GetValues(typeof(eFuelType)))
            {
                if (Enum.GetName(typeof(eFuelType), current).Equals(fuel))
                {
                    fuel = current;
                    break;
                }
            }

            return fuel;
        }
    }
}
