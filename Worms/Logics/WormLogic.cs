using System;
using System.Collections.Generic;

namespace Worms.Logics
{
    public class WormLogic
    {
        public int[] move(List<Food> lf, List<Worm> lw, Worm w)
        {
            int[] xy;
            if (w.life >= 20)
            {
                int up = 0;
                int down = 0;
                int left = 0;
                int right = 0;
                xy = new int[3] {w.getX(), w.getY(), 0};
                for (int i = 0; i < lw.Count; i++)
                {
                    if (lw[i].getX() == w.getX() + 1 && lw[i].getY() == w.getY())
                    {
                        right=1;
                    }
                    if (lw[i].getX() == w.getX() - 1 && lw[i].getY() == w.getY())
                    {
                        left=1;
                    }
                    if (lw[i].getX() == w.getX() && lw[i].getY() == w.getY()+1)
                    {
                        up=1;
                    }
                    if (lw[i].getX() == w.getX() && lw[i].getY() == w.getY()-1)
                    {
                        down=1;
                    }
                }

                if (right == 0)
                {
                    xy[0] = w.getX() + 1;
                    xy[1] = w.getY();
                }
                else
                {
                    if (left == 0)
                    {
                        xy[0] = w.getX() - 1;
                        xy[1] = w.getY();
                    }
                    else
                    {
                        if (up == 0)
                        {
                            xy[0] = w.getX();
                            xy[1] = w.getY()+1;
                        }
                        else
                        {
                            if (down == 0)
                            {
                                xy[0] = w.getX();
                                xy[1] = w.getY()-1;
                            }
                            else
                            {
                                xy = new int[2] {w.getX(), w.getY()};
                            }
                        }
                    }
                }
            }
            else
            {
                xy = new int[2];
                if (lf.Count == 0)
                {
                    xy = w.getxy();
                }
                else
                {
                    int[] min = lf[0].getxy();
                    xy = w.getxy();
                    for (int i = 0; i < lf.Count; i++)
                    {
                        if (Math.Abs(lf[i].getxy()[0] - xy[0]) + Math.Abs(lf[i].getxy()[1] - xy[1]) < Math.Abs(min[0] - xy[0]) + Math.Abs(min[1] - xy[1]))
                        {
                            min = lf[i].getxy();
                        }
                    }

                    if (xy[0] > min[0])
                    {
                        xy[0]--;
                    }
                    else
                    {
                        if (xy[0] < min[0])
                        {
                            xy[0]++;
                        }
                        else
                        {
                            if (xy[1] > min[1])
                            {
                                xy[1]--;
                            }
                            else
                            {
                                if (xy[1] < min[1])
                                {
                                    xy[1]++;
                                }
                            }
                        }
                    }

                    for (int i = 1; i < lw.Count; i++)
                    {
                        if (lw[i].getxy() == xy)
                        {
                            xy = w.getxy();
                        }
                    }
                }
            }

            return xy;
        }
    }
}