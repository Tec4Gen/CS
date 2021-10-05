using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authomaton
{
    public class Transition
    {
        public string StartState { get; set; }
        public string EndState { get; set; }
        public char Condition { get; set; }
    }
}
