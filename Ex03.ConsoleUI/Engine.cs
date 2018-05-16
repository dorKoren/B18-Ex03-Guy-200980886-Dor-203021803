using Ex03.GarageLogic;
using System;
using static Ex03.GarageLogic.Enums;
using static Ex03.GarageLogic.VehicleMaker;
using static Ex03.ConsoleUI.Menues;
using static Ex03.ConsoleUI.UI;
using static Ex03.ConsoleUI.Menues.MainMenu;
using System.Linq;

namespace Ex03.ConsoleUI
{
    public class Engine
    {

        /* Regular Members */
        private Garage m_Garage;

        /*  Constructor  */
        public Engine()
        {
            this.m_Garage = new Garage();
        }

        /* Properties */
        public Garage Garage
        {
            get { return m_Garage; }
            set { m_Garage = value; }  // <-- for what we need set??
        }

        /* Public Methods */
        public void Run()
        {
            string menuOption = GetMainMenuOption();
            int exit = (int)MainMenu.eMainMenuOptions.Exit;
            // While the user donesn't want to exit from the app
            while (int.Parse(menuOption) != exit)
            {
                navigateTo(menuOption);
                menuOption = GetMainMenuOption();  // bag potential?..
            }
        }

        /* Private Methods */
        private void navigateTo(string i_ChoiceIndex)
        {
            eMainMenuOptions choice = (eMainMenuOptions)Enum.Parse(typeof(eMainMenuOptions), i_ChoiceIndex);
            switch (choice)
            {
                case (eMainMenuOptions.InsertVehicle):
                    insertVehicleToGarage();
                    break;
                case (eMainMenuOptions.DisplayListOfLicenseNumbers):
                    displayLicenseNumberByStatus();
                    break;
                case (eMainMenuOptions.ChangeVehicleStatus):
                    changeVehicleStatus();
                    break;
                case (eMainMenuOptions.InflateTiresToMaximum):
                    inflateAllWheelsToMax();
                    break;
                case (eMainMenuOptions.RefuelVehicle):
                    refuleVehicle();
                    break;
                case (eMainMenuOptions.ChargeVehicle):
                    rechargeVehicle();
                    break;
                case (eMainMenuOptions.DisplayVehicleInformation):
                    displayVehicleDetails();
                    break;
                default:
                    // None or Exit
                    break;
            }
        }


        /// <summary>
        /// This method deals with insertion of a Vehicle into the garage.
        /// 
        /// </summary>
        private void insertVehicleToGarage()
        {
            // “Insert” a new vehicle into the garage. The user will be asked to 
            // select a vehicle type out of the supported vehicle types, and to 
            // input the license number of the vehicle. If the vehicle is already 
            // in the garage (based on license number) the system will display an
            // appropriate message and will use the vehicle in the garage 
            // (and will change the vehicle status to “In Repair”), if not, a new
            // object of that vehicle type will be created and the user will be 
            // prompted to input the values for the properties of his vehicle, 
            // according to the type of vehicle he wishes to add.

            string licenseNumber = GetLicenseNumber();
            string ownerName;
            string ownerPhone;

            if (Garage.VehicleIsAlreadyInTheGarage(licenseNumber))
            {
                Console.WriteLine(string.Format(DisplayVehicleIsAlreadyInTheGarage(licenseNumber)));  //   <----- If the license plate was found we need to change its status into "Waiting"
            }
            else
            {
                ownerName = GetOwnerName();
                ownerPhone = GetOwnerPhoneNumber();
                eVehicleType vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), GetVehicleType());
                Vehicle vehicle;
               VehicleMaker.MakeNewVehicle(vehicleType, out vehicle);

                setVehicleDetails(vehicle);

                Garage.Insert(vehicle, licenseNumber, ownerName, ownerPhone);
            }
        }


        private void setVehicleDetails(Vehicle i_Vehicle)  // maybe by ref ???
        {
            switch (i_Vehicle.Type)
            {
                case (eVehicleType.ElectricBasedCar):
                    setElectricBasedCar(i_Vehicle);
                    break;

                case (eVehicleType.ElectricBasedMotorcycle):
                    setElectricBasedMotorcycle(i_Vehicle);
                    break;

                case (eVehicleType.FuelBasedCar):
                    setFuelBasedCar(i_Vehicle);
                    break;

                case (eVehicleType.FuelBasedMotorcycle):
                    setFuelBasedMotorcycle(i_Vehicle);
                    break;

                case (eVehicleType.FuelBasedTruck):
                    setFuelBasedTruck(i_Vehicle);
                    break;

                default:
                    break;
            }
        }

        private void setElectricBasedCar(Vehicle i_Vehicle)
        {

        }

        private void setElectricBasedMotorcycle(Vehicle i_Vehicle)
        {

        }

        private void setFuelBasedCar(Vehicle i_Vehicle)
        {

        }

        private void setFuelBasedMotorcycle(Vehicle i_Vehicle)
        {

        }

        private void setFuelBasedTruck(Vehicle i_Vehicle)
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
        /// This method deals with the display of the license-numbers list
        /// , by status (Waiting, InRepair etc).
        /// </summary>
        private void displayLicenseNumberByStatus()
        {
            string userChoice = "";

            while (userChoice == "")
            {
                userChoice = UI.GetVehicleStatus();
            }

            eVehicleStatus status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), userChoice);  // bug potential
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
                eVehicleStatus status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), newStatus);
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
                licenseNumber = GetLicenseNumber();
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
                // throw new VehicleIsNotInGarageException();
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
                    //amount = UI.GetFuelAmount();    // dortal bag
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
                    if (float.TryParse(amountOfMins, out amount))
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
                if (Enum.GetName(typeof(eVehicleStatus), current).Equals(i_NewStatus))
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