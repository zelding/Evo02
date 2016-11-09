using System;
using Evo01.Contracts;

namespace Evo01.Models
{
    class Gene :IGene
    {
        public enum GeneTypes { Range = 0, Strength = 1, Speed = 2, Resolution = 3 };
        public readonly GeneTypes Type;

        protected double Value;

        public Gene(GeneTypes type, double value = 0)
        {
            Type = type;
            Value = value;
        }

        public double getValue()
        {
            return Value;
        }

        public Gene setValue(double value)
        {
            Value = value;

            return this;
        }

        public override string ToString()
        {
            string str = "";

            str += Type.ToString() + "=" + Value + "\n";

            return str;
        }
    }
}
