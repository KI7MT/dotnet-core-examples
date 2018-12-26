/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2018 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 MLSListing.dll
 *  Description..: 1). Use struct to add to listings array
 *                 2). Uses Random to generate an MLS ID
 */
using System;

namespace Beam.Example.Intermediate.MLS.Listing
{
    class Program
    {
        #region MLS Listing Struct
        struct House
        {
            public int mlsID;
            public String numberOfBedrooms;
            public String numberOfBathrooms;
            public int squareFeet;
            public double listPrice;
        };

        #endregion

        #region Main Method

        static void Main(string[] args)
        {
            // console title
            Console.Title = "MLS House Listings";

            // clear screen
            Console.Clear();

            // method variables
            Random random = new Random();
            int listCount = 0;

            // first house
            House house1;
            house1.mlsID = random.Next(100000, 999999);
            house1.numberOfBedrooms = "2";
            house1.numberOfBathrooms = "1";
            house1.squareFeet = 1100;
            house1.listPrice = 95000;

            // second house
            House house2;
            house2.mlsID = random.Next(100000, 999999);
            house2.numberOfBedrooms = "3";
            house2.numberOfBathrooms = "2";
            house2.squareFeet = 3000;
            house2.listPrice = 219000;

            // third house
            House house3;
            house3.mlsID = random.Next(100000, 999999);
            house3.numberOfBedrooms = "4";
            house3.numberOfBathrooms = "3";
            house3.squareFeet = 4500;
            house3.listPrice = 320000;

            // create an array and assign House Data to houseListings
            House[] mlsListing = new House[3];
            mlsListing[0] = house1;
            mlsListing[1] = house2;
            mlsListing[2] = house3;

            // print header
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(" Houses For Sale by MLS Listing");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            // start foreach loop - print each house struct from houseListings
            foreach (House thisHouse in mlsListing)
            {
               listCount++;
               Console.WriteLine(" MLS-ID: {0}", thisHouse.mlsID);
               Console.WriteLine("   Bedrooms .........: {0}", thisHouse.numberOfBedrooms);
               Console.WriteLine("   Bathrooms ........: {0}", thisHouse.numberOfBathrooms);
               Console.WriteLine("   Square Feet ......: {0:N0} sqft", thisHouse.squareFeet);
               Console.WriteLine("   Price ............: {0:c}", thisHouse.listPrice);
               Console.WriteLine();
            }

            // print footer
            Console.WriteLine();
        }

        #endregion

    } // end class Program

} // end namespace Beam.Example.Intermediate.MLS.Listing