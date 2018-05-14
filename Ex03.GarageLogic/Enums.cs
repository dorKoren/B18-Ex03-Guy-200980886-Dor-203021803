namespace Ex03.GarageLogic
{
    public class Enums
    {
        public enum eVehicleType
        {
            None,
            ElectricBasedMotorcycle,
            ElectricBasedCar,
            FuelBasedMotorcycle,
            FuelBasedCar,
            FuelBasedTruck,
        }

        public enum eFuelType
        {
            Unknown,
            Soler,
            Octane95,
            Octan96,
            Octan98
        }

        public enum eVehicleStatus
        {
            None,
            Waiting,
            InRepair,
            Repaired,
            PayedFor,
        }

        public enum eColorType
        {
            Unknown,
            Gray,
            Blue,
            White,
            Black
        }
        public enum eNumOfDoors
        {
            Unknown,
            Two,
            Three,
            Four,
            Five
        }

        public enum eLicenseType
        {
            Unknown,
            A,
            A1,
            B1,
            B2
        }
    }
}
