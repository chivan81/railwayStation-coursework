using System;
using System.ComponentModel.DataAnnotations;

namespace coursework
{
    class Station
    {
        private string name;
        private int platformAmount;
        private bool[] platforms;
        private List<Train> trains;

        public Station() : this(" ", 1) { }
        public List<Train> Trains
        {
            get { return trains; }
        }
        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва вокзалу не може бути порожньою!");
                name = value;
            }
        }

        public int PlatformAmount
        {
            get { return platformAmount; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Перонів не може бути менше одного");
                platformAmount = value;
            }
        }

        public Station(string name, int platformAmount)
        {
            Name = name;
            PlatformAmount = platformAmount;
            platforms = new bool[platformAmount];
            trains = new List<Train>();
        }  

        public void ArriveТrain(Train train)
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                if (platforms[i] == false)
                {
                    platforms[i] = true;
                    train.Platform = i + 1;
                    trains.Add(train);
                    return;
                }
            }
            Console.WriteLine("Всі перони зайняті!");
        }
        public void DepartureTrain(int delNum)
        {
            Train train = trains[delNum - 1];
            platforms[train.Platform - 1] = false;
            trains.RemoveAt(delNum - 1);
        }

        private string TrainsInfo()
        {
            string result = "";
            for (int i = 0; i < trains.Count; i++)
                result += $"{i + 1}. {trains[i]}\n";
            return result;
        }

        public override string ToString()
        {
            return $"Табло\n" +
                   "------------------------------------------\n" +
                   TrainsInfo() +
                   "------------------------------------------\n";
        }
    }
}