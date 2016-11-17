using System;
using Evo01.Contracts;

namespace Evo01.Models
{
    class Gene :IGene
    {
        public enum GeneTypes { Range = 0, Strength = 1, Speed = 2, Resolution = 3, Angle = 4 };
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

        public string ToString(int n = 0)
        {
            string str = "";
            string tabs = new string('\t', n);

            str += tabs + Type.ToString() + "=" + Value + "\n";
            
            return str;
        }
    }
}
