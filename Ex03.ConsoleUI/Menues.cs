using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public static class Menues
    {
        public static string DisplayMenue()
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


        public static string DisplayVehicleTypes()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please select a desired type of Vehicle out of the following: |
  |-------------------------------------------------------------- |
  | 1.   Electric Motorcycle                                      |
  | 2.   Electric Car                                             |
  | 3.   Fuel Based Motorcycle                                    |
  | 4.   Fuel Based Car                                           |
  | 5.   Fuel Based Truck                                         |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");

        }

        public static string DisplayColorTypes()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please select a desired color of Vehicle out of the following:|
  |---------------------------------------------------------------|                                                            
  | 1.   Gray                                                     |
  | 2.   Blue                                                     |
  | 3.   White                                                    |
  | 4.   Black                                                    |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");

        }

        public static string DisplayWheelsAirPressure()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter your wheels air pressure:                        |
  |---------------------------------------------------------------|                                                    
  |  Wheels air fressure: ___                                     |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }


        public static string DisplayFuelAmount()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter your fuel ammount:                               |
  |---------------------------------------------------------------|                                                    
  |  fuel ammount: ___                                            |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");

        }

        public static string DisplayBstteryLife()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter your battery life ammount:                       |
  |---------------------------------------------------------------|                                                    
  |  battery life ammount: ___                                    |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }

        public static string DisplayLicenseType()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please select a license type:                                 |
  |---------------------------------------------------------------|                                                    
  |  1. A                                                         |
  |  2. A1                                                        |
  |  3. B1                                                        |
  |  4. B2                                                        |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");

        }

        public static string DisplayEngineVolume()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter your engine volume:                              |
  |---------------------------------------------------------------|                                                    
  |  engine volume: ___                                           |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }

        public static string DisplayNumbersOfDoors()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please select how many doors you have:                        |
  |---------------------------------------------------------------|                                                    
  |  1. Two                                                       |
  |  2. Three                                                     |
  |  3. Four                                                      |
  |  4. Five                                                      |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }

        public static string DisplayIsCooles()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Is it cooled?                                                 |
  |---------------------------------------------------------------|                                                    
  |  1. yes                                                       |
  |  2. no                                                        |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }

        public static string DisplayVolumeOfCargo()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter volume cargo:                                    |
  |---------------------------------------------------------------|                                                    
  |  volume cargo: ___                                            |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }

        public static string DisplayOwnerName()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter owner name:                                      |
  |---------------------------------------------------------------|                                                    
  |  Owner name: ___                                              |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");

        }

        public static string DisplayOwnerPhoneNumber()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter owner phone number:                              |
  |---------------------------------------------------------------|                                                    
  |  Owner phone number: ___                                      |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }

        public static string DisplayOwnerLicenseNumber()
        {
            return string.Format(
@"
   _______________________________________________________________
  | Please enter owner license number:                            |
  |---------------------------------------------------------------|                                                    
  |  Owner license number: ___                                    |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |                                                               |
  |_______________________________________________________________| ");
        }
    }
}

