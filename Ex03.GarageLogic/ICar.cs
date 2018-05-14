namespace Ex03.GarageLogic
{
    /* Enums */
    public enum eColorType
    {
        Gray,
        Blue,
        White,
        Black
    }

    public enum eNumOfDoors
    {
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
