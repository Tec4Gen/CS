using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatonSecond
{
	public class StateMachine
	{
		public List<string> Alphabet { get; set; }
		public List<string> States { get; set; }
		public List<Transition> Transitions { get; set; }
		public string BeginState { get; set; }
		public List<string> FinalStates { get; set; }

		public StateMachine()
		{
		}

		public static StateMachine CreateMachineByJson(string jsonFilePath)
		{
			StateMachineForConverting stateMachine;
			using (var reader = new StreamReader(jsonFilePath))
			{
				stateMachine = JsonConvert.DeserializeObject<StateMachineForConverting>(reader.ReadToEnd());
			}
			
			var automaton = new StateMachine();
			automaton.Alphabet = stateMachine.Alphabet;
			automaton.Alphabet.Add("");
			automaton.States = stateMachine.States;
			automaton.BeginState = stateMachine.BeginState;
			automaton.FinalStates = stateMachine.FinalStates;
			automaton.Transitions = stateMachine.Transitions;

			if (automaton.Alphabet.Any(a => a.Length > 1))
			{
				throw new Exception("Ошибка в файле");
			}
			if (!automaton.Transitions.All(t => automaton.ValidateTransition(t)))
			{
				throw new Exception("Ошибка в файле");
			}

			return automaton;
		}

		public void Run(string input)
		{
			Console.WriteLine($"Проверка последовательности: {input}");

			if (ValidateWord(BeginState, input, new List<string>()))
			{
				return;
			}

			Console.WriteLine($"Ошибка: не являеться входной последовательностью: {input}");
		}

		private bool ValidateWord(string currentState, string input, List<string> steps)
		{
			if (FinalStates.Contains(currentState))
			{
				if (input == string.Empty)
				{
					var stepsMessage = string.Join(Environment.NewLine, steps);

					Console.WriteLine($"Подходящая последовательность {input} финальное состояние {currentState} с последовательность: {stepsMessage}");
					return true;
				}
				else
				{
					return false;
				}
			}

			char? nextChar = input.FirstOrDefault();
			var next = nextChar?.ToString() ?? string.Empty;

			var transitions = GetAllTransitions(currentState, next);
			foreach (var transition in transitions)
			{
				steps.Add(transition.ToString());
				if (transition.Symbol == string.Empty)
				{
					if (ValidateWord(transition.EndState, input, steps))
					{
						return true;
					}
				}
				else
				{
					if (ValidateWord(transition.EndState, input.Substring(1), steps))
					{
						return true;
					}
				}
			}
			return false;
		}

		private IEnumerable<Transition> GetAllTransitions(string currentState, string symbol)
		{
			return Transitions.FindAll(t => t.StartState == currentState && (t.Symbol == symbol || t.Symbol == string.Empty));
		}

		private bool ValidateTransition(Transition transition)
		{
			return States.Contains(transition.StartState) &&
				States.Contains(transition.EndState) &&
				Alphabet.Contains(transition.Symbol);
		}

		private class StateMachineForConverting
		{
			public List<string> Alphabet { get; set; }
			public List<string> States { get; set; }
			public string BeginState { get; set; }
			public List<string> FinalStates { get; set; }
			public List<Transition> Transitions { get; set; }
		}
	}
}
