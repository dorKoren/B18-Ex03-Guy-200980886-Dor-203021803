﻿using static Ex03.GarageLogic.Enums;
using System;

namespace Ex03.GarageLogic
{
    public class FuelBasedVehicle : Vehicle, IFillable   

    {
        /* Class Members */
        private eFuelType m_FuelType;
        private float m_CurrentAmountOfFuel;  // In liters. 
        private float m_MaxAmountOfFuel;      // In liters.

        /* Constructor */
        // Default constructor for the use of VehicleMaker class
        public FuelBasedVehicle() : base()
        {
            this.m_FuelType = eFuelType.Unknown;
            this.m_CurrentAmountOfFuel = 0;
            this.m_MaxAmountOfFuel = 0;
        }

        public FuelBasedVehicle(string i_ModelName, string i_LicenseNumber, eFuelType i_FuelType, float i_MaxAmountOfFuel)
            : base(i_ModelName, i_LicenseNumber)

        {
            this.m_MaxAmountOfFuel = i_MaxAmountOfFuel;
            this.m_CurrentAmountOfFuel = MaxAmountOfFuel;
            this.m_FuelType = i_FuelType;
        }

        /* Properties */
        public eFuelType FuelType
        {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

        public float CurrentAmountOfFuel
        {
            get { return m_CurrentAmountOfFuel; }
            set { m_CurrentAmountOfFuel = value; }
        }

        public float MaxAmountOfFuel
        {
            get { return m_MaxAmountOfFuel; }
            set { this.m_MaxAmountOfFuel = value; }
        }

        /* Public Methods */
        public void Fill(float i_Amount)
        {
            float newAmountOfFuel = i_Amount + CurrentAmountOfFuel;

            if (newAmountOfFuel > MaxAmountOfFuel || i_Amount < 0)
            {
                throw new ValueOutOfRangeException(this.GetType().Name, MaxAmountOfFuel, 0);
            }
            else
            {
                CurrentAmountOfFuel = newAmountOfFuel;
            }
        }

        /// <summary>
        /// A method that receives how much more fuel to add, and changes the 
        /// amount of fuel, if the fuel type is correct, and the fuel tank
        /// is less than full.
        /// </summary>
        public bool Refuel(float i_Amount, eFuelType i_FuelType)                        
        {
            bool refuled = true;
            if (!i_FuelType.Equals(FuelType))
            {
                refuled = !refuled;
                throw new ArgumentException(this.GetType().Name + "Wrong fuel type");
            }
            else
            {
                try
                {
                    Fill(i_Amount);
                }
                catch (ValueOutOfRangeException)
                {
                    refuled = !refuled;
                }
            }

            return refuled;
        }

        public override string ToString()
        {
            return string.Format(base.ToString() +
@"
Fuel type: {0}
current amount of fuel: {1}
Max amount of fuel: {2}
", FuelType, CurrentAmountOfFuel, MaxAmountOfFuel);
        }
    }
}
