using Ex03.GarageLogic;
using System;
using static Ex03.GarageLogic.Enums;
using static Ex03.GarageLogic.VehicleMaker;
using static Ex03.ConsoleUI.Menues;
using static Ex03.ConsoleUI.UI;
using static Ex03.ConsoleUI.Menues.MainMenu;
using System.Linq;
using static Ex03.GarageLogic.Garage;

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
                menuOption = GetMainMenuOption();  
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
        /// “Insert” a new vehicle into the garage. The user will be asked to 
        /// select a vehicle type out of the supported vehicle types, and to
        /// input the license number of the vehicle.If the vehicle is already 
        /// in the garage(based on license number) the system will display an
        /// appropriate message and will use the vehicle in the garage
        /// (and will change the vehicle status to “In Repair”), if not, a new
        /// object of that vehicle type will be created and the user will be
        /// prompted to input the values for the properties of his vehicle, 
        /// according to the type of vehicle he wishes to add.
        /// </summary>
        private void insertVehicleToGarage()
        {
            string licenseNumber = GetLicenseNumber();
            string ownerName;
            string ownerPhone;

            if (Garage.VehicleIsAlreadyInTheGarage(licenseNumber))
            {
                Console.WriteLine(string.Format(DisplayVehicleIsAlreadyInTheGarage(licenseNumber)));
                Garage.LicenseNumbersList.TryGetValue(licenseNumber, out VehicleDetails value);
                value.VehicleStatus = eVehicleStatus.InRepair;
            }
            else
            {
                ownerName = GetOwnerName();
                ownerPhone = GetOwnerPhoneNumber();
                eVehicleType vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), GetVehicleType());
                VehicleMaker.MakeNewVehicle(vehicleType, out Vehicle vehicle);
                setVehicle(vehicle, licenseNumber);
                Garage.Insert(vehicle, licenseNumber, ownerName, ownerPhone);
            }
        }

        private void setVehicle(Vehicle i_Vehicle, string i_LicenseNumber)  
        {
            i_Vehicle.LicenseNumber = i_LicenseNumber;
            i_Vehicle.ModelName = GetModelName();
            i_Vehicle.RemainingEnergyPercentage = float.Parse(GetRemainingEnergyPercentage());

            if (i_Vehicle.RemainingEnergyPercentage < 0 || i_Vehicle.RemainingEnergyPercentage > 100)
            {
                throw new ValueOutOfRangeException("Invalid percentace value!", 100, 0);
            }

            setVehicleDetails(i_Vehicle);                
        }

        private void setVehicleDetails(Vehicle i_Vehicle)
        {
            switch (i_Vehicle.Type)
            {
                case (eVehicleType.ElectricBasedCar):
                    setElectricCar(i_Vehicle);
                    break;

                case (eVehicleType.ElectricBasedMotorcycle):
                    setElectricMotorcycle(i_Vehicle);
                    break;

                case (eVehicleType.FuelBasedCar):
                    setFuelCar(i_Vehicle);
                    break;

                case (eVehicleType.FuelBasedMotorcycle):
                    setFuelMotorcycle(i_Vehicle);
                    break;

                case (eVehicleType.FuelBasedTruck):
                    setFuelTruck(i_Vehicle);
                    break;

                default:
                    break;
            }
        }

        private void setElectricBasedVehicle(ElectricBasedVehicle i_ElectricVehicle)
        {
            i_ElectricVehicle.CurrentBatteryLife = float.Parse(GetCurrentBatteryLife());

            if (i_ElectricVehicle.CurrentBatteryLife < 0 || 
                i_ElectricVehicle.CurrentBatteryLife > i_ElectricVehicle.MaxBatteryLife)
            {
                throw new ValueOutOfRangeException(
                    "Invalid value!", i_ElectricVehicle.MaxBatteryLife, 0);
            }
        }

        private void setFuelBasedVehicle(FuelBasedVehicle i_FuelVehicle)
        {
            eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), GetFuelType());

            if (i_FuelVehicle.FuelType != fuelType)
            {
                throw new ArgumentException("Invalid fuel type");
            }

            i_FuelVehicle.CurrentAmountOfFuel = float.Parse(GetCurrentAmountOfFuel());

            if (i_FuelVehicle.CurrentAmountOfFuel < 0 || 
                i_FuelVehicle.CurrentAmountOfFuel > i_FuelVehicle.MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(
                    "Invalid fuel amount!", i_FuelVehicle.MaxAmountOfFuel, 0);

            }
        }
        private void setCar(ICar i_Car)
        {
            i_Car.Color = (eColorType)Enum.Parse(typeof(eColorType), GetColorType());
            i_Car.NumOfDoors = (eNumOfDoors)Enum.Parse(typeof(eNumOfDoors), GetNumbersOfDoors());
        }

        private void setTruck(ITruck i_Truck)
        {
            i_Truck.IsCooled = GetCooled().Equals("1");
            i_Truck.VolumeOfCargo = float.Parse(GetVolumeOfCargo());

            if (i_Truck.VolumeOfCargo < 0)
            {
                throw new ValueOutOfRangeException("Invalid volume of cargo", float.MaxValue, 0); // ???
            }
        }

        private void setMotorcycle(IMotorcycle i_Motorcycle)
        {
            i_Motorcycle.LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), GetLicenseType());
            i_Motorcycle.EngineVolume = int.Parse(GetEngineVolume());

            if (i_Motorcycle.EngineVolume < 0)
            {
                throw new ValueOutOfRangeException("Invalid engine volume", float.MaxValue, 0);
            }
        }

        private void setElectricCar(Vehicle i_Vehicle)
        {
            ElectricBasedCar car = i_Vehicle as ElectricBasedCar;
            setCar(car);
            setElectricBasedVehicle(car);
        }

        private void setElectricMotorcycle(Vehicle i_Vehicle)
        {
            ElectricBasedMotorcycle motorcycle = i_Vehicle as ElectricBasedMotorcycle;
            setMotorcycle(motorcycle);
            setElectricBasedVehicle(motorcycle);
        }

        private void setFuelCar(Vehicle i_Vehicle)
        {
            FuelBasedCar car = i_Vehicle as FuelBasedCar;
            setCar(car);
            setFuelBasedVehicle(car);
        }

        private void setFuelMotorcycle(Vehicle i_Vehicle) 
        {
            FuelBasedMotorcycle motorcycle = i_Vehicle as FuelBasedMotorcycle;
            setMotorcycle(motorcycle);
            setFuelBasedVehicle(motorcycle);
        }

        private void setFuelTruck(Vehicle i_Vehicle)
        {
            FuelBasedTruck truck = i_Vehicle as FuelBasedTruck;
            setTruck(truck);
            setFuelBasedVehicle(truck);
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
                userChoice = GetVehicleStatus();
            }

            eVehicleStatus status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), userChoice);  // bug potential
            Console.WriteLine(Garage.DisplayLicenseNumbersList(status));
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
                Garage.LicenseNumbersList.TryGetValue(licenseNumber, out VehicleDetails ownerDetails);
                ownerDetails.VehicleStatus = status;
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
                while (fuelType == "") { fuelType = GetFuelType(); }
                while (amountOfFuel == "")
                {
                    amountOfFuel = UI.GetFuelAmount();    // dortal bag
                    amount = float.Parse(amountOfFuel);
                }
            }

            if (Garage.VehicleList.TryGetValue(licenseNumber, out Vehicle vehicle))
            {
                if (vehicle is FuelBasedVehicle fuelVehicle)
                {
                    fuelVehicle = (FuelBasedVehicle)vehicle;
                     fuel = (eFuelType)Enum.Parse(typeof(eFuelType), fuelType);         // Guy fix 17.05
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
                 if (vehicle is ElectricBasedVehicle electricVehicle)
                {
                    electricVehicle = (ElectricBasedVehicle)vehicle;
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
        private eVehicleStatus parseVehicleStatus(string i_NewStatus)          
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
        
    }
}