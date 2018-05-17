using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class ElectricBasedMotorcycle : ElectricBasedVehicle, IMotorcycle
    {
        /* Regular Members */
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        /* Const Members */
        private const string k_WheelModel = "Michelin";  
        private const int k_NumOfWheels = 2;
        private const float k_MaxAirPressure = 30;
        private const float k_MaxBatteryLife = 1.8F;


        /* Constructor */
        // Default constructor for the use of VehicleMaker class
        public ElectricBasedMotorcycle() : base()
        {
            this.m_LicenseType = eLicenseType.Unknown;
            this.m_EngineVolume = 0;
            MaxBatteryLife = k_MaxBatteryLife;
            Type = eVehicleType.ElectricBasedMotorcycle;
            InitWheels();
        }

        /* Unimplemented Properties */
        public eLicenseType LicenseType
        {
            get { return this.m_LicenseType; }
            set { this.m_LicenseType = value; }             
        }

        public int EngineVolume
        {
            get { return this.m_EngineVolume; }
            set { this.m_EngineVolume = value; }           
        }

        /* Public Methods */
        public void InitWheels()
        {
            InitWheels(k_WheelModel, k_NumOfWheels, k_MaxAirPressure);
        }

        public override string ToString()
        {
            return string.Format(
@"Electric Based Motorcycle:
{0}
License Type: {1} 
Engine volume: {2}", base.ToString(), LicenseType, EngineVolume);
        }
    }
}

