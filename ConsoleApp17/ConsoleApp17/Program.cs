//***********************************************************************/
//* Практическая работа № 17                                            */
//* Выполнила: Холодкова И.А., группа 2ИСП                              */
//* Задание: Разработка класса: объявление, создание экземпляров класса.*/
//***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_17
{
    internal class Program
    {
        public static void Error(string message, ConsoleColor cc) // оформление исключений
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        class Country // объявление класса 
        {
            private double human;
            public double Human
            {
                get { return human; } // возвращаем значение свойства
                set { human = value; } // устанавливаем новое значение свойства
            }
            private double PopulationSize() // закрытый метод класса, расчёт численности населения
            {
                double ps = Math.Pow(human, 4) + human * 100;
                return Math.Round(ps, 4);
            }
            private void GetInfo() // закрытый метод, вывод значений
            {
                Console.WriteLine($"Начальная численность населения: {human}");
                Console.WriteLine($"Численность населения через 20 лет: {PopulationSize()}");
            }
            public void SetInfo() // открытый метод, инициализация значений
            {
                Console.Write("Задайте начальную численность население страны: ");
                human = Double.Parse(Console.ReadLine());
                GetInfo();
            }
            ~Country() // деструктор
            {
                Console.WriteLine("\nДеструктор сработал!");
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.Write("Здравствуйте!\nПрактическая работа № 17.\n");
                Console.WriteLine("Расчёт численности населения за 20 лет.");
                Console.WriteLine();
                int interest = 0;
                for (; ; )
                {
                    interest++;
                    Country obj1 = new Country(); // создание экземпляра класса
                    obj1.SetInfo(); // вызов метода SetInfo() класса Country
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Хотите выйти из программы?");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Если ДА, то нажмите на esc.");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Если НЕТ, нажмите на enter.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ConsoleKeyInfo btn = Console.ReadKey();
                    if (btn.Key == ConsoleKey.Escape)
                        break;
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Error("Что-то пошло не так. Ошибка: " + ex.Message, ConsoleColor.Red);
            }
        }
    }
}