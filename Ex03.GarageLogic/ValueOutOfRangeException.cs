using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        /* Regular Members */
        private float m_MaxValue;
        private float m_MinValue;

        /* Constructor */
        public ValueOutOfRangeException(
            string i_Message,
            float i_MaxValue,
            float i_MinValue)
            : base(
                  string.Format("{0} Value Out Of Range Exception: ({1},{2})",i_Message, i_MaxValue, i_MinValue)) 
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }

        /* Properties */
        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MiValue
        {
            get { return m_MinValue; }
        }
    }
}
