using System;
using Evo01.Contracts;

namespace Evo01.Models
{
    class Gene :IGene
    {
        public enum GeneTypes { Range = 0, Strength = 1, Speed = 2, Resolution = 3 };
        public readonly GeneTypes type;

        private double value;

        public Gene(GeneTypes type, double value = 0)
        {
            this.type = type;
            this.value = (value != 0) ? value : new Random().NextDouble();
        }
    }
}
