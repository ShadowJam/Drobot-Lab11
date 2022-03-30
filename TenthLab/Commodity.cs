using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLab
{
    public class Commodity:IInit, IComparable //товар
    {
        string name; //название
        string producer; //производитель
        int rub;//цена
        int kop;
        protected static Random rnd = new Random();

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
            }
        }

        public int Rub //свойство
        {
            get
            {
                return rub;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка: количество рублей не может быть отрицательным");
                    rub = 0;
                }
                else
                    rub = value;
            }
        }

        public int Kop
        {
            get
            {
                return kop;
            }
            set
            {
                if (value < 0)
                {
                    if (rub > 0)
                    {
                        rub -= 1;
                        kop = 100 + value;
                    }
                    else
                        Console.WriteLine("Ошибка: количество копеек не может быть отрицательным");

                }
                else
                {
                    if (value > 99)
                    {
                        rub += value / 100;
                        kop = value % 100;
                    }
                    else
                        kop = value;
                }
            }
        }
        public Commodity()
        {
            Name = "";
            Producer = "";
            Rub = 0;
            Kop = 0;
        }

        public Commodity(string name, string producer, int rub, int kop)
        {
            Name = name;
            Producer = producer;
            Rub = rub;
            Kop = kop;
        }
        public void WhoAmI()
        {
            Console.WriteLine("Я товар");
        }

        public virtual void Show()
        {
            Console.WriteLine($"Название товара: {Name}, производитель: {Producer}, стоимость: {Rub}руб. {Kop}коп.");
        }

        public virtual void Init()
        {
            Name = "";
            Producer = "";
            for (int i=0; i<=rnd.Next(2,10); i++)
            {
                Name += (char)rnd.Next(65, 91);
            }
            for (int i = 0; i <= rnd.Next(2, 12); i++)
            {
                Producer += (char)rnd.Next(65, 91);
            }
            Rub = rnd.Next(10, 1000);
            kop = rnd.Next(0, 100);
        }

        public override string ToString()
        {
            return $"Название товара: {Name}, производитель: {Producer}, стоимость: {Rub}руб. {Kop}коп.";
        }

        public int CompareTo(object obj)
        {
            Commodity com = obj as Commodity;
            return String.Compare(this.Name, com.Name);
        }
        ////запрос на поиск наибольшего по стоимости товара
        //public static Commodity MostExpensiveCommodity(Commodity[] arr) 
        //{
        //    int maxrub = Int32.MinValue;
        //    int maxkop = -1;

        //    int tempid = 0;
        //    int id = tempid;
        //    foreach (Commodity elem in arr)
        //    {
        //        if (maxrub == elem.Rub)
        //        {
        //            if (maxkop < elem.Kop)
        //            {
        //                maxrub = elem.Rub;
        //                maxkop = elem.Kop;
        //                id = tempid;
        //            }
        //        }
        //        else if (maxrub < elem.Rub)
        //        {
        //            maxrub = elem.Rub;
        //            maxkop = elem.Kop;
        //            id = tempid;
        //        }
        //        tempid++;
        //    }
        //    return arr[id];
        //}
        ////запрос на поиск наименьшего по стоимости товара
        //public static Commodity LessExpensiveCommodity(Commodity[] arr)
        //{
        //    int minrub = Int32.MaxValue;
        //    int minkop = 100;

        //    int tempid = 0;
        //    int id = tempid;
        //    foreach (Commodity elem in arr)
        //    {
        //        if (minrub == elem.Rub)
        //        {
        //            if (minkop > elem.Kop)
        //            {
        //                minrub = elem.Rub;
        //                minkop = elem.Kop;
        //                id = tempid;
        //            }
        //        }
        //        else if (minrub > elem.Rub)
        //        {
        //            minrub = elem.Rub;
        //            minkop = elem.Kop;
        //            id = tempid;
        //        }
        //        tempid++;
        //    }
        //    return arr[id];
        //}
    }
}
