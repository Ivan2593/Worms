using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Worms.Logics;
using static System.Threading.Tasks.Task;

namespace Worms.Hosts
{
    public class FoodHost
    {
        private int countFood = 0;
        private FoodLogic f;
        public WorldLogic world;

        public FoodHost()
        {
            f = new FoodLogic();
        }

        public void af()
        {
            /*for (int j = 0; j < world.FoodList.Count; j++)
            {
                Console.WriteLine(world.FoodList[j].getxy()[0]+" "+world.FoodList[j].getxy()[1]);
            }*/
            //Console.WriteLine(world);
            int[] mas = new int[2] {f.foodlist[countFood].Item1, f.foodlist[countFood].Item2};
            countFood++;
            world.AddFood(mas);
        }
        public void Start()
        {
            
            world.countonfood += (_, _) =>
            {
                af();
            };
            world.St();
            af();
        }
    }
}