using System;
using System.Collections.Generic;
using Evo01.Contracts;

namespace Evo01.Models
{
    /// <summary>
    /// 
    /// </summary>
    class Chromosome : IChromosome
    {
        public readonly string name;

        private uint generation;
        private List<Gene> genes;

        /// <summary>
        /// 
        /// </summary>
        public Chromosome(string name)
        {
            this.generation = 0;
            this.name = name;

            foreach( Gene.Types type in Enum.GetValues(typeof(Gene.Types)) )
            {
                this.genes.Add(new Gene(type));
            }
        }
    }
}
