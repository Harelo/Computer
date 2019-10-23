using System.Collections;

namespace Computer
{
    /// <summary>
    /// A class that represents a bus (a group of wires) in a cpu
    /// </summary>
    public class Bus
    {
        /// <summary>
        /// The value of the bus
        /// </summary>
        private BitArray _busValue;

        /// <summary>
        /// Public getter and setter for the value of the bus
        /// </summary>
        public BitArray busValue
        {
            get => _busValue;
            set
            {
                _busValue = value;
                BusUpdateEvent?.Invoke(value);
            }
        }

        /// <summary>
        /// An indexer for a specific bit in the bus
        /// </summary>
        /// <param name="i">The bit's index</param>
        /// <returns></returns>
        public bool this[int i]
        {
            get => busValue[i];
            set
            {
                busValue[i] = value;
                BusUpdateEvent?.Invoke(busValue);
            }
        }

        /// <summary>
        /// Initalization of the BitArray
        /// </summary>
        /// <param name="bitAmount"></param>
        public Bus(int bitAmount)
        {
            _busValue = new BitArray(bitAmount, false);
        }

        //Event for updating the bus value for listeners
        public delegate void BusUpdateHandler(BitArray newValue);
        public event BusUpdateHandler BusUpdateEvent;


    }
}
