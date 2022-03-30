using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLab
{
    public class MilkProduct : Product //молочный продукт
    {
        double fat_content; //жирность
        bool lactose; //лактозное/безлактозное
        

        public Product Baselink 
        {
            get 
            {
                return (Product)this; 
            } 
        }

        public double Fat_content
        {
            get
            {
                return fat_content;
            }
            set
            {
                if (value < 0)
                    fat_content = 1;
                else fat_content = value;
            }
        }

        public bool Lactose
        {
            get
            {
                return lactose;
            }
            set
            {
                lactose = value;
            }
        }

        public MilkProduct()
        {
            Fat_content = 0;
            Lactose = true;
        }

        public MilkProduct(string name, string producer, int rub, int kop, int day, int fats, int carbo, int proteins, double fatcont, bool lact)
            : base(name, producer, rub, kop, day, fats, carbo, proteins)
        {
            Fat_content = fatcont;
            Lactose = lact;
        }
        public new void WhoAmI()
        {
            Console.WriteLine("Я молочный продукт");
        }

        public override void Show()
        {
            Console.WriteLine($"Название товара: {Name}, производитель: {Producer}, стоимость: {Rub}руб. {Kop}коп.");
            Console.WriteLine($"Срок годности: {Day}, жиры: {Fats}, белки: {Proteins}, углеводы: {Carbohydrates}");
            if (lactose)
                Console.WriteLine($"Содержание жира: {fat_content}%, содержание лактозы: да");
            else
                Console.WriteLine($"Содержание жира: {fat_content}%, содержание лактозы: нет");
        }

        public static MilkProduct NoLactoseMinExpensiveMilk(Commodity[] arr)
        {
            int maxrub = Int32.MaxValue;
            int maxkop = 100;

            MilkProduct ttt = new MilkProduct();
            int tempid = 0;
            int id = tempid;
            foreach (Commodity elem in arr)
            {
                ttt = elem as MilkProduct;
                if (ttt != null)
                {
                    MilkProduct mp = (MilkProduct)elem;
                    if (mp.Lactose == false)
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
                }
                tempid++;
            }
            return (MilkProduct)arr[id];
        }
        public override void Init()
        {
            base.Init();
            Fat_content = Math.Round(rnd.NextDouble() * 20, 1);
            Lactose = rnd.Next(2) != 0;
        }

        public override string ToString()
        {
            if (lactose)
                return base.ToString() + $"\nСодержание жира: {fat_content}%, содержание лактозы: да";
            else
                return base.ToString() + $"\nСодержание жира: {fat_content}%, содержание лактозы: нет";

        }
    }
}
