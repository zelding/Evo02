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
        public enum ChromosomeTypes { Sensor = 0, Movement = 1, Interaction = 2, Decision = 3, Brain = 5 };
        public readonly ChromosomeTypes Type;

        protected List<Gene> Genes;

        /// <summary>
        /// 
        /// </summary>
        public Chromosome(ChromosomeTypes Type)
        {
            this.Type = Type;
            Genes = new List<Gene>();

            foreach ( Gene.GeneTypes type in Enum.GetValues(typeof(Gene.GeneTypes)) )
            {
                Genes.Add(new Gene(type));
            }
        }

        public List<Gene> GetGenes()
        {
            return Genes;
        }

        public string ToString(int n = 0)
        {
            string str = "";

            foreach( Gene gene in Genes )
            {
                str += gene.ToString(n);
            }

            return str;
        }
    }
}
