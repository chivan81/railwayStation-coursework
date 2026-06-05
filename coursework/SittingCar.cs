using System;
using System.ComponentModel.DataAnnotations;

namespace coursework
{
    public class SittingCar : Carriage
    {
        public SittingCar()
        {
            totalPlaces = 60;
            freePlaces = 60;
            price = "400₴";
        }
        public override string CarInfo()
        {
            return $"Всього місць: {totalPlaces}\n" +
                   $"Вільних місць: {freePlaces}\n" +
                   $"Ціна квитка: {price}";
        }
    }
}
