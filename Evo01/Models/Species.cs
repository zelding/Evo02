using System;
using System.Collections.Generic;

namespace Evo01.Models
{
    class Species : Contracts.ISpecies
    {
        /// <summary>
        /// The name of the Species
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The time it takes for an Individual to reach sexual maturity
        /// </summary>
        public readonly double Maturity;

        /// <summary>
        /// The Chromosomes that the species has
        /// </summary>
        private List<Chromosome> Chromosomes;

        /// <summary>
        /// Creates a Species template
        /// </summary>
        /// <param name="name">The name of the Species</param>
        public Species(string name)
        {
            Name = name;
            Maturity = 100.0;
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

        public string ToString(int n = 0)
        {
            string tabs = new string('\t', n);
            string unders = new string('_', n * 18);
            string dots = new string('.', n * 24);

            string str = tabs + "Chromosomes: \n" +
                unders + "_______________\n";

            foreach (Chromosome chr in Chromosomes)
            {
                str += tabs +  chr.Type + ": \n" +
                    dots + "...............\n" + 
                    chr.ToString(n);
            }

            return str;
        }
    }
}
