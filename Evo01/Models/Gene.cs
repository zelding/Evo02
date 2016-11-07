using System;
using Evo01.Contracts;

namespace Evo01.Models
{
    class Gene :IGene
    {
        public enum GeneTypes { Range = 0, Strength = 1, Speed = 2, Resolution = 3 };
        public readonly GeneTypes type;

        protected double value;

        public Gene(GeneTypes type, double value = 0)
        {
            this.type = type;
            this.value = value;
        }

        public Gene setValue(double value)
        {
            this.value = value;

            return this;
        }

        public override string ToString()
        {
            string str = "";

            str += type.ToString() + "=" + value + "\n";

            return str;
        }
    }
}
