using Computer.Components;
using Computer.EightBitCPU;
using Computer.Helpers;
using System;
using System.Collections;

namespace Computer
{
    public static class ComputerCase
    {
        public static void Main()
        {
            CPUShop shop = new CPUShop();
            CPU8bBuilder builder = new CPU8bBuilder();
            VonNeumannCPU cpu = shop.Construct(builder);
            ((ALU8b)cpu.alu).NOT(new BitArray(8, false));
            Binary.PrintBA(cpu.cpuBus);
        }
    }

    public class A
    {
        public BitArray bits;

        public A()
        {
            bits = new BitArray(8, false);
        }
    }

    public class B
    {
        public BitArray bits;
        public B(ref BitArray _bits)
        {
            bits = _bits;
        }
    }
}
