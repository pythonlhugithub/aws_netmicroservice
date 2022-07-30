using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Webhostser
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _cServiceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory cServiceScopeFactory)
        {
            _logger = logger;
            _cServiceScopeFactory = cServiceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using (var _scope= _cServiceScopeFactory.CreateScope()) {
                    var config = _scope.ServiceProvider.GetRequiredService<ILogger>();
                    await Task.Delay(120000,stoppingToken);

                }
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
