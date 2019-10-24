using Computer.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Helpers
{
    /// <summary>
    /// A class whose purpose is to present the structure for building von neumann cpus
    /// </summary>
    public abstract class CPUBuilder
    {
        //The CPU instance
        public VonNeumannCPU cpu { get; protected set; }

        //Abstract build methods
        public abstract void BuildRegisters();
        public abstract void BuildControlUnit();
        public abstract void BuildInstructionSet();
        public abstract void BuildALU();
        public abstract void BuildCPUBus();
    }
}
