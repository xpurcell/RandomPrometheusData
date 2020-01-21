using System;
using Prometheus;
using System.Threading;
using System.Diagnostics;
using System.Net;

namespace rand_1_10
{
    class Program
    {

        private static readonly Gauge randomProm1 =
        Metrics.CreateGauge("random_data1", "random data1");

        private static readonly Gauge randomProm2 =
      Metrics.CreateGauge("random_data2", "random data2");

        private static readonly Gauge randomProm3 =
      Metrics.CreateGauge("random_data3", "random data3");


        private static readonly Gauge randomProm4 =
      Metrics.CreateGauge("random_data4", "random data4");


        private static readonly Gauge randomProm5 =
      Metrics.CreateGauge("random_data5", "random data5");

        static void Main(string[] args)
        {
            Console.WriteLine("Running");

            Console.WriteLine("running Test");
            //var server = new MetricServer(hostname: "localhost", port: 1245);
            //server.Start();
            var pusher = new MetricPusher(new MetricPusherOptions
            {
                Endpoint = "http://grafanaserver.westus2.cloudapp.azure.com:9091/metrics",
                Job = "123"
            });

            pusher.Start();


            Stopwatch clockStop;
            Console.WriteLine("starting clock");
            
            while (true)
            {
                clockStop = Stopwatch.StartNew(); // time how long our compariosn takes.
                Console.WriteLine("random data loop");
                Random random1 = new Random();
                int randomNumber1 = random1.Next(0, 100);
                randomProm1.Set(randomNumber1);

                Random random2 = new Random();
                int randomNumber2 = random2.Next(0, 100);
                randomProm2.Set(randomNumber2);

                Random random3 = new Random();
                int randomNumber3 = random3.Next(0, 100);
                randomProm3.Set(randomNumber3);

                Random random4 = new Random();
                int randomNumber4 = random4.Next(0, 100);
                randomProm3.Set(randomNumber4);

                Random random5 = new Random();
                int randomNumber5 = random5.Next(0, 100);
                randomProm3.Set(randomNumber5);

                while (clockStop.ElapsedMilliseconds / 1000 != 5)
                {

                }
                clockStop.Stop();
            }

            
        }
    }
}
