using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using CarRentalServies.Areas.Admin.Controllers;

namespace CarRentalServies.Models
{
    public class SchedulerServies : IHostedService,IDisposable
    {
        private int executionCount = 0;

        private System.Threading.Timer _timerNotification;

        public IConfiguration _iconfiguration;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;

        public SchedulerServies(IServiceScopeFactory serviceScopeFactory, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IConfiguration iconfiguration)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _env = env;
            _iconfiguration = iconfiguration;
        }

        public Task StartAsync(CancellationToken stoppigToken)
        {
            _timerNotification = new Timer(RunJob, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        private void RunJob(object  state)
        {
            using (var scrope = _serviceScopeFactory.CreateScope())
            {
                try
                {
                    Console.WriteLine("Hello Task Is Running");
                    AdminController controller = new AdminController();
                    controller.RemoveFromAndToDateFromDatabase();

                }
                catch (Exception ex)
                {

                }
                Interlocked.Increment(ref executionCount);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timerNotification?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timerNotification?.Dispose();
        }
    }
}
