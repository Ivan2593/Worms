namespace Worms.Logics
{
    public class Food
    {
        public int life = 10;
        private int[] xy = new int[2];

        public Food(int[] mas)
        {
            xy[0] = mas[0];
            xy[1] = mas[1];
        }
        public void sublife()
        {
            life--;
        }

        public void setlife()
        {
            life = -1;
        }
        public int[] getxy()
        {
            return xy;
        }
        
    }
}