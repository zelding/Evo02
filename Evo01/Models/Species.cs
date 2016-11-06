using System;
using System.Collections.Generic;

namespace Evo01.Models
{
    class Species : Contracts.ISpecies
    {
        public readonly string Name;
        private List<Chromosome> Chromosomes;

        public Species(string name)
        {
            Name = name;
            Chromosomes = new List<Chromosome>();

            foreach (Chromosome.ChromosomeTypes type in Enum.GetValues(typeof(Chromosome.ChromosomeTypes)))
            {
                Chromosomes.Add(new Chromosome(type));
            }
        }

        public List<Chromosome> GetChromosomes()
        {
            return Chromosomes;
        }

        public override string ToString()
        {
            string str = "Chromosomes: \n" + 
                "_______________\n";

            foreach(Chromosome chr in Chromosomes)
            {
                str += chr.Type + ": \n" +
                    "...............\n" + 
                    chr.ToString();
            }

            return str;
        }
    }
}
