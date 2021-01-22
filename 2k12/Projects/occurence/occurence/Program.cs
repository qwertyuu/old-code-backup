using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace occurence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the sentense");
            var uInput = Console.ReadLine();
            Console.WriteLine("Write what you want to change");
            var toChange = Console.ReadLine();
            Console.WriteLine("Write what you want to change it with");
            var changeWith = Console.ReadLine();
            StringBuilder toChangeWithUpper = new StringBuilder();
            for (int i = 0; i < toChange.Length; i++)
            {
                if (i == 0)
                {
                    toChangeWithUpper.Append(toChange[i].ToString().ToUpper());
                }
                else
                {
                    toChangeWithUpper.Append(toChange[i]);
                }
            }
            Console.WriteLine(uInput.Replace(toChange, changeWith).Replace(toChangeWithUpper.ToString(), changeWith));
            Console.ReadLine();
        }
    }
}
