using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLab
{
    public class IdNumber
    {
        public int number;
        public IdNumber(int n)
        {
            number = n;
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is IdNumber nom)
                return this.number == nom.number;
            else
                return false;
        }
    }
    public class InitClass:IInit, ICloneable
    {
        string word;
        protected static Random rnd = new Random();
        public IdNumber id;
        public string Word
        {
            get { return word; } set { word = value; } 
        }
        public InitClass()
        {
            Word = "JustWord";
            id = new IdNumber(1);
        }
        public InitClass(string word, int num)
        {
            Word = word;
            id = new IdNumber(num);
        }
            
        public void Init()
        {
            Word = "";
            for (int i = 0; i <= rnd.Next(2, 10); i++)
            {
                Word += (char)rnd.Next(65, 91);
            }
            id = new IdNumber(rnd.Next(2, 50));
        }

        public override string ToString()
        {
            return id.number+$": Слово {Word}";
        }

        public object Clone()
        {
            return new InitClass(this.Word, this.id.number);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
