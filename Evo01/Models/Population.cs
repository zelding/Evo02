using System;
using System.Collections.Generic;

namespace Evo01.Models
{
    class Population
    {
        public const double MUTATION_RATE = 0.05;

        protected int size;
        protected Random rnd;
        protected List<Individual> Individuals;

        public Population(int size, bool init, int seed = 0)
        {
            this.size = size;
            Individuals = new List<Individual>();
            rnd = new Random(seed);

            if ( init )
            {
                for(int i = 0; i < this.size; i++)
                {
                    Individual newGuy = new Individual(new Species("DumbFish"), rnd);
                    Individuals.Add(newGuy.createIndividual());
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            int i = 0;

            foreach(Individual guy in Individuals)
            {
                str +=
                    "Guy " + i.ToString() + ": \n" +
                    "=====================\n" +
                    "Species: " + guy.species.Name + "\n" +
                    guy.species.ToString() +
                    "=====================\n";
                i++;
            }

            return str;
        }
    }
}
