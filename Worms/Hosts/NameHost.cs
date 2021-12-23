using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Worms.Logics;
using static System.Threading.Tasks.Task;

namespace Worms.Hosts
{
    public class NameHost
    {
        public WorldLogic world;
        private NameLogic nlogic = new NameLogic();
        public NameHost()
        {
        }
        public void Start()
        {
            world.wname = nlogic.setname();
            world.nextname += (_, _) =>
            {
                world.wname = nlogic.setname();
            };
        }
    }
}