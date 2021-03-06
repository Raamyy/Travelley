﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelley.Back_End
{
    public abstract class TripType
    {
        protected string name;
        public int minNumberOfSeats;
        public int maxNumberOfSeats;

        virtual public bool InRange(int NumberOfSeats)
        {
            return NumberOfSeats >= minNumberOfSeats && NumberOfSeats <= maxNumberOfSeats;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class Family: TripType
    {
        public Family()
        {
            name = "Family";
            minNumberOfSeats = 3;
            maxNumberOfSeats = int.MaxValue;
        }
    }

    public class Couple: TripType
    {
        public Couple()
        {
            name = "Couple";
            minNumberOfSeats = 2;
            maxNumberOfSeats = 2;
        }
    }

    public class General: TripType
    {
        public General()
        {
            name = "General";
            minNumberOfSeats = 1;
            maxNumberOfSeats = int.MaxValue;
        }
    }

    public class Friends: TripType
    {
        public Friends()
        {
            name = "Friends";
            minNumberOfSeats = 2;
            maxNumberOfSeats = int.MaxValue;
        }
    }

    public class Lonely: TripType
    {
        public Lonely()
        {
            name = "Lonely";
            minNumberOfSeats = 1;
            maxNumberOfSeats = 1;
        }
    } 
}
