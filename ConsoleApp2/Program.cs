/*
 В одном из предыдущих практических заданий вы создавали класс "Магазин". Добавьте к уже созданному классу
информацию о площади магазина. Выполните нагрузку + (для увеличения площади магазина на указанный
размер), - (для уменьшения площади магазина на указанный
размер), == (проверка на равенство площадей магазинов), < и >
(проверка магазинов меньших или больших по площади),
!= и Equals. Используйте механизм свойств
полей класса
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Shop
    {
        private string Name { get; set; }
        private uint Area { get; set; }

        public Shop() { }

        public Shop(string name, uint area)
        {
            Name = name;
            Area = area;
        }

        public static Shop operator +(Shop mag, uint count)
        {
            return new Shop(mag.Name, mag.Area + count);
        }

        public static Shop operator -(Shop mag, uint count)
        {
            if (mag.Area - count < 0)
            {
                throw new Exception($"Невозможно уменьшить площадь больше чем на {mag.Area}");
            }

            return new Shop(mag.Name, mag.Area - count);
        }

        public static bool operator ==(Shop magL, Shop magR)
        {
            return magL.Area == magR.Area;
        }

        public static bool operator !=(Shop magL, Shop magR)
        {
            if (magL.Area != magR.Area) { return true; }
            return false;
        }

        public static bool operator >(Shop magL, Shop magR)
        {
            return magL.Area > magR.Area;
        }

        public static bool operator <(Shop magL, Shop magR)
        {
            return magL.Area < magR.Area;
        }

        public override bool Equals(object obj)
        {
            return Area == ((Shop)obj).Area;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Area: {Area}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop1 = new Shop("ATB", 1000);
            Shop shop2 = new Shop("Antoshka", 75);

            Console.WriteLine(shop1);
            Console.WriteLine(shop2);
            Console.WriteLine();

            Console.WriteLine("==");
            Console.WriteLine(shop1 == shop2);
            Console.WriteLine();

            Console.WriteLine("+ and -");
            shop1 = shop1 - 30;
            shop2 = shop2 + 30;
            Console.WriteLine(shop1);
            Console.WriteLine(shop2);
            Console.WriteLine();

            Console.WriteLine("!=");
            Console.WriteLine(shop1 != shop2);
            Console.WriteLine();

            Console.WriteLine(">");
            Console.WriteLine(shop1 > shop2);
            Console.WriteLine();
            Console.WriteLine("<");
            Console.WriteLine(shop1 < shop2);
            Console.WriteLine();

            Console.WriteLine("Equals");
            Console.WriteLine(shop1.Equals(shop2));

            Console.ReadLine();
        }
    }
}
