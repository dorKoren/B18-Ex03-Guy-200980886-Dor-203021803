using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    interface ICar
    {
        /* Properties */
        eColorType Color
        {
            get;
        }

        eNumOfDoors NumOfDoors
        {
            get;
        }
    }
}
