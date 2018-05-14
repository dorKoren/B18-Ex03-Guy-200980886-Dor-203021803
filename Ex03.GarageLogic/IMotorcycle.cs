using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    interface IMotorcycle
    {
        /* Properties */
        eLicenseType LicenseType
        {
            get;
        }

        int EngineVolume
        {
            get;
        }
    }
}