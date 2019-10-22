using Computer.Components;
using Computer.EightBitCPU;
using Computer.Helpers;
using System.Collections;
using System.ComponentModel;

namespace Computer
{
    public class ComputerCase
    {
        public static void Main()
        {
            CPUShop shop = new CPUShop();
            CPU8bBuilder builder = new CPU8bBuilder();
            VonNeumannCPU cpu = shop.Construct(builder);
        }
    }
}
