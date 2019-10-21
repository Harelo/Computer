using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components.Helpers
{
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
