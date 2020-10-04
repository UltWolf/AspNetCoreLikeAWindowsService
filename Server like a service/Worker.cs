using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Server_like_a_service
{
    public class Worker : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                using (FileStream fs = new FileStream("append.txt",FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using(StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("Worker are working: "+ DateTime.Now);
                    }
                }

                Thread.Sleep(300);
            }
        }

        public  Task StopAsync(CancellationToken cancellationToken)
        {
            using (FileStream fs = new FileStream("append.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Worker are stop working at: " + DateTime.Now);
                }
            }
            return Task.FromResult(0);
        }
    }
}