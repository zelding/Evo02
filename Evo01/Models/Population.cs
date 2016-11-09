using System;
using System.Collections.Generic;

namespace Evo01.Models
{
    class Population
    {
        public const double BASE_MUTATION_RATE = 0.05;
        public const int MIRACLE_CHANCE_FACTOR = 317;

        protected int Size;
        protected Random Rnd;
        protected List<Individual> Individuals;

        public Population(int size, bool init, int seed = 0)
        {
            Size = size;
            Individuals = new List<Individual>();
            Rnd = new Random(seed);

            if ( init )
            {
                for(int i = 0; i < Size; i++)
                {
                    Individual newGuy = new Individual(new Species("DumbFish"), Rnd);
                    Individuals.Add(newGuy.createIndividual());
                }
            }
        }

        public Population(List<Individual> individuals, int seed = 0)
        {
            Individuals = individuals;
            Size = Individuals.Count;
            Rnd = new Random(seed);
        }

        public Population addIndividual(Individual individual)
        {
            Individuals.Add(individual);

            return this;
        }

        public List<Individual> getIndividuals()
        {
            return Individuals;
        }

        public Individual getIndividual(int index)
        {
            return Individuals[index];
        }

        /// <summary>
        /// Returns true if a miracle has occured
        /// </summary>
        /// <returns></returns>
        public static bool IneedaMiracle(Random Rnd)
        {
            return Rnd.Next(MIRACLE_CHANCE_FACTOR * 1000) % MIRACLE_CHANCE_FACTOR == 0;
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
                    "Species: " + guy.Species.Name + "\n" +
                    "Indi stuff: \n" +
                    guy.ToString() + "\n" +
                    "|X|------------------\n" +
                    guy.Species.ToString() +
                    "=====================\n";
                i++;
            }

            return str;
        }
    }
}
