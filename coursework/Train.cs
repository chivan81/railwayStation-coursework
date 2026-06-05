using System;
using System.ComponentModel.DataAnnotations;

namespace coursework
{
    class Train
    {
        private string startStation;
        private string finalStation;
        private string departureTime;
        private string arrivalTime;
        private int carAmount;
        private int platform;
        private List<Carriage> carriages;

        public Train() : this(" ", " ", null, null, 1, 0) { }

        public string StartStation
        {
            get { return startStation; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва вокзалу не може бути порожньою!");
                startStation = value;
            }
        }
        public string FinalStation
        {
            get { return finalStation; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва вокзалу не може бути порожньою!");
                finalStation = value;
            }
        }
        public string DepartureTime
        {
            get { return departureTime; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Час відправлення не може бути порожнім!");
                departureTime = value;
            }
        }
        public string ArrivalTime
        {
            get { return arrivalTime; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Час прибуття не може бути порожнім!");
                arrivalTime = value;
            }
        }
        public int CarAmount
        {
            get { return carAmount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Вагонів не може бути менше 0");
                carAmount = value;
            }
        }
        public int Platform
        {
            get { return platform; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Невірне значення перону!");
                platform = value;
            }
        }

        public List<Carriage> Carriages => carriages;
        public void AddCarriages(int compartmentCount, int sittingCount)
        {
            for (int i = 0; i < compartmentCount; i++)
                carriages.Add(new CompartmentCar());
            for (int i = 0; i < sittingCount; i++)
                carriages.Add(new SittingCar());
        }

        public Train(string startStation, string finalStation, string departureTime, string arrivalTime, int carAmount, int platform)
        {
            StartStation = startStation;
            FinalStation = finalStation;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            CarAmount = carAmount;
            Platform = platform;
            carriages = new List<Carriage>();
        }

        public int compartmentCount()
        {
            return Carriages.Count(c => c is CompartmentCar);
        }
        public int sittingCount()
        {
            return Carriages.Count(s => s is SittingCar);
        }
        
        public string CarriagesCount()
        {
            
            return "------------------------------------------\n" +
                   $"Кількість вагонів різних типів: \n" +
                   $"Купе: | Плацкарт:\n" +
                   $"{compartmentCount()} | {sittingCount()}\n" +
                   "------------------------------------------\n";
        }

        public override string ToString()
        {
            return $"{StartStation} → {FinalStation} | Відправлення: {DepartureTime} | Прибуття: {ArrivalTime} | Перон: {Platform}";
        }
    }
}