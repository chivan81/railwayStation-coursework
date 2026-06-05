using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace coursework
{
    public class Passanger
    {
        private string fullName;
        private char gender;
        private int age;
        private string id;

        public string FullName
        {
            get { return fullName; }
            set
            {
                int spaces = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == ' ')
                        spaces += 1;
                }
                if (spaces < 2)
                    throw new ArgumentException("Неправильно введено повне ім'я");
                fullName = value;
            }
        }
        public char Gender
        {
            get { return gender; }
            set
            {
                char lower = char.ToLower(value);
                if (lower != 'm' && lower != 'f')
                    throw new ArgumentException("Неправильно введено гендер");
                gender = lower;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 14)
                    throw new ArgumentException("Ви не можете купити білет якщо вам менше 14ти");
                age = value;
            }
        }
        public string Id
        {
            get { return id; }
            set
            {
                if (value.ToString().Length != 9)
                    throw new ArgumentException("Номер паспорту введено неправильно.");
                id = value;
            }
        }

        public Passanger(string fullName, char gender, int age, string id)
        {
            FullName = fullName;
            Gender = gender;
            Age = age;
            Id  = id;
        }

        public override string ToString()
        {
            string stat = Gender == 'm' ? "чоловік" : "жінка";
            return $"Ваш білет:\n" +
                   "------------------------------------------\n" +
                   $"ПІБ: {FullName}\n" +
                   $"Стать: {stat}\n" +
                   $"Вік: {Age} \n" +
                   $"Номер паспорту:  {Id} \n" +
                   "------------------------------------------\n";
                   
        }
    }
}