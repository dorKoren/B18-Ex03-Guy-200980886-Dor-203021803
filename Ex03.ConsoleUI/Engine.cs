using Ex03.GarageLogic;
using System;
using static Ex03.GarageLogic.Enums;
using static Ex03.ConsoleUI.Menus;
using static Ex03.ConsoleUI.UI;
using static Ex03.ConsoleUI.Menus.MainMenu;
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
            float amountInMins = -1;
            bool hasCharged = false;

            while (!hasCharged)
            {
                while (amountInMins <= 0 || amountInMins > i_ElectricVehicle.MaxBatteryLife * 60)
                {
                    amountInMins = float.Parse(GetCurrentBatteryLife());
                }

                hasCharged = i_ElectricVehicle.Charge(amountInMins);
            }

            setWheelsAirPressure(i_ElectricVehicle);            // init wheels to desired PSI
        }

        private void setFuelBasedVehicle(FuelBasedVehicle i_FuelVehicle)
        {
            float amount = -1;
            bool hasBeenRefueled = false;

            while (!hasBeenRefueled)
            {
                while (amount <= 0 || amount > i_FuelVehicle.MaxAmountOfFuel)
                {
                    amount = float.Parse(GetCurrentAmountOfFuel());
                }

                hasBeenRefueled = i_FuelVehicle.Refuel(amount, i_FuelVehicle.FuelType);
            }

            setWheelsAirPressure(i_FuelVehicle);
        }

        private void setCar(ICar i_Car)
        {
            i_Car.Color = (eColorType)Enum.Parse(typeof(eColorType), GetColorType());
            i_Car.NumOfDoors = (eNumOfDoors)Enum.Parse(typeof(eNumOfDoors), GetNumbersOfDoors());
        }

        private void setTruck(ITruck i_Truck)
        {
            i_Truck.IsCooled = GetCooled().Equals("1");
            float volumeOfCargo = -1;

            while (volumeOfCargo <= 0)
            {
                volumeOfCargo = float.Parse(GetVolumeOfCargo());
            }

            i_Truck.VolumeOfCargo = volumeOfCargo;
        }

        private void setMotorcycle(IMotorcycle i_Motorcycle)
        {
            i_Motorcycle.LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), GetLicenseType());
            int engineVolume = -1;

            while (engineVolume <= 0)
            {
                engineVolume = int.Parse(GetEngineVolume());
            }

            i_Motorcycle.EngineVolume = engineVolume;
        }

        private void setWheelsAirPressure(Vehicle i_Vehicle)
        {
            float newPSI = 0;

            if (i_Vehicle.hasAnyWheels())
            {
                float maxPSI = i_Vehicle.Wheels[0].MaxAirPressure;

                while (newPSI <= 0 || newPSI > maxPSI)
                {
                    newPSI = float.Parse(GetWheelsAirPressure());
                }

                i_Vehicle.SetWheelsAirPressure(newPSI);
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

            eVehicleStatus status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), userChoice);  
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
        }

        /// <summary>
        /// This method deals with inflating a certain 
        /// vehicle’s wheels to max PSI.
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
                     fuel = (eFuelType)Enum.Parse(typeof(eFuelType), fuelType);        
                    try
                    {
                        fuelVehicle.Refuel(amount, fuel);
                    }
                    catch
                    {
                        Console.WriteLine("Wrong type of fuel for " + (Enum.GetName(typeof(eFuelType), fuelVehicle.Type)) + "\n"
                                            + "Did not refuel vehicle " + fuelVehicle.LicenseNumber);
                    }             
                }
                else
                {
                    Console.WriteLine("Can not recharge a " + vehicle.Type);
                }
            }
            else
            {
                Console.WriteLine("Vehicle number " + vehicle.LicenseNumber + " isn't found in this Garage");
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
                while (licenseNumber == "") { licenseNumber = GetLicenseNumber(); }
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
                        try
                        {
                            electricVehicle.Charge(amount);
                        }
                        catch
                        {
                             Console.WriteLine("Amount of charging minutes exceeds battery capacity \n"
                                            + "Did not refuel vehicle " + electricVehicle.LicenseNumber);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Can not recharge a " + vehicle.Type);
                }
            }
            else
            {
                Console.WriteLine("Vehicle number " + vehicle.LicenseNumber + " isn't found in this Garage");
            }
        }

        private void displayVehicleDetails()
        {
            Console.WriteLine(Garage.DisplayVehicleInformation(GetLicenseNumber()));
        }       
    }
}