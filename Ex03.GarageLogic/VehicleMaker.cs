using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.ElectricBasedVehicle;
using static Ex03.GarageLogic.FuelBasedVehicle;
using static Ex03.GarageLogic.Vehicle;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public static class VehicleMaker
    {

        /* Public Methods */
        public static Vehicle MakeNewVehicle(eVehicleType i_VehicleType)
        {
            Vehicle newVehicle = null;   // Bag Potential ! we need to think about corect exception!

            switch (i_VehicleType)
            {
                case (eVehicleType.ElectricBasedMotorcycle):
                    newVehicle = new ElectricBasedMotorcycle();
                    break;

                case (eVehicleType.ElectricBasedCar):
                    newVehicle = new ElectricBasedCar();
                    break;

                case (eVehicleType.FuelBasedMotorcycle):
                    newVehicle = new FuelBasedMotorcycle();
                    break;

                case (eVehicleType.FuelBasedCar):
                    newVehicle = new FuelBasedCar();
                    break;
               
                case (eVehicleType.FuelBasedTruck):
                    newVehicle = new FuelBasedTruck();
                    break;

                default:
                    break;
            }

            return newVehicle;
        }

    }
}
