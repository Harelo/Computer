using Computer.Components;
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
        public VonNeumannCPU Construct(CPUBuilder builder)
        {
            builder.BuildCPUBus();
            builder.BuildALU();
            builder.BuildControlUnit();
            builder.BuildInstructionSet();
            builder.BuildRegisters();

            return builder.cpu;
        }
    }
}
