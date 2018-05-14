using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.FuelBasedVehicle;

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
        public FuelBasedMotorcycle(string i_ModelName, string i_LicenseNumber, eLicenseType i_LicenseType,
            int i_EngineVolume) : base(i_LicenseNumber, i_ModelName, k_FuelType, k_MaxAmountOfFuel)
        {
            this.m_LicenseType = i_LicenseType;
            this.m_EngineVolume = i_EngineVolume;
            InitWheels();
        }

        /* Unimplemented Properties */
        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
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
" + base.ToString() +
@"License Type: {0} 
Engine volume: {1}", LicenseType, EngineVolume);
        }



    }
}
