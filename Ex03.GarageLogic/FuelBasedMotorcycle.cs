using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.FuelBasedVehicle;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelBasedMotorcycle : FuelBasedVehicle, IMotorcycle
    {
        /* Regular Members */
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        /* Const Members */
        private const string k_WheelModel = "Michelin";  // we need to check in the document about the brand name...
        private const int k_NumOfWheels = 2;
        private const float k_MaxAirPressure = 30;
        private const float k_MaxAmountOfFuel = 6;
        private const eFuelType k_FuelType = eFuelType.Octan96;


        /* Constructor */
        // Default constructor for the use of VehicleMaker class
        public FuelBasedMotorcycle() : base()
        {
            this.m_LicenseType = eLicenseType.Unknown;
            this.m_EngineVolume = 0;
            MaxAmountOfFuel = k_MaxAmountOfFuel;
            FuelType = k_FuelType;
            Type = eVehicleType.FuelBasedMotorcycle;
        }

        public FuelBasedMotorcycle(string i_ModelName, string i_LicenseNumber, eLicenseType i_LicenseType,
            int i_EngineVolume) : base(i_LicenseNumber, i_ModelName, k_FuelType, k_MaxAmountOfFuel)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
            Type = eVehicleType.FuelBasedMotorcycle;
            FuelType = k_FuelType;
            InitWheels();
        }

        /* Unimplemented Properties */
        public eLicenseType LicenseType
        {
            get { return this.m_LicenseType; }
            set { this.m_LicenseType = value; }             // Guy addition 14.05
        }

        public int EngineVolume
        {
            get { return this.m_EngineVolume; }
            set { this.m_EngineVolume = value; }            // Guy addition 14.05
        }

        /* Public Methods */
        public void InitWheels()
        {
            InitWheels(k_WheelModel, k_NumOfWheels, k_MaxAirPressure);
        }

        public override string ToString()
        {
            return string.Format(
@"Fuel Based Motorcycle:
{0}
License Type: {1} 
Engine volume: {2}", base.ToString(), LicenseType, EngineVolume);
        }
    }
}
