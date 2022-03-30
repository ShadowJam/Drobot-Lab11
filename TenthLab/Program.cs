using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void DemoOne()
        {

            Commodity a1 = new Commodity("Утюг", "Данон", 4, -1);
            Commodity a2 = new Product("Хлэб", "ЧувашскаяПекарня", 223, 0, 10, 100, 30, 22);
            Commodity a3 = new MilkProduct("Кифир", "Нытвенский Молокозавод", 223, 0, 10, 100, 30, 22, 2.8, false);
            Commodity a4 = new Toy("Жираф", "биб", 10, 35, "мягкая игрушка", "99-100 лет");
            
            Commodity[] lst = { a1, a2, a3, a4, };
            foreach (Commodity commodity in lst)
            {
                commodity.Show();
                Console.WriteLine();
                commodity.WhoAmI();
                Console.WriteLine();
            }
            
        }
        public static void DemoTwo()
        {
            Commodity t1 = new Toy("Носорог", "ИП Михал Палыч", 1222, -1, "развивающая", "1000+ лет");
            Commodity t2 = new Toy("Конструктор", "Игры для детей", 42988942, -1, "развивающая", "5+ лет");
            Commodity t3 = new Toy("Коллектор", "Банк Казахстана", 1, -1, "коллекционная", "25+ лет");
            Commodity m1 = new MilkProduct("Чудо", "Нестле", 40, 0, 10, 100, 30, 22, 2.8, false);
            Commodity m2 = new MilkProduct("Йогурт", "ИП Игорь Михалыч", 10, 0, 10, 100, 30, 22, 2.8, true);
            Commodity m3 = new MilkProduct("Бифидок", "ОАО Арбуз", 25, 0, 10, 100, 30, 22, 2.8, true);
            Commodity p1 = new Product("бумажный пакет", "пятерочка", 10, 0, 12222, 10, 30, 22);
            Commodity p2 = new Product("мясо", "Узбекский мясокомбинат", 20, 0, 4, 10, 30, 22);
            Commodity p3 = new Product("Арбуз", "ИП Ахмед Абромович", 20, 0, 23, 1, 30, 22);
            Commodity[] lst = { t1, t2, t3, m1, m2, m3, p1, p2, p3 };
            Toy a5 = Toy.MaxExpensiveToy(lst); //запрос на самую дорогую игрушку
            a5.Show();

            Console.WriteLine();
            MilkProduct m4 = MilkProduct.NoLactoseMinExpensiveMilk(lst); //запрос на дешевый безлактозный мол продукт
            m4.Show();
            Console.WriteLine();
            Product p4 = Product.LongestDateLessFat(lst); //запрос на продукт с мин содержанием жира
                                                          //и самым большим сроком годности
            p4.Show();
            Console.WriteLine();
        }
        public static void DemoThree()
        {
            //массив для тестирования функционала IInit
            IInit[] iarr = new IInit[8];
            for (int i = 0; i < 5; i++)
            {
                if (i % 3 == 0)
                {
                    Toy t = new Toy();
                    t.Init();
                    iarr[i] = t;
                }
                else
                {
                    if (i % 3 == 1)
                    {
                        Product pr = new Product();
                        pr.Init();
                        iarr[i] = pr;
                    }
                    else if (i % 3 == 2)
                    {
                        MilkProduct mp = new MilkProduct();
                        mp.Init();
                        iarr[i] = mp;
                    }
                }
            }
            for (int i = 5; i<8; i++)
            {
                InitClass ic = new InitClass();
                ic.Init();
                iarr[i] = ic;
            }
            //вывод
            Commodity[] comarr = new Commodity[5];
            foreach (IInit x in iarr)
                Console.WriteLine(x+"\n");
            Console.WriteLine("===========================================================");
            //массив для тестирования сортировки IComparable
            for (int i = 0; i < 5; i++)
            {
                if (i % 3 == 0)
                {
                    Toy t = new Toy();
                    t.Init();
                    comarr[i] = t;
                }
                else
                {
                    if (i % 3 == 1)
                    {
                        Product pr = new Product();
                        pr.Init();
                        comarr[i] = pr;
                    }
                    else if (i % 3 == 2)
                    {
                        MilkProduct mp = new MilkProduct();
                        mp.Init();
                        comarr[i] = mp;
                    }
                }
            }
            //вывод
            Console.WriteLine("Неотсортированный массив:");
            foreach (IInit x in comarr)
                Console.WriteLine(x + "\n");
            Console.WriteLine("===========================================================");
            //сортировка
            Array.Sort(comarr);
            Console.WriteLine("Отсортированный по имени массив:");
            foreach (IInit x in comarr)
                Console.WriteLine(x + "\n");
            Console.WriteLine("===========================================================");
            //сортировка ICompare
            Array.Sort(comarr, new SortByPrice());
            Console.WriteLine("Отсортированный по цене массив:");
            //вывод
            foreach (IInit x in comarr)
                Console.WriteLine(x + "\n");
            Console.WriteLine("===========================================================");
            //клонирование
            InitClass[] arrInit = {(InitClass)iarr[5], (InitClass)iarr[6], (InitClass)iarr[7] };
            InitClass ic1 = new InitClass(arrInit[0].Word, arrInit[0].id.number);
            InitClass ic2 = (InitClass)arrInit[0].Clone();
            InitClass ic3 = (InitClass)arrInit[0].ShallowCopy();

            arrInit[0].Word = arrInit[0].Word + "Clone";
            arrInit[0].id.number = 200;
            Console.WriteLine("Клонирование");
            Console.WriteLine(ic1);
            Console.WriteLine(ic2);
            Console.WriteLine(ic3);
            Console.WriteLine(arrInit[0]);
        }
        private static void Menu()//меню
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Пожалуйста выберите демо");
                Console.WriteLine("1. Демо первого задания");
                Console.WriteLine("2. Демо второго задания");
                Console.WriteLine("3. Демо третьего задания");
                Console.WriteLine("4. Выход");
                bool ok = false;
                int menu_choise;
                do
                {
                    string input = Console.ReadLine();
                    ok = Int32.TryParse(input, out menu_choise) && (1 <= menu_choise) && (menu_choise <= 4);
                    if (!ok) Console.WriteLine("Ошибка! выберите опцию меню!");
                } while (!ok);
                Console.WriteLine(" ");
                switch (menu_choise)
                {
                    case (1):
                        DemoOne();
                        break;
                    case (2):
                        DemoTwo();
                        break;
                    case (3):
                        DemoThree();
                        break;
                    case (4):
                        exit = true;
                        break;
                }
            } while (!exit);
        }
    }
}
