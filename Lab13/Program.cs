using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    internal class Program
    {
        /*Задан класс Building, который описывает здание. Класс содержит следующие элементы:

        адрес здания;
        длина здания;
        ширина здания;
        высота здания.
        В классе Building нужно реализовать следующие методы:

        конструктор с 4 параметрами;
        свойства get/set для доступа к полям класса;
        метод Print(), который выводит информацию о здании.
        Разработать класс MultiBuilding, который наследует возможности класса Building и добавляет поле этажность.
        В классе MultiBuilding реализовать следующие элементы:

        конструктор с 5 параметрами – реализует вызов конструктора базового класса;
        свойство get/set доступа к внутреннему полю класса;
        метод Print(), который обращается к методу Print() базового класса Building для вывода информации о всех полях класса.
        Класс MultiBuilding сделать таким, что не может быть унаследован.*/
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите адрес здания ");
                string adress = Console.ReadLine();
                Console.Write("Введите длину ");
                double length = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите ширину ");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите высоту ");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите количество этажей ");
                uint levels = Convert.ToUInt16(Console.ReadLine());
            
            
                Building b = new Building(adress, length, width, height);
                Building mb = new MultiBuilding(adress, length, width, height, levels);
                Console.WriteLine("\nДанные здания без этажности:");
                b.Print();
                Console.WriteLine("\nДанные здания c учетом этажности:");
                mb.Print();
            }
            catch(Exception ex)
            { Console.WriteLine(ex.Message); }
            Console.ReadKey();
        }

        class Building
        {
            public string Adress { get; set; }
            double length;
            double width;
            double height;

            public double Length
            {
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Длина здания должна быть больше 0");
                    }
                    length = value;
                }
                get
                {
                    return length;
                }

            }
            public double Width
            {
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Ширина здания должна быть больше 0");
                    }
                    width = value;
                }
                get
                {
                    return width;
                }

            }
            public double Height
            {
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentOutOfRangeException("Высота здания должна быть больше 0");
                    }
                    height = value;
                }
                get
                {
                    return height;
                }

            }

            public Building (string Adress, double length, double width, double height )
            {
                this.Adress = Adress;
                Length = length;
                Width = width;    
                Height = height;
            }

            public virtual void Print()
            {
                Console.WriteLine("Здание по адресу {0} имеет длину {1} м, ширину {2} м, высоту {3} м", Adress, Length, Width, Height);
            }
        }

        sealed class MultiBuilding : Building
        {
            uint levels;
            public uint Levels
            {
                set
                {
                    if (value < 1)
                    {
                        throw new ArgumentOutOfRangeException("Количество этажей здания должно быть 1 или более");
                    }
                    levels = value;
                }
                get
                {
                    return levels;
                }

            }
            public MultiBuilding(string Adress, double length, double width, double height, uint levels)
                : base(Adress, length, width, height)
            {
                Levels = levels;
            }

            public override void Print() 
            {
                base.Print();
                Console.WriteLine("Количество этажей в здании {0}",levels);
            }
                
        }
    }

}
