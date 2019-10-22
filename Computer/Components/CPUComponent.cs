﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Computer.Components
{
    public abstract class CPUComponent
    {
        /// <summary>
        /// A reference to the CPU bus
        /// </summary>

        private BitArray _cpuBus;
        protected BitArray cpuBus
        {
            get => _cpuBus;
            set
            {
                _cpuBus = value;
                cpu.cpuBus = value;
            }
        }

        private VonNeumannCPU cpu;
        public CPUComponent(VonNeumannCPU _cpu)
        {
            cpu = _cpu;
        }
    }
}