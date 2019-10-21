using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components.Helpers
{
    /// <summary>
    /// A class whose purpose is to build a CPU using the builder class
    /// </summary>
    public class CPUShop
    {
        public void Construct(CPUBuilder builder)
        {
            builder.BuildALU();
            builder.BuildControlUnit();
            builder.BuildInstructionSet();
        }
    }
}
