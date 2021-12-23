namespace Worms.Logics
{
    public class Worm
    {
        public int life = 10;
        private int[] xy = new int[2] {0, 0};
        public string name;

        public Worm(int[] mas, int l, string _name)
        {
            xy[0] = mas[0];
            xy[1] = mas[1];
            life = l;
            name = _name;
        }
        public void sublife()
        {
            life--;
        }

        public void pluslife()
        {
            life = life + 10;
        }
        
        public void minlife()
        {
            life = life - 10;
        }

        public void setxy(int[] _xy)
        {
            xy[0] = _xy[0];
            xy[1] = _xy[1];
        }
        
        public int[] getxy()
        {
            return xy;
        }

        public void setname(string _name)
        {
            name = _name;
        }
        
        public int getX()
        {
            return xy[0];
        }
        
        public int getY()
        {
            return xy[1];
        }
        
    }
}