using System;
using System.ComponentModel.DataAnnotations;

namespace coursework
{
    public abstract class Carriage
    {
        protected int totalPlaces;
        protected int freePlaces;
        protected string price;

        public int TotalPlaces() { return totalPlaces; }
        public int FreePlaces() { return freePlaces; }

        public void ReducePlace()
        {
            if (freePlaces > 0)
            {
                freePlaces--;
            }
            else
            {
                Console.WriteLine("Вільних місць немає!");
            }
                
        }

        public abstract string CarInfo();
    }
}