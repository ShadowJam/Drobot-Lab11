using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLab
{
    public class Product:Commodity //продукт
    {
        // срок_годности
        int day;
        //содержание угледов жиров и белков
        int fats;
        int carbohydrates;
        int proteins;

        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value < 0)
                    day = 1;
                else day = value;
            }
        }

        public int Fats
        {
            get
            {
                return fats;
            }
            set
            {
                if (value < 0)
                    fats = 1; 
                else fats = value;
            }
        }

        public int Carbohydrates
        {
            get
            {
                return carbohydrates;
            }
            set
            {
                if (value < 0)
                    carbohydrates = 1;
                else carbohydrates = value;
            }
        }

        public int Proteins
        {
            get
            {
                return proteins;
            }
            set
            {
                if (value < 0)
                    proteins = 1;
                else proteins = value;
            }
        }

        public Product()
        {
            Day = 0;
            Fats = 0;
            Carbohydrates = 0;
            Proteins = 0;
        }

        public Product(string name, string producer, int rub, int kop, int day, int fats, int carbo, int proteins)
            : base(name, producer, rub, kop)
        {    
            Day = day;
            Fats = fats;
            Carbohydrates = carbo;
            Proteins = proteins;
        }
        public new void WhoAmI()
        {
            Console.WriteLine("Я продукт");
        }

        public override void Show()
        {
            Console.WriteLine($"Название товара: {Name}, производитель: {Producer}, стоимость: {Rub}руб. {Kop}коп.");
            Console.WriteLine($"Срок годности: {Day}, жиры: {Fats}, белки: {Proteins}, углеводы: {Carbohydrates}");
        }

        public static Product LongestDateLessFat(Commodity[] arr)
        {
            int maxdate = Int32.MinValue;
            int minfat = Int32.MaxValue;

            Product ttt = new Product();
            int tempid = 0;
            int id = tempid;
            foreach (Commodity elem in arr)
            {
                ttt = elem as Product;
                if (ttt != null)
                {
                    Product p = (Product)elem;
                    if (maxdate <= p.Day && minfat >= p.Fats)
                    {
                        maxdate = p.Day;
                        minfat = p.Fats;
                        id = tempid;
                    }
                }
                tempid++;
            }
            return (Product)arr[id];
        }

        public override void Init()
        {
            base.Init();
            Day = rnd.Next(1, 366);
            Fats = rnd.Next(1, 1501);
            Carbohydrates = rnd.Next(1, 1501);
            Proteins = rnd.Next(1, 1501);
        }
        public override string ToString()
        {
            return base.ToString() + $"\nСрок годности: {Day}, жиры: {Fats}, белки: {Proteins}, углеводы: {Carbohydrates}";
        }
    }
}
