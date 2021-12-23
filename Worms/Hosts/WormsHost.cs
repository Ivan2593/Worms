using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Worms.Logics;
using static System.Threading.Tasks.Task;

namespace Worms.Hosts
{
    public class WormsHost
    {
        public WorldLogic world;
        private WormLogic wlogic = new WormLogic();
        public WormsHost()
        {
        }
        public void Start()
        {
            world.wormwork += (_, _) =>
            {
                /*for (int i = 0; i < world.foodlist.Count; i++)
                {
                    Console.WriteLine(world.foodlist[i].getxy()[0]+" "+world.foodlist[i].getxy()[1]);
                }*/
                //Console.WriteLine("up "+world.FoodList.Count);
                for (int i = 0; i < world.WormList.Count; i++)
                {
                    int[] xy = wlogic.move(world.FoodList, world.WormList1, world.WormList[i]);
                    if (xy.Length == 2)
                    {
                        world.WormList1.Add(new Worm(xy, world.WormList[i].life, world.WormList[i].name));
                    }
                    else
                    {
                        string name = world.WormName();
                        world.WormList[i].minlife();
                        int[] coord = new int[2] {xy[0], xy[1]};
                        world.WormList1.Add(new Worm(world.WormList[i].getxy(), world.WormList[i].life, world.WormList[i].name));
                        world.WormList1.Add(new Worm(coord, 10, name));
                    }
                }
                //Console.WriteLine("up "+world.FoodList.Count);
                world.EndDay();
            };
        }
    }
}