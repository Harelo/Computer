using Computer.Interfaces;

namespace Computer.EightBitCPU
{
    public class ControlUnit8b : IControlUnit
    {
        public IALU alu { get; private set; }

        public ControlUnit8b()
        {
            alu = new ALU8b();
        }
    }
}
