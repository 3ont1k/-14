//**************************************************************************
//* Практическая работа № 14                                               *
//* Выполнил: Складаный А.А., группа 2ИСПд                                 *
//* Задание:  Организация и использование функций                          *
//**************************************************************************
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace работа_12
{
    internal class Program
    {
        struct Dealership
        {
            string model;
            string firm;
            int year;
            string equipment;
            int price;
            public Dealership(string model, string firm, int year, string equipment, int price)
            {
                this.model = model;
                this.firm = firm;
                this.year = year;
                this.equipment = equipment;
                this.price = price;
            }
            public void PrintInfoObjStruct()
            {
                Console.WriteLine($"\n информация:\n" +
                    $"модель = {model}" +
                    $"фирма = {firm}" +
                    $"год выпуска = {year}" +
                    $"комплектация = {equipment}" +
                    $"цена = {price}");
            }
            static void HandleError(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Произошла ошибка: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }
            static void Main(string[] args)
            {
                try
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Clear();
                        Console.WriteLine("здраствуйте! Вас приветсвует дилерский центр  " +
                            "\"Купил нисан, возись с ним сам\" +" +
                            " Введите интересующую сколько моделей авто вас интересует");
                        int n = Convert.ToInt32(Console.ReadLine());
                        for( int i = 0; i < n; i++ )
                        {
                            Console.Write("\tВведите модель авто: ");
                            string model = Console.ReadLine();
                            Console.Write("\tВведите фирму авто: ");
                            string firm = Console.ReadLine();
                            Console.Write("\tВведите год выпуска авто: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\tВведите комплектиацию авто: ");
                            string equipment = Console.ReadLine();
                            Console.Write("\tВведите цену авто: ");
                            int price = Convert.ToInt32(Console.ReadLine());
                            Dealership dealership = new Dealership(model, firm, year, equipment, price);
                        }
                       





                        Console.WriteLine("\nХотите повторить программу?\n\n\t\t\t 1 = да, другая цифра = нет.");
                        int povtor = Convert.ToInt32(Console.ReadLine());
                        if (povtor != 1) break;

                    }
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
            }
        }
    }
}
