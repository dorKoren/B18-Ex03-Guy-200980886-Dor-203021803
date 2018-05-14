﻿using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Enums;
using static Ex03.GarageLogic.VehicleMaker;

namespace Ex03.ConsoleUI
{
    public class Engine
    {

        public static void Run()
        {

            Console.WriteLine(DisplayMenue());

        }
















        /* Private Methods */
        private static string DisplayMenue()
        {
            return string.Format(
@"
 _______________________________________________________________
| Please choose from the following operations:                  |
|---------------------------------------------------------------|
| 1. Insert a Vehicle into the garage.                          |
| 2. Display a list of license numbers currently in the garage. |
| 3. Change a certain vehicle’s status.                         |
| 4. Inflate tires to maximum.                                  |
| 5. Refuel vehicle.                                            |
| 6. Charge vehicle.                                            |
| 7. Display vehicle information.                               |
|_______________________________________________________________| ");
        }
    }
}
