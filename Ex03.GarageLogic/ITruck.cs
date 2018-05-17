namespace Ex03.GarageLogic
{
    public interface ITruck
    {
        /* Public Methods */
        bool IsCooled
        {
            get;
            set;
        }

        /* Properties */
        float VolumeOfCargo
        {
            get;
            set;
        }
    }
}
