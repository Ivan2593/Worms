using System;
using System.Collections.Generic;

namespace Worms.Logics
{
    public class FoodLogic
    {
        private Random r = new Random();
        public List<(int,int)> foodlist = new List<(int, int)>();
        public FoodLogic()
        {
            while (foodlist.Count < 100)
            {
                int add = 1;
                var mas = getFood();
                for (int i = foodlist.Count - 1; i > foodlist.Count - 11; i--)
                {
                    if (i < 0 || add != 1)
                    {
                        break;
                    }
                    if (mas[0] == foodlist[i].Item1 && mas[1] == foodlist[i].Item2)
                    {
                        add = 0;
                    }
                }

                if (add == 1)
                {
                    foodlist.Add((mas[0], mas[1]));
                }
            }
        }
        public int[] getFood()
        {
            var mas = new int[2];
            mas[0] = NextNormal();
            mas[1] = NextNormal();
            return mas;
        }
        private int NextNormal(double mu = 0, double sigma = 5)
        {
            var u1 = r.NextDouble();
            var u2 = r.NextDouble();
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            var randNormal = mu + sigma * randStdNormal;
                return (int)Math.Round(randNormal);
        }
    }
}