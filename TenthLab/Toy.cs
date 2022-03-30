using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLab
{
    public class Toy:Commodity //игрушка
    {
        //тип игрушки
        string toy_type;
        //возрастная категория
        string age_group;
        string[] TTypes = {"Мягкая", "Развивающая", "Антистресс", "Коллекционная", "Для активного отдыха" };
        string[] TAge = { "0+", "3-11лет", "12+", "15+", "99+" };

        public string ToyType
        {
            get { return toy_type; }
            set { toy_type = value; }
        }

        public string AgeGroup
        {
            get { return age_group; }
            set { age_group = value; }
        }

        public Toy()
        {
            AgeGroup = "";
            ToyType = "";
        }

        public Toy(string name, string producer, int rub, int kop, string type, string age)
            :base(name, producer, rub, kop)
        {
            ToyType = type;
            AgeGroup = age;
        }

        public new void WhoAmI()
        {
            Console.WriteLine("Я игрушка");
        }

        public override void Show()
        {
            Console.WriteLine($"Название товара: {Name}, производитель: {Producer}, стоимость: {Rub}руб. {Kop}коп.");
            Console.WriteLine($"Тип игрушки: {ToyType}, Возрастная группа: {AgeGroup}");
        }

        //запрос на поиск наибольшей по стоимости игрушки
        public static Toy MaxExpensiveToy(Commodity[] arr)
        {
            int maxrub = Int32.MinValue;
            int maxkop = -1;

            Toy ttt = new Toy();
            int tempid = 0;
            int id = tempid;
            foreach (Commodity elem in arr)
            {
                ttt = elem as Toy;
                if (ttt != null)
                {
                    if (maxrub == elem.Rub)
                    {
                        if (maxkop < elem.Kop)
                        {
                            maxrub = elem.Rub;
                            maxkop = elem.Kop;
                            id = tempid;
                        }
                    }
                    else if (maxrub < elem.Rub)
                    {
                        maxrub = elem.Rub;
                        maxkop = elem.Kop;
                        id = tempid;
                    }
                }
                tempid++;
            }
            return (Toy)arr[id];
        }

        //запрос на поиск наименьшей по стоимости игрушки
        public static Toy MinExpensiveToy(Commodity[] arr)
        {
            int maxrub = Int32.MaxValue;
            int maxkop = 100;

            Toy ttt = new Toy();
            int tempid = 0;
            int id = tempid;
            foreach (Commodity elem in arr)
            {
                ttt = elem as Toy;
                if (ttt != null)
                {
                    if (maxrub == elem.Rub)
                    {
                        if (maxkop > elem.Kop)
                        {
                            maxrub = elem.Rub;
                            maxkop = elem.Kop;
                            id = tempid;
                        }
                    }
                    else if (maxrub > elem.Rub)
                    {
                        maxrub = elem.Rub;
                        maxkop = elem.Kop;
                        id = tempid;
                    }
                }
                tempid++;
            }
            return (Toy)arr[id];
        }
        public override void Init()
        {
            base.Init();
            ToyType = TTypes[rnd.Next(TTypes.Length)];
            AgeGroup = TAge[rnd.Next(TAge.Length)];
        }

        public override string ToString()
        {
            return base.ToString() + $"\nТип игрушки: {ToyType}, Возрастная группа: {AgeGroup}";
        }
    }
}
