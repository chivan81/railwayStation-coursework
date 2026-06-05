using System;
using System.ComponentModel.DataAnnotations;

namespace coursework
{
    public class Ticket
    {
        private string selectedTrain;
        private string selectedCar;
        private int carNum;

        public string SelectedTrain
        {
            get { return selectedTrain; }
            set { selectedTrain = value; }
        }
        public string SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; }
        }
        public int CarNum
        {
            get { return  carNum; }
            set {  carNum = value; }
        }
        public Ticket(string selectedTrain, string selectedCar, int carNum)
        {
            SelectedTrain = selectedTrain;
            SelectedCar = selectedCar;
            CarNum = carNum;
        }

        public override string ToString()
        {
            return
                   $"Рейс: \n" +
                   SelectedTrain +
                   $"\nТип вагону | Номер вагону \n" +
                   $"{SelectedCar} | {CarNum} ";
        }
    }
}