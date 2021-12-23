using System;
using System.Collections.Generic;
using Xunit;
using Worms.Logics;

namespace UITestProject1
{
    public class AppTests
    {
        [Theory]
        [InlineData( new int[2] { 0,-1 } ) ]
        public void go_to_empty(int[] coord)
        { 
            var world = new WorldLogic();
            world.wname = "1";
            world.St();
            bool ans = world.CheckTheField(coord);
            Assert.True(ans);
        }
        
        [Theory]
        [InlineData( new int[2] { 0,-1 } ) ]
        public void go_to_food(int[] coord)
        { 
            var world = new WorldLogic();
            world.wname = "1";
            world.St();
            world.AddFood(coord);
            bool ans = world.CheckTheField(coord);
            world.WormList1.Add(new Worm(coord,10,"1"));
            world.EndDay();
            Assert.True(ans);
            for (int i = 0; i < world.WormList.Count; i++) {
                Assert.Equal(19,world.WormList[i].life);
            }
        }
        
        [Theory]
        [InlineData( new int[2] { 0,-1 } ) ]
        public void go_to_worm(int[] coord)
        { 
            var world = new WorldLogic();
            world.wname = "1";
            world.St();
            world.wname = "2";
            world.WormList.Add(new Worm(coord, 10, world.wname));
            bool ans = world.CheckTheField(coord);
            Assert.False(ans);
        }
        
        [Theory]
        [InlineData( new int[2] { 0,-1 } ) ]
        public void good_reproduction(int[] coord)
        { 
            var world = new WorldLogic();
            var wlogic = new WormLogic();
            world.wname = "1";
            world.St();
            world.AddFood(coord);
            world.WormList[0].pluslife();
            for (int i = 0; i < world.WormList.Count; i++)
            {
                var xy = wlogic.move(world.FoodList, world.WormList1, world.WormList[i]);
                if (xy.Length == 2)
                {
                    world.WormList1.Add(new Worm(xy, world.WormList[i].life, world.WormList[i].name));
                }
                else
                {
                    var name = world.WormName();
                    world.WormList[i].minlife();
                    var coord1 = new int[2] {xy[0], xy[1]};
                    world.WormList1.Add(new Worm(world.WormList[i].getxy(), world.WormList[i].life, world.WormList[i].name));
                    world.WormList1.Add(new Worm(coord1, 10, name));
                }
            }
            world.EndDay();
            Assert.Equal(2,world.WormList.Count);
        }
        
        [Theory]
        [InlineData( new int[2] { 0,-1 } ) ]
        public void bad_reproduction(int[] coord)
        { 
            var world = new WorldLogic();
            var wlogic = new WormLogic();
            world.wname = "1";
            world.St();
            world.AddFood(coord);
            for (int i = 0; i < world.WormList.Count; i++)
            {
                var xy = wlogic.move(world.FoodList, world.WormList1, world.WormList[i]);
                if (xy.Length == 2)
                {
                    world.WormList1.Add(new Worm(xy, world.WormList[i].life, world.WormList[i].name));
                }
                else
                {
                    var name = world.WormName();
                    world.WormList[i].minlife();
                    var coord1 = new int[2] {xy[0], xy[1]};
                    world.WormList1.Add(new Worm(world.WormList[i].getxy(), world.WormList[i].life, world.WormList[i].name));
                    world.WormList1.Add(new Worm(coord1, 10, name));
                }
            }
            world.EndDay();
            Assert.Equal(1,world.WormList.Count);
        }
        
        [Theory]
        [InlineData( 100 ) ]
        public void unique_name(int day)
        { 
            var names = new NameLogic();
            var namelist = new List<String>();
            for (int i = 0; i < day; i++)
            {
                namelist.Add(names.setname());
            }
            bool ans = true;
            for (int i = 0; i < day; i++)
            {
                for (int j = 0; j < day; j++)
                {
                    if (i != j && namelist[i] == namelist[j])
                    {
                        ans = false;
                        break;
                    }
                }
            }
            Assert.True(ans);
        }
        
        [Theory]
        [InlineData( 100 ) ]
        public void unique_food(int day)
        { 
            var foods = new FoodLogic();
            bool ans = true;
            for (int i = 0; i < foods.foodlist.Count-10; i++)
            {
                for (int j = i+1; j < i+10; j++)
                {
                    if (foods.foodlist[i].Item1 == foods.foodlist[j].Item1 && foods.foodlist[i].Item2 == foods.foodlist[j].Item2)
                    {
                        ans = false;
                        break;
                    }
                }
            }
            Assert.True(ans);
        }
        
        [Theory]
        [InlineData( new int[2] { 4,3 } ) ]
        public void logic_worm(int[] coord)
        { 
            var world = new WorldLogic();
            var wlogic = new WormLogic();
            world.wname = "1";
            world.St();
            world.AddFood(coord);
            int k = 0;
            while (world.WormList[0].getX() != coord[0] || world.WormList[0].getY() != coord[1])
            {
                var xy = wlogic.move(world.FoodList, world.WormList1, world.WormList[0]);
                world.WormList1.Add(new Worm(xy, world.WormList[0].life, world.WormList[0].name));
                world.EndDay();
                world.St();
                k++;
            }
            Assert.Equal(4,world.WormList[0].getX());
            Assert.Equal(3,world.WormList[0].getY());
            Assert.Equal(7,k);
        }
        
        
    }
}