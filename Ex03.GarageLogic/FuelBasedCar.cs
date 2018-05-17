using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class FuelBasedCar : FuelBasedVehicle, ICar
    {
        /* Regular Members */
        private eColorType m_Color;
        private eNumOfDoors m_NumOfDoors;

        /* Const Members */
        private const string k_WheelModel = "Michelin";  
        private const int k_NumOfWheels = 4;
        private const float k_MaxAirPressure = 32;
        private const float k_MaxAmountOfFuel = 45;
        private const eFuelType k_FuelType = eFuelType.Octan98;

        /* Constructor */
        // Default constructor for the use of VehicleMaker class
        public FuelBasedCar() : base()
        {
            this.m_Color = eColorType.Unknown;
            this.m_NumOfDoors = eNumOfDoors.Unknown;
            MaxAmountOfFuel = k_MaxAmountOfFuel;
            Type = eVehicleType.FuelBasedCar;
            FuelType = k_FuelType;
            InitWheels();
        }

        /* Unimplemented Properties */
        public eColorType Color
        {
            get { return this.m_Color; }
            set { this.m_Color = value; }           
        }

        public eNumOfDoors NumOfDoors
        {
            get { return this.m_NumOfDoors; }
            set { this.m_NumOfDoors = value; }      
        }

        /* Public Methods */
        public void InitWheels()
        {
            InitWheels(k_WheelModel, k_NumOfWheels, k_MaxAirPressure);
        }

        public override string ToString()
        {
            return string.Format(
@"Fuel Based Car:
{0}
Color: {1} 
Num of doors: {2}", base.ToString(), Color, NumOfDoors);
        }
    }
}
