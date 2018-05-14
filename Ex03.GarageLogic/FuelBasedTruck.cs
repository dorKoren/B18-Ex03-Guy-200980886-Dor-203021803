using System;
using System.Collections.Generic;


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
        public FuelBasedTruck(string i_ModelName, string i_LicenseNumber, bool i_IsCooled,
             float i_VolumeOfCargo) : base(i_LicenseNumber, i_ModelName, k_FuelType, k_MaxAmountOfFuel)
        {
            this.m_IsCooled = i_IsCooled;
            this.m_VolumeOfCargo = i_VolumeOfCargo;
            InitWheels();
        }

        /* Unimplemented Properties */
        public bool IsCooled
        {
            get { return m_IsCooled; }
        }

        public float VolumeOfCargo
        {
            get { return m_VolumeOfCargo; }
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
