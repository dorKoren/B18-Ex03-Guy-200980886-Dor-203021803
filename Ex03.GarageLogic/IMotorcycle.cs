﻿namespace Ex03.GarageLogic
{
    /* Enum */
    public enum eLicenseType
    {
        A,
        A1,
        B1,
        B2
    }

    /* Interface */
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