using Computer.Components.EightBitCPU;
using Computer.Helpers;
using Computer.Components.Interfaces;

namespace Computer
{
    public static class ComputerCase
    {
        public static void Main(string[] args)
        {
            CPUShop shop = new CPUShop();
            CPU8bBuilder builder = new CPU8bBuilder();
            IVonNeumannCPU cpu = shop.Construct(builder);
        }
    }
}
