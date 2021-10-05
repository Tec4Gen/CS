using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatonSecond
{
    public class Transition
    {
		public string StartState { get; set; }
		public string Symbol { get; set; }
		public string EndState { get; set; }

		public override string ToString()
		{
			return $"{Symbol} => ({StartState} -> {EndState})";
		}
	}
}
