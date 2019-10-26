using System;
using System.Collections.Generic;
using System.Text;

namespace Computer.Interfaces
{
    public interface IBussed
    {
        Bus outputBus { get; }
        Bus inputBus { get; }
    }
}
