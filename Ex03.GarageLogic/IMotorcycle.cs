using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public interface IMotorcycle
    {
        /* Properties */
        eLicenseType LicenseType
        {
            get;
            set;
        }

        int EngineVolume
        {
            get;
            set;
        }
    }
}