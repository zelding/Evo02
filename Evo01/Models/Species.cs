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
            this.Name = name;
            this.Chromosomes = new List<Chromosome>();

            foreach (Chromosome.ChromosomeTypes type in Enum.GetValues(typeof(Chromosome.ChromosomeTypes)))
            {
                this.Chromosomes.Add(new Chromosome(type));
            }
        }

        public List<Chromosome> GetChromosomes()
        {
            return this.Chromosomes;
        }
    }
}
