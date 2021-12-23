using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Worms.Logics;
using static System.Threading.Tasks.Task;

namespace Worms.Hosts
{
    public class LogHost
    {
        public WorldLogic world;
        private LogLogic l = new LogLogic();
        public LogHost()
        {
        }

        public void log()
        {
            String food = "Food:[";
            for (int j = 0; j < world.FoodList.Count; j++)
            {
                food = food + "(" +world.FoodList[j].getxy()[0]+","+world.FoodList[j].getxy()[1]+")";
                if (j < world.FoodList.Count - 1)
                {
                    food = food + ",";
                }
            }
            food = food + "]";
            for (int i = 0; i < world.WormList.Count; i++)
            {
                //Console.WriteLine("Days:("+world.day+"),Worms:["+world.WormList[i].name+"("+world.WormList[i].getX()+","+world.WormList[i].getY()+")]");
                l.wr("Days:("+world.day+"),Worms:["+world.WormList[i].name+"("+world.WormList[i].getX()+","+world.WormList[i].getY()+")],"+food);
            }
        }
        public void Start()
        {
            world.log += (_, _) =>
            {
                
                log();
               
                /*if (world.day == 20)
                {
                    l.e();
                }*/
                world.StDay();
            };
            world.death += (_, _) =>
            {
                l.wr("Worms = "+world.WormList.Count);
                l.e();
            };
        }

    }
}