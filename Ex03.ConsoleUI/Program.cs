using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.ConsoleUI.UI;
using static Ex03.GarageLogic.Vehicle;
using static Ex03.GarageLogic.ValueOutOfRangeException;
using static Ex03.GarageLogic.Garage;
using static Ex03.GarageLogic.Enums;
using static Ex03.GarageLogic.VehicleMaker;


namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {

            //Start();

            /*
            List<Vehicle.Wheel> list = new List<Vehicle.Wheel>
            {
                new Vehicle.Wheel("ddd", 10),
                new Vehicle.Wheel("ddd", 10)
            };

            Vehicle v = new Vehicle("Honda", "1223");

            //Console.WriteLine(v.ToString());


            FuelBasedVehicle fv = new FuelBasedVehicle("1234", "FordFocus", FuelBasedVehicle.eFuelType.Octan96, 50);

            ElectricBasedVehicle ev = new ElectricBasedVehicle("Ferari", "1222", 100);

            FuelBasedMotorcycle fm = new FuelBasedMotorcycle("1233", "Zibi", eLicenseType.A, 250);

            FuelBasedCar fc = new FuelBasedCar("123", "Day", eColorType.Black, eNumOfDoors.Four);

            FuelBasedTruck ft = new FuelBasedTruck("22333", "101010101", true, 100);

            ElectricBasedMotorcycle em = new ElectricBasedMotorcycle("GOODYEAR", "205151", eLicenseType.A1, 250);

            ElectricBasedCar ec = new ElectricBasedCar("zibi", "1234", eColorType.Gray, eNumOfDoors.Three);

             try
             {
                 ec.Fill(10);
             }
             catch (ValueOutOfRangeException e)
             {
                 Console.WriteLine("catch : " + e.Message);
             } */

            /*
            Garage garage = new Garage();

            garage.Insert(ec, "123", "Dor", "11111");  // <--- Bag potential
            garage.Insert(ec, "456", "guy", "22222");
            garage.Insert(ec, "678", "zibi", "33333");

            garage.ChangeVehicleStatus("456", VehicleDetails.eVehicleStatus.Repaired);

            garage.LicenseNumbersList.TryGetValue("456", out VehicleDetails value);

            Console.WriteLine(ec.Wheels[0].CurrentAirPressure);

            garage.InflateTiresToMaximum("456");

            Console.WriteLine(ec.Wheels[0].CurrentAirPressure);
            */

            Vehicle newVehicle = MakeNewVehicle(eVehicleType.ElectricBasedCar);



            Console.WriteLine(newVehicle.ToString());



            //Console.WriteLine(garage.DisplayLicenseNumbersList(Garage.VehicleDetails.eVehicleStatus.Waiting));



        }
    }
}
