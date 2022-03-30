using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenthLab;

namespace EleventhLab
{
    internal class GenCollection<T> : List<T>  
    {
        
        static Random x = new Random();


        //создание массива
        public static List<Commodity> CollectionCreate(int len)
        {
            List<Commodity> arr = new List<Commodity>(len);
            for (int i = 0; i < len; i++)
            {
                RandomAdd(arr);
            }
            return arr;
        }
        //добавление случайного элемента
        public static void RandomAdd(List<Commodity> arr)
        {
            int rndgen = x.Next(1, 5);
            switch (rndgen)
            {
                case 1:
                    {
                        Commodity temp = new Commodity();
                        temp.Init();
                        arr.Add(temp);
                        break;
                    }
                case 2:
                    {
                        Commodity temp = new Product();
                        temp.Init();
                        arr.Add(temp);
                        break;
                    }
                case 3:
                    {
                        Commodity temp = new MilkProduct();
                        temp.Init();
                        arr.Add(temp);
                        break;
                    }
                case 4:
                    {
                        Commodity temp = new Toy();
                        temp.Init();
                        arr.Add(temp);
                        break;
                    }
            }
        }

        //удаление элемента
        public static void SimpleRemove(List<Commodity> arr, int indx)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (arr.Count == 0) Console.WriteLine("Collection is empty");
            else
            {
            if (indx - 1 >= arr.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    arr.Remove(arr[indx - 1]); 
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Удаление завершено");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //вывод массива
        public static void Show(List<Commodity> arr)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Печать коллекции:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (Commodity elem in arr)
            {
                elem.Show();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static List<Commodity> SimpleClone(List<Commodity> arr, bool deep)
        {
            List<Commodity> clonearr = new List<Commodity>(arr.Count);
            if (!deep)
            {
                //clonearr = arr.Clone();
            }
            else
            {
                //глубокое клонирование
            }
            return clonearr;
        }

        //запросы

        //количество игрушек 
        public static int NumberOfToys(List<Commodity> arr)
        {
            int toyCount = 0;
            foreach (Commodity t in arr)
            {
                Toy tempt = t as Toy;
                if (tempt != null) toyCount++;
            }
            return toyCount;
        }

        //печать игрушек
        public static void ToyShow(List<Commodity> arr)
        {
            foreach (Commodity t in arr)
            {
                Toy tempt = t as Toy;
                if (tempt != null)
                {
                    t.Show();
                    Console.WriteLine();
                }

            }
        }

        //количество элементов
        public static int CurrentLength(List<Commodity> arr)
        {
            return arr.Count;
        }

        //сортировка и поиск элемента

        public static List<Commodity> SearchingNSort(List<Commodity> arr)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            //сортировка через
            arr.Sort();
            Console.WriteLine("Отсортированный массив:");
            Show(arr);

            //поиск в списке
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Введите название товара");
            string comName = "";
            bool isCorrectName = false;
            do
            {
                comName = Console.ReadLine();
                if (comName == string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Введена пустая строка.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else isCorrectName = true;
            } while (!isCorrectName);
            Console.WriteLine("Введите производителя товара");
            string comProd = "";
            bool isCorrectProd = false;
            do
            {
                comProd = Console.ReadLine();
                if (comProd == string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Введена пустая строка.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else isCorrectProd = true;
            } while (!isCorrectProd);

            //сам поиск
            bool isFind = false;
            int indx = 0;
            for (int i = 0; i < arr.Count; i++)
            {

                Commodity elem = arr[i];
                if (elem.Name == comName && elem.Producer == comProd)
                {
                    isFind = true;
                    indx = i + 1;
                    break;
                }
            }
            if (isFind) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Объект найден, номер: " + indx); }
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Такого объекта не обнаружено."); }
            Console.ForegroundColor = ConsoleColor.White;

            return arr;
        }
    }
}
