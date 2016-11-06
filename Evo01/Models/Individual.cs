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

        public Individual(Species species)
        {
            this.species = species;
            energy = 1000.0;
            fittness = 0.0;
            Chromosomes = new List<Chromosome>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="father">Parent 1</param>
        /// <param name="mother">Parent 2</param>
        public void createIndividual(Individual father = null, Individual mother = null)
        {
            if (father != null && mother != null)
            {
                if( father.species == mother.species )
                {

                }
            }
            else
            {
                Random rnd = new Random();

                Chromosomes = species.GetChromosomes();

                foreach( Chromosome chr in Chromosomes )
                {

                }
            }
        }

        public double getFittness()
        {
            throw new NotImplementedException();
        }
    }
}
