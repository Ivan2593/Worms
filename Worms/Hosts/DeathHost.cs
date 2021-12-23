using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Worms.Logics;
using static System.Threading.Tasks.Task;

namespace Worms.Hosts
{
    public class DeathHost: IHostedService
    {
        private readonly WorldLogic world;
        private IHostApplicationLifetime appLifetime;
        
        public DeathHost(WorldLogic _world, IHostApplicationLifetime _appLifetime)
        {
            world = _world;
            appLifetime = _appLifetime;
        }

        private void RunAsync()
        {
            world.death += (_,_) =>
            {
                appLifetime.StopApplication();
            };
            
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Run(RunAsync, cancellationToken);
            return CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return CompletedTask;
        }
    }
}