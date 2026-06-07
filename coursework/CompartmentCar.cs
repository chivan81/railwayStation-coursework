using System;
using System.ComponentModel.DataAnnotations;

namespace coursework
{
    public class CompartmentCar : Carriage
    {
        public CompartmentCar()
        {
            totalPlaces = 40;
            freePlaces = 0;
            price = "800₴";
        }
        public override string CarInfo()
        {
            return $"Всього місць: {totalPlaces}\n" +
                   $"Вільних місць: {freePlaces}\n" +
                   $"Ціна квитка: {price}";
        }
    }
}
