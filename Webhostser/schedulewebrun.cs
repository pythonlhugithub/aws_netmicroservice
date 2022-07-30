using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Webhostser
{
    public class schedulewebrun : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {

           // var _timer = new Timer(Console.Write("timer"),null, TimeSpan.Zero, TimeSpan.FromHours(24));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
