using System;
using System.Collections.Generic;

namespace Worms.Logics
{
    public class WorldLogic
    {
        public List<Food> FoodList = new List<Food>();
        public List<Worm> WormList = new List<Worm>();
        public List<Worm> WormList1 = new List<Worm>();
        public event EventHandler<int> countonfood;
        public event EventHandler<int> log;
        public event EventHandler<int> wormwork;
        public event EventHandler<int> death;
        public event EventHandler<int> nextname;
        public int day = 0;
        public string wname = "1";
        public void St()
        {
            day++;
            int[] val = new int[2] {0, 0};
            WormList.Add(new Worm(val, 10, wname));
        }

        public void StDay()
        {
            if (day < 100)
            {
                day++;
                if (countonfood != null)
                    countonfood(this, day);

            }
            else
            {
                if (death != null)
                    death(this, day);
            }
        }

        public void EndDay()
        {
            List<Food> FoodList1 = new List<Food>();
            for (int i = 0; i < WormList1.Count; i++)
            {
                for (int j = 0; j < FoodList.Count; j++)
                {
                    if (WormList1[i].getxy()[0] == FoodList[j].getxy()[0] && WormList1[i].getxy()[1] == FoodList[j].getxy()[1])
                    {
                            WormList1[i].pluslife();
                            FoodList[j].setlife();
                    }
                }
            }
            for (int j = 0; j < FoodList.Count; j++)
            {
                FoodList[j].sublife();
                if (FoodList[j].life>0)
                {
                    FoodList1.Add(FoodList[j]);
                }
            }
            FoodList = new List<Food>();
            FoodList = FoodList1;
            WormList = new List<Worm>();
            for (int i = 0; i < WormList1.Count; i++)
            {
                WormList1[i].sublife();
                if (WormList1[i].life > 0)
                {
                    WormList.Add(WormList1[i]);
                }
            }
            WormList1 = new List<Worm>();
            if (log != null)
                log(this, day);
        }
        public void AddFood(int[] mas)
        {
            if (CheckTheField(mas) == false)
            {
                for (int i = 0; i < WormList.Count; i++)
                {
                    if (mas[0] == WormList[i].getX() && mas[1] == WormList[i].getY())
                    {
                        WormList[i].pluslife();
                    }
                }
            }
            else
            {
                FoodList.Add(new Food(mas));
            }
            //Console.WriteLine("down"+FoodList.Count);
            if (wormwork != null)
                wormwork(this, day);
        }

        public string WormName()
        {
            if (nextname != null)
                nextname(this, day);
            return wname;
        }

        public bool CheckTheField(int[] coord)
        {
            bool ans=true;
            for (int i = 0; i < WormList.Count; i++)
            {
                if (coord[0] == WormList[i].getX() && coord[1] == WormList[i].getY())
                {
                    ans = false;
                    break;
                }
            }

            return ans;
        }
        
    }
}