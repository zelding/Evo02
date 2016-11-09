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
