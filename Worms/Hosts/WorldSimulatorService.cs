using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Worms.Logics;
using static System.Threading.Tasks.Task;

namespace Worms.Hosts
{
    public class WorldSimulatorService: IHostedService
    {
        private WorldLogic world;
        private FoodHost fh;
        private WormsHost wh;
        private LogHost lh;
        private NameHost nh;

        public WorldSimulatorService(FoodHost fh, WormsHost wh, LogHost lh, NameHost nh, WorldLogic _world,  IHostApplicationLifetime _appLifetime)
        {
            world = _world;
            this.fh = fh;
            this.wh = wh;
            this.lh = lh;
            this.nh = nh;
            fh.world = _world;
            wh.world = _world;
            lh.world = _world;
            nh.world = _world;
            world.death += (_,_) =>
                        {
                            _appLifetime.StopApplication();
                        };
        }
        
        private void RunAsync()
        {
            nh.Start();
            lh.Start();
            wh.Start();
            fh.Start();
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