using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo01.Models
{
    class Individual : Contracts.IIndividual
    {
        public readonly Species species;

        protected double fittness;
        protected double energy;
        protected List<Chromosome> Chromosomes;
        protected Random rnd;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="species" type="Evo01.Models.Species">Species it belongs to</param>
        /// <param name="rnd" type="Random">Random seeder that the population uses</param>
        public Individual(Species species, Random rnd = null)
        {
            this.species = species;
            energy = 1000.0;
            fittness = 0.0;
            Chromosomes = new List<Chromosome>();
            this.rnd = rnd ?? new Random();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="father">Parent 1</param>
        /// <param name="mother">Parent 2</param>
        public Individual createIndividual(Individual father = null, Individual mother = null)
        {
            Chromosomes = species.GetChromosomes();

            if (father != null && mother != null)
            {
                if( father.species == mother.species )
                {

                }
            }
            else if(father != null)
            {

            }
            else
            {
                foreach( Chromosome chr in Chromosomes )
                {
                    foreach(Gene gene in chr.GetGenes())
                    {
                        gene.setValue(rnd.NextDouble());
                    }
                }
            }

            return this;
        }

        public double getFittness()
        {
            throw new NotImplementedException();
        }
    }
}
