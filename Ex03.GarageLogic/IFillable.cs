namespace Ex03.GarageLogic
{
    public interface IFillable
    {
        // Needs to throw exception if overfilling.
        void Fill(float amount);

    }
}
