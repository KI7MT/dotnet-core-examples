/* 
 *  Author ......: Greg, Beam, KI7MT, <ki7mt@yahoo.com>
 *  Copyright ...: Copyright (C) 2017 GPLv3
 *  Level .......: Basic
 *  Target ......: netcoreapp2.0 Job.Listing.dll
 *  Description..: 1). Use Two Struct to generate job postings
 *                 2). Uses Random to generate Job ID's
 */
using System;

namespace Beam.Example.Job.Listing
{
    class Program
    {
        #region Struct: Address

        struct Address
        {
            public String submitName;
            public String submitStreet;
            public String submitCity;
            public String submitState;
            public int submitZip;
        };

        #endregion

        #region Struct: Jobs

        struct Jobs
        {
            public int jobID;
            public String jobName;
            public String jobQualifications;
            public double jobSalary;
            public String jobDescription;
            public Address submitAddress;
        };

        #endregion

        #region Main Method

        static void Main(string[] args)
        {
            // console title
            Console.Title = "Programmer Job Openings";

            // clear screen
            Console.Clear();

            // method variables
            Random random = new Random(); // for random job ID

            // data for job-1
            Jobs job1;
            job1.jobID = random.Next(100000, 999999);
            job1.jobName = "Computer Science Professor";
            job1.jobQualifications = "Master's in Computer Science";
            job1.jobSalary = 900;
            job1.jobDescription = "Teaching Introduction to .NET Core";
            job1.submitAddress.submitName = "CSharp University";
            job1.submitAddress.submitStreet = "123 Microsoft Way";
            job1.submitAddress.submitCity = "Redmond";
            job1.submitAddress.submitState = "WA";
            job1.submitAddress.submitZip = 12345;

            // data for job-2
            Jobs job2;
            job2.jobID = random.Next(100000, 999999);
            job2.jobName = "General Chemistry Professor";
            job2.jobQualifications = "Master's in Chemistry";
            job2.jobSalary = 650;
            job2.jobDescription = "Teaching General Chemistry, CHMY-121 and 122";
            job2.submitAddress.submitName = "CSharp University";
            job2.submitAddress.submitStreet = "123 Microsoft Way";
            job2.submitAddress.submitCity = "Redmond";
            job2.submitAddress.submitState = "WA";
            job2.submitAddress.submitZip = 12345;

            // create the array and assign Position Data to jobsList
            Jobs[] jobList = new Jobs[2];
            jobList[0] = job1;
            jobList[1] = job2;

            // print header
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(" CSharp University Employment Opportunities");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine();

            // foreach loop through and print each job posting from jobList
            foreach (Jobs thisJob in jobList)
            {
                Console.WriteLine(" JOB-ID: {0}", thisJob.jobID);
                Console.WriteLine("   Position .............: {0}", thisJob.jobName);
                Console.WriteLine("   Qualifications .......: {0}", thisJob.jobQualifications);
                Console.WriteLine("   Description ..........: {0}", thisJob.jobDescription);
                Console.WriteLine("   Salary ...............: {0:c}/per credit hour", thisJob.jobSalary);
                Console.WriteLine("   Mail Application To ..: {0}", thisJob.submitAddress.submitName);
                Console.WriteLine("                           {0} {1} {2}, {3}", thisJob.submitAddress.submitStreet,
                                                                                 thisJob.submitAddress.submitCity,
                                                                                 thisJob.submitAddress.submitState,
                                                                                 thisJob.submitAddress.submitZip);
                Console.WriteLine();
            }

            // print footer
            Console.WriteLine();
            Console.Write(" Press Any Key to Exit ... ");
            Console.ReadKey();
        }

        #endregion

    } // END - class Program

} // END - namespace Beam.Example.Job.Listing
