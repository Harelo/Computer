using Computer.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Helpers
{
    /// <summary>
    /// A class whose purpose is to build a CPU using the builder class
    /// </summary>
    public class CPUShop
    {
        public IVonNeumannCPU Construct(CPUBuilder builder)
        {
            builder.BuildALU();
            builder.BuildControlUnit();
            builder.BuildInstructionSet();

            return builder.cpu;
        }
    }
}
