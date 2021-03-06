﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Travelley
{
   public class TourGuide : Person
    {
        private List<Trip> trips;

        internal List<Trip> Trips { get => trips; set => trips = value; }

        public TourGuide(string Id, string Name, string Nationality, string Language,string Gender, string Email, string PhoneNumber)
        {
            this.Id = Id;
            this.Name = Name;
            this.Nationality = Nationality;
            this.Language = Language;
            this.Gender = Gender;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            Trips = new List<Trip>();
        }

        void AddTrip(Trip obj)
        {
            Trips.Add(obj);
        }

        public double GetSalary(int month, int year)
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            double salary = 0;
            if (currentMonth < month && currentYear < year)
                return -1;

            foreach (Trip T in trips)
            {
                //Tourguide takes money if he starts the trip
                if (T.Start.Month == month && T.Start.Year == year)
                {
                    salary += 150;
                }
            }
            return salary;
        }

        public static TourGuide GetBestTourGuide(int Month)
        {
            int year = DateTime.Today.Year;
            if (Month == 0)  //handles the case if we are in month 1
            {
                Month = 12;
                year--;
            }
            TourGuide ret = DataBase.TourGuides[0];

            foreach (TourGuide t in DataBase.TourGuides)
            {
                if (t.GetSalary(Month, year) > ret.GetSalary(Month, year))
                    ret = t;
            }
            if (ret.GetSalary(Month, year) == 0) //Not Considered a best touguide with salary = 0 !!
                return null;
            return ret;
        }

		public bool CheckAvailability(DateTime start, DateTime end)
		{
            foreach(Trip T in trips)
            {
                if ((start >= T.Start && start <= T.End) || (end >= T.Start && end <= T.End) || (T.Start >= start && T.Start <= end) || (T.End >= start && T.End <= end))
                    return false;
            }
            return true;
		}

        public override string ToString()
        {
            return Name;
        }
    }
}
