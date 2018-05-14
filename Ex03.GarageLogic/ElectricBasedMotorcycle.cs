namespace Ex03.GarageLogic
{
    public class ElectricBasedMotorcycle : ElectricBasedVehicle, IMotorcycle
    {
        /* Regular Members */
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        /* Const Members */
        private const string k_WheelModel = "Michelin";  // we need to check in the document about the brand name...
        private const int k_NumOfWheels = 2;
        private const float k_MaxAirPressure = 30;
        private const float k_MaxBatteryLife = 1.8F;


        /* Constructor */
        public ElectricBasedMotorcycle(string i_ModelName, string i_LicenseNumber, eLicenseType i_LicenseType,
            int i_EngineVolume) : base(i_LicenseNumber, i_ModelName, k_MaxBatteryLife)
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
@"Electric Based Motorcycle:
" + base.ToString() +
@"License Type: {0} 
Engine volume: {1}", LicenseType, EngineVolume);
        }



    }
}

