using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelBasedTruck : FuelBasedVehicle, ITruck
    {
        /* Regular Members */
        private bool m_IsCooled;
        private float m_VolumeOfCargo;

        /* Const Members */
        private const string k_WheelModel = "Michelin";  // we need to check in the document about the brand name...
        private const int k_NumOfWheels = 12;
        private const float k_MaxAirPressure = 28;
        private const float k_MaxAmountOfFuel = 115;
        private const eFuelType k_FuelType = eFuelType.Octan96;


        /* Constructor */
        // Default constructor for the use of VehicleMaker class
        public FuelBasedTruck() : base()
        {
            this.m_IsCooled = false;
            this.m_VolumeOfCargo = 0;
            MaxAmountOfFuel = k_MaxAmountOfFuel;
            Type = eVehicleType.FuelBasedTruck;
        }

        public FuelBasedTruck(string i_ModelName, string i_LicenseNumber, bool i_IsCooled,
             float i_VolumeOfCargo) : base(i_LicenseNumber, i_ModelName, k_FuelType, k_MaxAmountOfFuel)
        {
            this.m_IsCooled = i_IsCooled;
            this.m_VolumeOfCargo = i_VolumeOfCargo;
            Type = eVehicleType.FuelBasedTruck;
            InitWheels();
        }

        /* Unimplemented Properties */
        public bool IsCooled
        {
            get { return this.m_IsCooled; }
            set { this.m_IsCooled = value; }                // Guy addition 14.05
        }

        public float VolumeOfCargo
        {
            get { return m_VolumeOfCargo; }
            set { this.m_VolumeOfCargo = value; }           // Guy addition 14.05
        }

        /* Public Methods */
        public void InitWheels()
        {
            InitWheels(k_WheelModel, k_NumOfWheels, k_MaxAirPressure);
        }

        public override string ToString()
        {
            return string.Format(
@"Fuel Based Truck:
" + base.ToString() +
@"Is Cooled: {0} 
Volume of cargo: {1}", IsCooled, VolumeOfCargo);
        }



    }
}
