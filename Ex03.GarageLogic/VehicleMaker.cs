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
        public static void MakeNewVehicle(eVehicleType i_VehicleType, out Vehicle o_Vehicle)
        {
            //Vehicle newVehicle = null;   // Bag Potential ! we need to think about corect exception!
            o_Vehicle = null;

            switch (i_VehicleType)
            {
                case (eVehicleType.ElectricBasedMotorcycle):
                    o_Vehicle = new ElectricBasedMotorcycle();
                    break;

                case (eVehicleType.ElectricBasedCar):
                    o_Vehicle = new ElectricBasedCar();
                    break;

                case (eVehicleType.FuelBasedMotorcycle):
                    o_Vehicle = new FuelBasedMotorcycle();
                    break;

                case (eVehicleType.FuelBasedCar):
                    o_Vehicle = new FuelBasedCar();
                    break;
               
                case (eVehicleType.FuelBasedTruck):
                    o_Vehicle = new FuelBasedTruck();
                    break;

                default:
                    break;
            }
        }

    }
}
