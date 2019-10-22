using Computer.Components;
using System;
using System.Collections;
namespace Computer
{
    public class ComputerCase
    {
        public static void Main()
        {
            BitArray i = new BitArray(8, false);
            BitArray o = new BitArray(8, false);
            Register r = new Register(8, i, o);
        }
    }
}
