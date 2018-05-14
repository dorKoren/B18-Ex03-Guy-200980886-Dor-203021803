using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.ElectricBasedVehicle;
using static Ex03.GarageLogic.FuelBasedVehicle;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class VehiclesMaker
    {

        /* Enums */
        public enum eVehicleType
        {
            None,
            ElectricBasedMotorcycle,
            ElectricBasedCar,
            FuelBasedMotorcycle,
            FuelBasedCar,
            FuelBasedTruck,
        }


        /* Public Methods */
        public Vehicle MakeNewVehicle(eVehicleType i_VehicleType)
        {
            Vehicle newVehicle = null;   // Bag Potential ! we need to think about corect exception!
            switch (i_VehicleType)
            {
                case (eVehicleType.ElectricBasedCar):
                    break;
                case (eVehicleType.ElectricBasedMotorcycle):

                    break;
                case (eVehicleType.FuelBasedCar):

                    break;
                case (eVehicleType.FuelBasedMotorcycle):

                    break;
                case (eVehicleType.FuelBasedTruck):

                    break;
                default:

                    break;
            }

            return newVehicle;
        }

    }
}
