using System;
using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;

namespace coursework
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Station Odessa = new Station("Одеський вокзал", 7);
            Train train1 = new Train("Одеса", "Київ", "11:30", "01:00", 15, 0);
            Train train2 = new Train("Одеса", "Львів", "21:15", "07:30", 11, 0);
            Train train3 = new Train("Одеса", "Вінниця", "6:30", "12:15", 10, 0);
            train1.AddCarriages(7, 8);
            train2.AddCarriages(5, 6);
            train3.AddCarriages(3, 7);
            Odessa.ArriveТrain(train1);
            Odessa.ArriveТrain(train2);
            Odessa.ArriveТrain(train3);

            bool isValid = false;
            bool isDispatcher = false;
            bool ticketBuy = false;

            while (!isValid)
            {
                Ticket ticket = null;
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Одеський вокзал (купити квиток)");
                Console.WriteLine("2. Панель диспетчера");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(Odessa);
                        int trainNum;
                        Console.WriteLine("Введіть номер потягу:");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out trainNum)
                                && trainNum >= 1 && trainNum <= Odessa.Trains.Count())
                            {
                                break;
                            }
                            Console.WriteLine("Не вірне значення номеру потягу, спробуйте ще раз");
                        }
                        Train selectedTrain = Odessa.Trains[trainNum - 1];
                        Console.Clear();

                        Console.WriteLine(selectedTrain);
                        Console.WriteLine(selectedTrain.CarriagesCount());
                        Console.WriteLine("Введіть тип вагону: \n 1. Купе\n 2. Плацкарт");
                        string choiseCar;
                        while (true)
                        {
                            choiseCar = Console.ReadLine();
                            if (choiseCar == "1" || choiseCar == "2")
                                break;
                            Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                        }
                        switch (choiseCar)
                        {
                            case "1":
                                Console.Clear();
                                int comNum;
                                Console.WriteLine($"Введіть номер вагону \n Всього: {selectedTrain.compartmentCount()}");
                                while (true)
                                {
                                    if (int.TryParse(Console.ReadLine(), out comNum)
                                        && comNum >= 1 && comNum <= selectedTrain.compartmentCount())
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Не вірне значення номеру вагону, спробуйте ще раз");
                                }
                                Carriage selectedCom = selectedTrain.Carriages[comNum - 1];
                                Console.WriteLine(selectedCom.CarInfo());
                                Console.WriteLine("Купити квиток?\n 1. Y  2. N");
                                char comTicket;
                                while (true)
                                {
                                    if (char.TryParse(Console.ReadLine(), out comTicket)
                                            && (comTicket == 'Y' || comTicket == 'N'))
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Спробуйте ще раз.");
                                }
                                switch (comTicket)
                                {
                                    case 'Y':
                                        if (selectedCom.FreePlaces() > 0)
                                        {
                                            Console.Clear();
                                            ticket = new Ticket(selectedTrain.ToString(), "Купе", comNum);
                                            selectedCom.ReducePlace();
                                            ticketBuy = true;
                                            break;
                                        }
                                        else
                                        {
                                            selectedCom.ReducePlace();
                                            break;
                                        }
                                    case 'N':
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                                        break;
                                }
                                break;
                            case "2":
                                Console.Clear();
                                int sitNum;
                                Console.WriteLine($"Введіть номер вагону \n Всього: {selectedTrain.sittingCount()}");
                                while (true)
                                {
                                    if (int.TryParse(Console.ReadLine(), out sitNum)
                                        && sitNum >= 1 && sitNum <= selectedTrain.sittingCount())
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Не вірне значення номеру вагону, спробуйте ще раз");
                                }
                                Carriage selectedSit = selectedTrain.Carriages[selectedTrain.compartmentCount() + sitNum - 1];
                                Console.WriteLine(selectedSit.CarInfo());
                                Console.WriteLine("Купити квиток?\n 1. Y  2. N");
                                char sitTicket;
                                while (true)
                                {
                                    if (char.TryParse(Console.ReadLine(), out sitTicket)
                                            && (sitTicket == 'Y' || sitTicket == 'N'))
                                    {
                                        break;
                                    }
                                    Console.WriteLine("Спробуйте ще раз.");
                                }
                                switch (sitTicket)
                                {
                                    case 'Y':
                                        if (selectedSit.FreePlaces() > 0)
                                        {
                                            Console.Clear();
                                            ticket = new Ticket(selectedTrain.ToString(), "Плацкарт", sitNum);
                                            selectedSit.ReducePlace();
                                            ticketBuy = true;
                                            break;
                                        }
                                        else
                                        {
                                            selectedSit.ReducePlace();
                                            break;
                                        }
                                    case 'N':
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                                        break;
                                }
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine(Odessa);
                        isDispatcher = true;
                        Console.WriteLine("Панель диспетчера:");
                        Console.WriteLine("1. Додати поїзд");
                        Console.WriteLine("2. Видалити поїзд");
                        string dispChoice;
                        while (true)
                        {
                            dispChoice = Console.ReadLine();
                            if (dispChoice == "1" || dispChoice == "2")
                            {
                                break;
                            }
                            Console.WriteLine("Спробуйте ще раз.");
                        }
                        switch (dispChoice)
                        {
                            case "1":
                                {
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Введіть початкову станцію:");
                                        string startSt = Console.ReadLine();

                                        Console.WriteLine("Введіть кінцеву станцію:");
                                        string endSt = Console.ReadLine();

                                        Console.WriteLine("Введіть час відправлення:");
                                        string depTime = Console.ReadLine();

                                        Console.WriteLine("Введіть час прибуття:");
                                        string arrTime = Console.ReadLine();

                                        int compCount;
                                        while (true)
                                        {
                                            Console.WriteLine("Введіть кількість купе:");
                                            if (int.TryParse(Console.ReadLine(), out compCount) && compCount >= 1)
                                                break;
                                            Console.WriteLine("Невірне значення!");
                                        }

                                        int sitCount;
                                        while (true)
                                        {
                                            Console.WriteLine("Введіть кількість плацкартів:");
                                            if (int.TryParse(Console.ReadLine(), out sitCount) && sitCount >= 1)
                                                break;
                                            Console.WriteLine("Невірне значення!");
                                        }

                                        Train newTrain = new Train(startSt, endSt, depTime, arrTime, 0, 0);
                                        newTrain.AddCarriages(compCount, sitCount);
                                        Odessa.ArriveТrain(newTrain);
                                        Console.WriteLine("Поїзд додано!");
                                        Console.WriteLine(Odessa);
                                        isValid = true;
                                        break;
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine($"Помилка: {ex.Message}");
                                        break;
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Помилка: введіть коректні дані!");
                                        break;
                                    }
                                }
                            case "2":
                                {
                                    Console.Clear();
                                    Console.WriteLine(Odessa);
                                    int delNum;
                                    while (true)
                                    {
                                        Console.WriteLine("Введіть номер поїзду, що відбув");
                                        if (int.TryParse(Console.ReadLine(), out delNum)
                                            && (delNum >= 1 && delNum <= Odessa.Trains.Count))
                                            break;
                                        Console.WriteLine("Спробуйте ще раз.");
                                    }
                                    Odessa.DepartureTrain(delNum);
                                    Console.WriteLine("Поїзд відбув. Перон звільнено.");
                                    Console.WriteLine(Odessa);
                                    isValid = true;
                                    break;
                                }
                        }

                        break;
                    default:
                        Console.WriteLine("Невірний вибір! Спробуйте ще раз.");
                        break;
                }
                Passanger passanger = null;
                bool validPass = false;
                if (ticket != null)
                {
                    while (ticketBuy == true)
                    {
                        try
                        {
                            Console.WriteLine("Введіть ПІБ:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введіть стать (M/F):");
                            char gender = char.Parse(Console.ReadLine());
                            Console.WriteLine("Введіть свій вік:");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введіть номер паспорту:");
                            string id = Console.ReadLine();

                            passanger = new Passanger(name, gender, age, id);

                            ticketBuy = false;
                            break;
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Помилка: введіть коректне число!");
                        }
                    }
                    Console.Clear();
                    Console.WriteLine(passanger);
                    Console.WriteLine(ticket);
                }
                else if (!isDispatcher) { Console.WriteLine("Покупку скасовано."); }
                Console.WriteLine("\nБажаєте купити ще квиток? (Y/N)");
                char again;
                while (true)
                {
                    if (char.TryParse(Console.ReadLine(), out again)
                        && (again == 'Y' || again == 'N'))
                        break;
                    Console.WriteLine("Спробуйте ще раз.");
                }
                if (again == 'Y')
                    isValid = false;
                else
                    isValid = true;
            }
        }
    }
}
