
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelBasedTruck : FuelBasedVehicle, ITruck
    {
        /* Regular Members */
        private bool m_IsCooled;
        private float m_VolumeOfCargo;

        /* Const Members */
        private const string k_WheelModel = "Michelin";  
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
            FuelType = k_FuelType;
            InitWheels();
        }

        /* Unimplemented Properties */
        public bool IsCooled
        {
            get { return this.m_IsCooled; }
            set { this.m_IsCooled = value; }               
        }

        public float VolumeOfCargo
        {
            get { return m_VolumeOfCargo; }
            set { this.m_VolumeOfCargo = value; }         
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
{0}
Is Cooled: {1} 
Volume of cargo: {2}",base.ToString(), IsCooled, VolumeOfCargo);
        }
    }
}
