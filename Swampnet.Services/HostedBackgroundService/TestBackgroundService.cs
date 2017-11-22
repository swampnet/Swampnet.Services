using Swampnet.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Serilog;
using System.Diagnostics;

namespace Swampnet.Services.HostedBackgroundService
{
    public class TestBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log.Debug("TestBackgroundService is starting");

            stoppingToken.Register(() =>
                    Log.Debug($"TestBackgroundService background task is stopping. (stoppingToken)"));

            while (!stoppingToken.IsCancellationRequested)
            {
                Debug.WriteLine("TestBackgroundService doing background work.");

                await Task.Delay(30000);
            }

            Log.Debug($"TestBackgroundService background task is stopping.");

            await Task.CompletedTask;
        }
    }
}
