namespace DIapp.Services
{
    using System;

    public class RandomCounter : ICounter
    {
        static Random Rnd = new Random();
        private int value;
        public RandomCounter()
        {
            value = Rnd.Next(0, 1000);
        }

        public int Value
        {
            get => value;
        }
    }
}
