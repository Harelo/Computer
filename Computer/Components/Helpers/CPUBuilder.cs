using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components.Helpers
{
    public abstract class CPUBuilder
    {
        protected VonNeumannCPU cpu { get; }

        public abstract void BuildControlUnit();
        public abstract void BuildInstructionSet();
        public abstract void BuildALU();
    }   
}
