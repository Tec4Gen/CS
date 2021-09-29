using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            //var firstTask = new FirstTask();

            //firstTask.Run();

            var secondTask = new SecondTask();

            secondTask.Coder();
            secondTask.Decoder();
        }
    }
}
