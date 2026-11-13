//**************************************************************************
//* Практическая работа № 14                                               *
//* Выполнил: Складаный А.А., группа 2ИСПд                                 *
//* Задание:  Разработка программ с использованием структур                *
//**************************************************************************
using System;

namespace работа_12
{
    internal class Program
    {
        struct Dealership
        {
            private string model;
            private string firm;
            private int year;
            private string equipment;
            private int price;
            public void InfoAboutObjStruct()
            {
                Console.Write("\tВведите модель авто: ");
                model = Console.ReadLine();
                Console.Write("\tВведите фирму авто: ");
                firm = Console.ReadLine();
                Console.Write("\tВведите год выпуска авто: ");
                year = Convert.ToInt32(Console.ReadLine());
                Console.Write("\tВведите комплектацию авто: ");
                equipment = Console.ReadLine();
                Console.Write("\tВведите цену авто: ");
                price = Convert.ToInt32(Console.ReadLine());
            }
            public void PrintInfoObjStruct()
            {
                Console.WriteLine($"\n Информация об автомобиле:\n" +
                    $"\tМодель = {model}\n" +
                    $"\tФирма = {firm}\n" +
                    $"\tГод выпуска = {year}\n" +
                    $"\tКомплектация = {equipment}\n" +
                    $"\tЦена = {price} руб.");
            }
            public bool FindObjStruct(string searchModel)
            {
                return model != null && model.ToLower() == searchModel.ToLower();
            }
            public int GetPrice()
            {
                return price;
            }
        }

        static void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nПроизошла ошибка: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Clear();
                    Console.WriteLine("Здравствуйте! Вас приветствует дилерский центр " +
                        "\"Купил ниссан, возись с ним сам\" " +
                        "\nВведите сколько моделей авто вас интересует:");
                    int n = Convert.ToInt32(Console.ReadLine());

                    if (n <= 0)
                    {
                        throw new Exception("Количество автомобилей должно быть больше нуля.");
                    }
                    Dealership[] cars = new Dealership[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"\n--- Автомобиль №{i + 1} ---");
                        cars[i].InfoAboutObjStruct();
                    }
                    Console.WriteLine("\n================ ВСЕ АВТОМОБИЛИ ================");
                    for (int i = 0; i < n; i++)
                    {
                        cars[i].PrintInfoObjStruct();
                    }
                    Console.Write("\nВведите модель автомобиля для поиска: ");
                    string searchModel = Console.ReadLine();
                    Console.WriteLine($"\n================ РЕЗУЛЬТАТЫ ПОИСКА «{searchModel}» ================");
                    bool found = false;
                    for (int i = 0; i < n; i++)
                    {
                        if (cars[i].FindObjStruct(searchModel))
                        {
                            cars[i].PrintInfoObjStruct();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Автомобиль с такой моделью не найден.");
                    }
                    Console.WriteLine("\n================ НАИБОЛЕЕ ДОРОГОЙ АВТОМОБИЛЬ ================");
                    int maxPrice = cars[0].GetPrice();
                    for (int i = 1; i < n; i++)
                    {
                        if (cars[i].GetPrice() > maxPrice)
                        {
                            maxPrice = cars[i].GetPrice();
                        }
                    }
                    for (int i = 0; i < n; i++)
                    {
                        if (cars[i].GetPrice() == maxPrice)
                        {
                            cars[i].PrintInfoObjStruct();
                        }
                    }
                }
                catch (FormatException ex)
                {
                    HandleError(ex);
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }

                Console.WriteLine("\nХотите повторить программу?\n\n\t\t\t 1 = да, другая цифра = нет.");
                string repeatInput = Console.ReadLine();
                if (repeatInput != "1") break;
            }
        }
    }
}
