using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

}

