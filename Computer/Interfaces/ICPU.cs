using System.Collections.Generic;

namespace Computer.Interfaces
{
    public interface ICPU
    {
        public IControlUnit controlUnit { get; }

        public Dictionary<string, IInstruction> instructionSet { get; }
        public IALU alu { get; }
    }
}
