using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authomaton
{
	public class StateMachine
	{
		public List<string> Alphabet { get; set; }
		public List<string> States { get; set; }
		public List<Transition> Transitions { get; set; }
		public string BeginState { get; set; }
		public string FinalState { get; set; }
        public StateMachine()
        {

        }
		public StateMachine(string jsonFilePath)
		{
			StateMachine stateMachibe;
			using (var reader = new StreamReader(jsonFilePath))
			{
				stateMachibe = JsonConvert.DeserializeObject<StateMachine>(reader.ReadToEnd());
			}
			

			Alphabet = stateMachibe.Alphabet;
			States = stateMachibe.States;
			Transitions = stateMachibe.Transitions;
			BeginState = stateMachibe.BeginState;
			FinalState = stateMachibe.FinalState;

		}

		public void Run(char[] input)
		{
			var currentState = BeginState;
			foreach (var c in input)
			{
				var transition = GetNextTransition(currentState, c);
				if (transition == null)
				{
                    Console.WriteLine("Последовательность не подходит для этого автомата");
					return;
				}

				Console.WriteLine($"{c} => ({transition.StartState}, {transition.EndState})");

				currentState = transition.EndState;

				if (IsEndState(currentState))
				{
					Console.WriteLine("Последовательность подходит для этого автомата");
					return;
				}
				
			}

			return;
		}

		private bool IsEndState(string stateName)
		{
			return FinalState.Contains(stateName);
		}

		private Transition GetNextTransition(string startState, char c)
		{
			return Transitions.FirstOrDefault(t => t.StartState == startState && t.Condition == c);
		}
	}
}
