using System.Collections;

namespace Computer
{
    public class Bus
    {
        private BitArray _busValue;
        public BitArray busValue
        {
            get => _busValue;
            set
            {
                _busValue = value;
                BusUpdateEvent?.Invoke(value);
            }
        }

        public bool this[int i]
        {
            get => busValue[i];
            set
            {
                busValue[i] = value;
                BusUpdateEvent?.Invoke(busValue);
            }
        }

        public Bus(int bitAmount)
        {
            _busValue = new BitArray(bitAmount, false);
        }

        public delegate void BusUpdateHandler(BitArray newValue);
        public event BusUpdateHandler BusUpdateEvent;


    }
}
