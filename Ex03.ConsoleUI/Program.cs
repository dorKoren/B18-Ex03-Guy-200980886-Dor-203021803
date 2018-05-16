using static Ex03.ConsoleUI.Engine;
using System;
using System.Text;
using Ex03.GarageLogic;
using static Ex03.ConsoleUI.Menues.MainMenu;



using static Ex03.ConsoleUI.UI;  // <--- delete!

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Engine engine = new Engine();
            //engine.Run();

            Garage garage = new Garage();

            ElectricBasedCar ec = new ElectricBasedCar("Tesla", "0000001", Enums.eColorType.Black, Enums.eNumOfDoors.Four);

            FuelBasedCar fc = new FuelBasedCar("VolksWagen", "0000002", Enums.eColorType.Black, Enums.eNumOfDoors.Four);

            FuelBasedMotorcycle fm = new FuelBasedMotorcycle();
            ElectricBasedMotorcycle em = new ElectricBasedMotorcycle();
            FuelBasedTruck ft = new FuelBasedTruck();

            garage.Insert(ec, "0000001", "Guy", "0509933321");
            garage.Insert(fc, "0000002", "Dor", "0545206551");
            garage.Insert(em, "0000003", "TamiTamir", "0509933321");
            em.Wheels[0].CurrentAirPressure = 10;
            garage.Insert(fm, "0000004", "GeorgeBush", "0545206551"); 
            garage.Insert(ft, "0000005", "WillSmith", "0545206551");

            engine.Garage = garage;
            engine.Run();





            //Console.WriteLine(garage.DisplayVehicleInformation("4958611"));

            //Console.WriteLine(GetVehicleType());

            //eMainMenuOptions choice = (eMainMenuOptions)Enum.Parse(typeof(eMainMenuOptions), "");
            //Console.WriteLine(choice.ToString());







        }
    }
}