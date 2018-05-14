using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        /* Nested Class */
        public class Wheel : IFillable
        {
            /* Class Members */
            private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;

            /* Constructor */

            public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
            {
                this.m_ManufacturerName = i_ManufacturerName;
                this.m_MaxAirPressure = i_MaxAirPressure;
                this.m_CurrentAirPressure = i_MaxAirPressure;
            }

            /* Properties */
            public string ManufacturerName
            {
                get { return m_ManufacturerName; }
            }

            public float CurrentAirPressure
            {
                get { return m_CurrentAirPressure; }
                set { this.m_CurrentAirPressure = value; }
            }

            public float MaxAirPressure
            {
                get { return m_MaxAirPressure; }
            }

            /* Unimplemented Methods */

            /// <summary>
            /// Receives how much more air to add to a wheel, and changes the
            /// air pressure while not crossing the max limit.
            /// Attention: this method only inflates a wheel, not deflates. 
            /// </summary>
            public void Fill(float i_Amount)
            {
                float newPressure = i_Amount + CurrentAirPressure;

                if (newPressure > MaxAirPressure || i_Amount < 0)              
                {
                    throw new ValueOutOfRangeException(this.GetType().Name, MaxAirPressure, 0);
                }
                else
                {
                    CurrentAirPressure = newPressure;
                }
            }

            /* public Methods */
            public override string ToString()
            {
                return string.Format(
@"Manufacturer Name:     {0}
Current air pressure:  {1}
Max air pressure:      {2}", ManufacturerName, CurrentAirPressure, MaxAirPressure);
            }
        }





        /************************************** End of inner class *******************************************************/

        /* Regular Members */
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_RemainingEnergyPercentage;
        protected List<Wheel> m_Wheels;
        protected eVehicleType m_Type;

        /* ReadOnly Members */
        protected readonly float r_FullEnergy = 100F;
        protected readonly string r_Default = "DEFAULT";

        /* Constructor */
        // Default constructor for the use of VehicleMaker class
        public Vehicle()
        {
            this.m_ModelName = r_Default;
            this.m_LicenseNumber = r_Default;
            this.m_RemainingEnergyPercentage = 0;
            m_Type = eVehicleType.None;
            InitWheels("", 0, 0);
        }

        public Vehicle(string i_Model, string i_LicenseNumber)
        {   // we should add exception
            this.m_ModelName = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_RemainingEnergyPercentage = r_FullEnergy;  // We assume that full energy is represented by 100F (as 100%)
            this.m_Type = eVehicleType.None;
            InitWheels("", 0, 0);
        }

        /* Properties */
        public string ModelName
        {
            get { return this.m_ModelName; }
            set { this.m_ModelName = value; }               // Addition Guy 14.05

        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { this.m_LicenseNumber = value; }           // Addition Guy 14.05
        }

        public float RemainingEnergyPercentage
        {
            get { return m_RemainingEnergyPercentage; }
            set { m_RemainingEnergyPercentage = value; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public eVehicleType Type                    // Guy addition 14.05
        {
            get { return this.m_Type; }
            set { this.m_Type = value; }
        }


        /* Public Methods */
        public void InitWheels(string i_WheelModel, int i_NumOfWheels, float i_MaxAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>();

            for (int wheelIndex = 0; wheelIndex < i_NumOfWheels; wheelIndex++)
            {
                wheels.Add(new Wheel(i_WheelModel, i_MaxAirPressure));
            }

            Wheels = wheels;
        }

        /// <summary>
        /// This method fills all wheels with the given
        /// </summary>
        /// <param name="i_MaxAirPressure"></param>
        /// <returns></returns>
        public bool InflateAllWheels(float i_MaxAirPressure)                        // Guy addition 14.05
        {
            bool hasInflatedAllWheels = false;
            int numOfInflatedWheels = 0;

            if (Wheels.Count >= 0)
            {
                foreach (Wheel currentWheel in Wheels)
                {
                    float pressureDiff = currentWheel.MaxAirPressure - currentWheel.CurrentAirPressure;
                    try 
                    {
                        currentWheel.Fill(pressureDiff);
                        numOfInflatedWheels++;
                    }
                    catch
                    {
                        throw new ValueOutOfRangeException(this.GetType().Name, currentWheel.MaxAirPressure, 0);
                    }
                }
                hasInflatedAllWheels = (numOfInflatedWheels == Wheels.Count - 1) ? !hasInflatedAllWheels : hasInflatedAllWheels;
            }

            return hasInflatedAllWheels;
        }

        public override string ToString()
        {

            return string.Format(
@"Model name: {0}
License number: {1}
Remaining energy percentage: {2}%

Wheels: 
{3}", ModelName, LicenseNumber, RemainingEnergyPercentage, printWheels(Wheels));
        }

        /* Private Methods */
        private string printWheels(List<Wheel> i_Wheels)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Wheel currentWheel in i_Wheels)
            {
                sb.Append("wheel " + i_Wheels.IndexOf(currentWheel) + ":\n");
                sb.Append(currentWheel.ToString() + "\n");
            }

            return sb.ToString();
        }
    }
}
