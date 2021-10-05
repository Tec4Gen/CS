using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authomaton
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new StateMachine("input.json");
            a.Run("001010".ToArray());
            Console.ReadLine();

//            var a = new StateMachine
//            {
//                Alphabet = new List<string>
//                {
//                    "0",
//                    "1"
//                },
//                BeginState = "S1",
//                FinalState = "S4"
//,
//                States = new List<string>
//                {
//                    "S1",
//                    "S2",
//                    "S3",
//                    "S4",
//                },
//                Transitions = new List<Transition>
//                {
//                    new Transition 
//                    {
//                        StartState = "S1",
//                        EndState = "S2",
//                        Condition = '0'
//                    },
//                    new Transition
//                    {
//                        StartState = "S1",
//                        EndState = "S3",
//                        Condition = '1'
//                     },
//                    new Transition
//                    {
//                        StartState = "S2",
//                        EndState = "S4",
//                        Condition = '1'
//                    },
//                    new Transition
//                    {
//                        StartState = "S3",
//                        EndState = "S3",
//                        Condition = '1'
//                    },
//                    new Transition
//                    {
//                        StartState = "S3",
//                        EndState = "S4",
//                        Condition = '0'
//                    }
//                }
//            };

            //            var b = JsonConvert.SerializeObject(a);

            //            using (var file = new StreamWriter("input.json"))
            //            {
            //                file.WriteLine(b);
            //            }
        }
    }
}
