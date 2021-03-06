﻿using System.Collections.Generic;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class ElectricBasedVehicle : Vehicle, IFillable
    {

        /* Class Members */
        private float m_CurrentBatteryLife;   // In hours.
        private float m_MaxBatteryLife;       // In hours.

        /* Constructor */

        // Default constructor for the use of VehicleMaker class
        public ElectricBasedVehicle() : base()
        {
            this.m_MaxBatteryLife = 0;
            this.m_CurrentBatteryLife = 0;
        }

        public ElectricBasedVehicle(string i_ModelName, string i_LicenseNumber, float m_MaxTimeOfEngineOperation)
            : base(i_ModelName, i_LicenseNumber)
        {
            // We should add exception.???
            this.m_MaxBatteryLife = m_MaxTimeOfEngineOperation;
            this.m_CurrentBatteryLife = m_MaxTimeOfEngineOperation;
        }

        /* Properties */
        public float CurrentBatteryLife
        {
            get { return this.m_CurrentBatteryLife; }
            set { this.m_CurrentBatteryLife = value; }
        }

        public float MaxBatteryLife
        {
            get { return this.m_MaxBatteryLife; }
            set { this.m_MaxBatteryLife = value; }
        }

        /* Unimplemented Methods */

        /// <summary>
        /// Receives how many more ***minutes*** to add, and charges the battery,
        /// while not crossing the max limit.
        /// </summary>
        public void Fill(float i_Amount)
        {
            float newBatteryLife = (i_Amount / 60F) + CurrentBatteryLife;

            if (newBatteryLife > MaxBatteryLife || i_Amount < 0)
            {
                throw new ValueOutOfRangeException(this.GetType().Name, MaxBatteryLife, 0);
            }
            else
            {
                CurrentBatteryLife = newBatteryLife;
            }
            // update the remaining amount of energy
            RemainingEnergyPercentage = (MaxBatteryLife > 0) ? ((CurrentBatteryLife / MaxBatteryLife) * 100) : 0;

        }

        /* Public Methods */

        /// <summary>
        /// A method charges the given amount of ***mins*** 
        /// into the vehicle's battry life.
        /// </summary>
        public bool Charge(float i_AmountInMins)    
        {
            bool isCharged = true;

            try
            {
               Fill(i_AmountInMins);
            }
            catch (ValueOutOfRangeException)
            {
                isCharged = !isCharged;   // isCharged = false
            }

            return isCharged;

        }

        public override string ToString()
        {
            return string.Format(base.ToString() +
@"
Remaining time of engine operation: {0}
Max time of engine operation: {1}
", CurrentBatteryLife, MaxBatteryLife);
        }
    }
}