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
            //Engine engine = new Engine();
            //engine.Run();

            Garage garage = new Garage();

            ElectricBasedCar ec = new ElectricBasedCar("Tesla", "0000001", Enums.eColorType.Black, Enums.eNumOfDoors.Four);

            FuelBasedCar fc = new FuelBasedCar("VolksWagen", "0000002", Enums.eColorType.Black, Enums.eNumOfDoors.Four);

            garage.Insert(ec, "0000001", "Guy", "0509933321");
            garage.Insert(fc, "0000002", "Dor", "0545206551");

            ElectricBasedMotorcycle em = new ElectricBasedMotorcycle();
            FuelBasedTruck ft = new FuelBasedTruck();

            Console.WriteLine(ft.ToString());

            //Console.WriteLine(garage.DisplayVehicleInformation("4958611"));

            //Console.WriteLine(GetVehicleType());

            //eMainMenuOptions choice = (eMainMenuOptions)Enum.Parse(typeof(eMainMenuOptions), "");
            //Console.WriteLine(choice.ToString());







        }
    }
}