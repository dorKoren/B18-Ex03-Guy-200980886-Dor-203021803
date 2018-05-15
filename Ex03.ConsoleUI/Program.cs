using static Ex03.ConsoleUI.Engine;
using System;
using System.Text;
using Ex03.GarageLogic;


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

            ElectricBasedCar ec = new ElectricBasedCar("Honda", "4958611", Enums.eColorType.Black, Enums.eNumOfDoors.Four);

            garage.Insert(ec, "4958611", "Dor", "0545206551");

            //Console.WriteLine(fc.ToString());

            //Console.WriteLine(garage.DisplayVehicleInformation("4958611"));

            Console.WriteLine(GetVehicleType());








        }
    }
}
