using System;
using Evo01.Contracts;

namespace Evo01.Models
{
    class Gene :IGene
    {
        public enum Types { Sensor = 0, Movement = 1, Interaction = 2, Decision = 3 };
        public readonly Types type;

        private double value;

        public Gene(Types type, double value = 0)
        {
            this.type = type;
            this.value = (value != 0) ? value : new Random().NextDouble();
        }
    }
}
