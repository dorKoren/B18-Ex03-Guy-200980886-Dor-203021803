﻿using System;
using System.Text;
using System.Collections.Generic;
using static Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic
{
    public class Garage
    {

        /* Nested Class */
        public class VehicleDetails
        {
            /* Regular Members */
            private string m_OwnerName;
            private string m_OwnerPhone;
            private eVehicleStatus m_VehicleStatus;

            /* Constructor */
            public VehicleDetails(string i_OwnerName, string i_OwnerPhone)
            {
                this.m_OwnerName = i_OwnerName;
                this.m_OwnerPhone = i_OwnerPhone;
                this.m_VehicleStatus = eVehicleStatus.InRepair;
            }

            /* Properties */
            public string OwnerName
            {
                get { return m_OwnerName; }
            }

            public string OwnerPhone
            {
                get { return m_OwnerPhone; }
            }

            public eVehicleStatus VehicleStatus
            {
                get { return m_VehicleStatus; }
                set { m_VehicleStatus = value; }
            }

            /* Public Methods */
            public override string ToString()
            {
                return string.Format(
@"Owner name: {0} 
Owner phone: {1}
Vehicle status: {2}", OwnerName, OwnerPhone, VehicleStatus);
            }
        }

        /**************************** End Of Nested Class ***********************/

        /* Regular Members */
        private Dictionary<string, VehicleDetails> m_LicenseNumbersList;  // <license number, vehicle details>  
        private Dictionary<string, Vehicle> m_VehicleList;                // <license number, vehicle>

        /* Constructor */
        public Garage()
        {
            this.m_LicenseNumbersList = new Dictionary<string, VehicleDetails>();
            this.m_VehicleList = new Dictionary<string, Vehicle>();
        }

        /* Properties */
        public Dictionary<string, VehicleDetails> LicenseNumbersList
        {
            get { return m_LicenseNumbersList; }
        }

        public Dictionary<string, Vehicle> VehicleList
        {
            get { return m_VehicleList; }
        }

        /* Public Methods */

        /// <summary>
        /// “Insert” a new vehicle into the garage.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        public void Insert(
            Vehicle i_Vehicle,
            string i_LicenseNumber,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            if (i_LicenseNumber != "" && i_OwnerName != "" && i_OwnerPhone != "")
            {
                // If we have this vehicle in this garage, change its status
                if (VehicleIsAlreadyInTheGarage(i_LicenseNumber))
                {

                    throw new ArgumentException("Vehicle's license plate is already in the Garage");
                }
                // If we don't have this vehicle in this garage, add it
                else
                {
                    VehicleDetails details = new VehicleDetails(i_OwnerName, i_OwnerPhone)
                    {
                        VehicleStatus = eVehicleStatus.Waiting
                    };

                    LicenseNumbersList.Add(i_LicenseNumber, details);
                    VehicleList.Add(i_LicenseNumber, i_Vehicle);
                }
            }
        }

        /// <summary>
        /// Check if the vehicle is already in the garage.
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        public bool VehicleIsAlreadyInTheGarage(string i_LicenseNumber)
        {
            return LicenseNumbersList.ContainsKey(i_LicenseNumber);
        }

        /// <summary>
        /// Display a list of license numbers currently in the garage, with a
        /// filtering option based on the status of each vehicle.
        /// </summary>
        /// <param name="i_VehicleStatus"></param>
        /// <returns> A list of license numbers string representation </returns>
        public string DisplayLicenseNumbersList(
            eVehicleStatus i_FilteringStatus)
        {
            string licenseNumbersList;

            if (i_FilteringStatus.Equals(eVehicleStatus.None))   // Print all the list
            {
                licenseNumbersList = printLicenseNumbersList(LicenseNumbersList);
            }
            // Print the filtered list.
            else
            {
                Dictionary<string, VehicleDetails> filteredDictionary = new Dictionary<string, VehicleDetails>(LicenseNumbersList);
                List<string> licenses = getDifferentLicensesStatus(i_FilteringStatus);
                removeLicenses(filteredDictionary, licenses);
                licenseNumbersList = printLicenseNumbersList(filteredDictionary);  // i didn't figure out how to use to string method...
            }

            return licenseNumbersList;
        }

        public void ChangeVehicleStatus(
            string i_LicenseNumber,
            eVehicleStatus i_DesiredStatus)
        {

            if (i_LicenseNumber != "")
            {
                LicenseNumbersList.TryGetValue(i_LicenseNumber, out VehicleDetails value);
                value.VehicleStatus = i_DesiredStatus;
            }
        }

        public void InflateTiresToMaximum(string i_LicenseNumber)
        {
            VehicleList.TryGetValue(i_LicenseNumber, out Vehicle vehicle);
            if (vehicle != null)
            {
                vehicle.InflateAllWheels(vehicle.Wheels[0].MaxAirPressure);
            }
        }
        
        public string DisplayVehicleInformation(string i_LicenseNumber)
        {
            string vehicleInformation = "";

            if (VehicleList.TryGetValue(i_LicenseNumber, out Vehicle vehicle) &&
                LicenseNumbersList.TryGetValue(i_LicenseNumber, out VehicleDetails vehicleDetails))
            {
                vehicleInformation = string.Format(
@"{0}
{1}", vehicleDetails.ToString(), vehicle.ToString());
            }

            return vehicleInformation;
        }

        /* Private Methods */

        private string printLicenseNumbersList(
            Dictionary<string, VehicleDetails> i_LicenseNumbers)  // How can we make it to be polimorfic?
        {
            StringBuilder sb = new StringBuilder();

            if (i_LicenseNumbers.Count == 0)   // List is empty.
            {
                sb.Append("");
            }

            foreach (KeyValuePair<string, VehicleDetails> pair in i_LicenseNumbers)
            {
                sb.Append(pair.Key);
                sb.Append("  ");
            }

            return sb.ToString();
        }

        /// <summary>
        ///  Iterarte over the LicenseNumbersList and add all the license 
        ///  whose sataus is different from the i_FilteringStatus to 
        ///  the keys list.
        /// </summary>
        /// <param name="i_FilteringStatus"></param>
        /// <returns></returns>
        private List<string> getDifferentLicensesStatus(
            eVehicleStatus i_FilteringStatus)  // How can we make it to be polimorfic?
        {
            List<string> keys = new List<string>();

            foreach (KeyValuePair<string, VehicleDetails> pair in LicenseNumbersList)
            {
                eVehicleStatus status = pair.Value.VehicleStatus;

                if (!status.Equals(i_FilteringStatus))
                {
                    keys.Add(pair.Key);
                }
            }

            return keys;
        }

        private void removeLicenses(
            Dictionary<string, VehicleDetails> i_FilterDictionary,
            List<string> i_Keys)
        {
            foreach (string key in i_Keys)
            {
                i_FilterDictionary.Remove(key);
            }
        }
    }
}