namespace Ex03.GarageLogic
{
    public class ElectricBasedCar : ElectricBasedVehicle, ICar
    {
        /* Regular Members */
        private eColorType m_Color;
        private eNumOfDoors m_NumOfDoors;

        /* Const Members */
        private const string k_WheelModel = "Michelin";  // we need to check in the document about the brand name...
        private const int k_NumOfWheels = 4;
        private const float k_MaxAirPressure = 32;
        private const float k_MaxBatteryLife = 3.2F;


        /* Constructor */
        public ElectricBasedCar(string i_ModelName, string i_LicenseNumber, eColorType i_Color,
            eNumOfDoors i_NumOfDoors) : base(i_LicenseNumber, i_ModelName, k_MaxBatteryLife)
        {
            this.m_Color = i_Color;
            this.m_NumOfDoors = i_NumOfDoors;
            InitWheels();
        }

        /* Unimplemented Properties */
        public eColorType Color
        {
            get { return m_Color; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
        }

        /* Public Methods */
        public void InitWheels()
        {
            InitWheels(k_WheelModel, k_NumOfWheels, k_MaxAirPressure);
        }

        public override string ToString()
        {
            return string.Format(
@"Electric Based Car:
" + base.ToString() +
@"Color: {0} 
Num of doors: {1}", Color, NumOfDoors);
        }



    }
}
