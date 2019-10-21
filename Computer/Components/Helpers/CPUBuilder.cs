﻿using Computer.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components.Helpers
{
    /// <summary>
    /// A class whose purpose is to present the structure for building von neumann cpus
    /// </summary>
    public abstract class CPUBuilder
    {
        protected IVonNeumannCPU cpu { get; }

        public abstract void BuildControlUnit();
        public abstract void BuildInstructionSet();
        public abstract void BuildALU();
        public abstract void BuildProgramCounter();
    }   
}
