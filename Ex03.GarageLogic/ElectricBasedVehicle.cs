﻿using System.Collections.Generic;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class ElectricBasedVehicle : Vehicle, IFillable
    {


        /* Class Members */
        private float m_CurrentBatteryLife; // In hours.
        private float m_MaxBatteryLife;       // In hours.


        /* Constructor */
        public ElectricBasedVehicle(string i_ModelName, string i_LicenseNumber, float m_MaxTimeOfEngineOperation)
            : base(i_ModelName, i_LicenseNumber)
        {
            // We should add exception.
            this.m_MaxBatteryLife = m_MaxTimeOfEngineOperation;
            this.m_CurrentBatteryLife = m_MaxTimeOfEngineOperation;
        }

        /* Properties */
        public float CurrentBatteryLife
        {
            get { return m_CurrentBatteryLife; }
            set { m_CurrentBatteryLife = value; }
        }

        public float MaxBatteryLife
        {
            get { return m_MaxBatteryLife; }
        }

        /* Unimplemented Methods */

        /// <summary>
        /// Receives how many more hours to add, and charges the battery,
        /// while not crossing the max limit.
        /// </summary>
        public void Fill(float i_Amount)
        {
            float newBatteryLife = i_Amount + CurrentBatteryLife;

            if (newBatteryLife > MaxBatteryLife || i_Amount < 0)
            {
                throw new ValueOutOfRangeException(this.GetType().Name, MaxBatteryLife, 0);
            }
            else
            {
                CurrentBatteryLife = newBatteryLife;
            }
        }

        /* Public Methods */
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