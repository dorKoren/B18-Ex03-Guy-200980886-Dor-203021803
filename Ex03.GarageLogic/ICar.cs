using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public interface ICar
    {
        /* Properties */
        eColorType Color
        {
            get;
            set;
        }

        eNumOfDoors NumOfDoors
        {
            get;
            set;
        }
    }
}
