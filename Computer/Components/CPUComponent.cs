using Computer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components
{
    public abstract class CPUComponent : IBussed
    {
        /// <summary>
        /// A reference to the CPU bus
        /// </summary>

        private Bus _cpuBus;
        public Bus inputBus
        {
            get => _cpuBus;
            protected set
            {
                _cpuBus = value;
                cpu.cpuBus = value;
            }
        }

        public Bus outputBus { protected set; get; }

        private VonNeumannCPU cpu;
        public CPUComponent(VonNeumannCPU _cpu)
        {
            cpu = _cpu;
        }
    }
}
