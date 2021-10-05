using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutomatonSecond
{
    class Program
    {
        static void Main(string[] args)
        {

            //var fist = StateMachine.CreateMachineByJson("inputFist.json");
            //fist.Run("01");
            //Console.ReadLine();

            var fist = StateMachine.CreateMachineByJson("inputSecond.json");
            fist.Run("00");
            Console.ReadLine();
            #region First
            //var a = new StateMachine
            //{
            //    Alphabet = new List<string>
            //    {
            //        "0",
            //        "1"
            //    },
            //    BeginState = "S1",
            //    FinalStates = new List<string>
            //    {
            //        "S4",
            //        "S6"
            //    },
            //    States = new List<string>
            //    {
            //        "S1",
            //        "S2",
            //        "S3",
            //        "S4",
            //        "S5",
            //        "S6",
            //    },
            //    Transitions = new List<Transition>
            //    {
            //        new Transition
            //        {
            //            StartState = "S1",
            //            EndState = "S2",
            //            Symbol = "0"
            //        },
            //        new Transition
            //        {
            //            StartState = "S1",
            //            EndState = "S3",
            //            Symbol = "1"
            //         },
            //        new Transition
            //        {
            //            StartState = "S1",
            //            EndState = "S5",
            //            Symbol = "0"
            //         },
            //        new Transition
            //        {
            //            StartState = "S2",
            //            EndState = "S4",
            //            Symbol = "1"
            //        },
            //        new Transition
            //        {
            //            StartState = "S3",
            //            EndState = "S3",
            //            Symbol = "1"
            //        },
            //        new Transition
            //        {
            //            StartState = "S3",
            //            EndState = "S4",
            //            Symbol = "0"
            //        },
            //        new Transition
            //        {
            //            StartState = "S5",
            //            EndState = "S6",
            //            Symbol = "0"
            //        }
            //    }
            //};

            //var b = JsonConvert.SerializeObject(a);

            //using (var file = new StreamWriter("inputFist.json"))
            //{
            //    file.WriteLine(b);
            //}
            #endregion

            #region Second
            var a = new StateMachine
            {
                Alphabet = new List<string>
                {
                    "0",
                    "1"
                },
                BeginState = "S1",
                FinalStates = new List<string>
                {
                    "S3",
                    "S6"
                },
                States = new List<string>
                {
                    "S1",
                    "S2",
                    "S3",
                    "S4",
                    "S5",
                    "S6",
                },
                Transitions = new List<Transition>
                {
                    new Transition
                    {
                        StartState = "S1",
                        EndState = "S2",
                        Symbol = "1"
                    },
                    new Transition
                    {
                        StartState = "S1",
                        EndState = "S4",
                        Symbol = ""
                     },
                    new Transition
                    {
                        StartState = "S2",
                        EndState = "S3",
                        Symbol = "1"
                    },
                    new Transition
                    {
                        StartState = "S3",
                        EndState = "S1",
                        Symbol = "1"
                    },
                    new Transition
                    {
                        StartState = "S4",
                        EndState = "S5",
                        Symbol = ""
                    },
                    new Transition
                    {
                        StartState = "S4",
                        EndState = "S5",
                        Symbol = "0"
                    },
                    new Transition
                    {
                        StartState = "S5",
                        EndState = "S6",
                        Symbol = "0"
                    },
                    new Transition
                    {
                        StartState = "S6",
                        EndState = "S4",
                        Symbol = "0"
                    }
                }
            };

            var b = JsonConvert.SerializeObject(a);

            using (var file = new StreamWriter("inputSecond.json"))
            {
                file.WriteLine(b);
            }
            #endregion

        }
    }
}
