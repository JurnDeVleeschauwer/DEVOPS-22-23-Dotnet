using Bogus;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Domain.Statistics.Datapoints
{

    public class DataPointsFaker : Faker<DataPoint>
    {

        //singleton zodat hij niet steeds een nieuwe faker object moet creëren per virtual machine (memory heap)
        private static DataPointsFaker _instance;

        public static DataPointsFaker Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DataPointsFaker();
                }
                return _instance;
            }
        }

        public int Tick { get; set; }

        public Hardware Hardware { get { return _hardware; } set { _hardware = value; Tick = 0; } }
        private Hardware _hardware;


        public DataPointsFaker()
        {
        }

        public static Dictionary<DateTime, Hardware> GetFakeStatistics(DateTime StartTime, DateTime EndTime)
        {
            Dictionary<DateTime, Hardware> _data = new();

            var delta = EndTime - StartTime;
            for (int i = 0; i <= delta.Days; i++)
            {
                _data.Add(StartTime.AddDays(i), GenerateRandomHardWareUsage());
            }
            
            return _data;

        }



        public static Hardware GenerateRandomHardWareUsage()
        {
            int m = (int)Math.Ceiling(GetInt(0, 50));
            int s = (int)Math.Ceiling(GetInt(0, 50));
            int c = (int)Math.Ceiling(GetInt(0, 50));

            return new Hardware(m, s,  c);
        }

        private static double GetInt(int min, int max)
        {
            return new Random().NextInt64(min, max);

        }


    }
}
