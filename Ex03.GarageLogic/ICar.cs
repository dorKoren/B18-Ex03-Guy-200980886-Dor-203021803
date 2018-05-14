namespace Ex03.GarageLogic
{
    /* Enums */
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

    /* Interface */
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
