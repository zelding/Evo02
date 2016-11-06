using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo01.Models
{
    class Population
    {
        public const double MUTATION_RATE = 0.05;

        protected int size;
        protected List<Individual> Individuals;

        public Population(int size, bool init)
        {
            this.size = size;
            Individuals = new List<Individual>();

            if ( init )
            {
                for(int i = 0; i < this.size; i++)
                {
                    Individual newGuy = new Individual(new Species("DumbFish"));
                    newGuy.createIndividual();
                    Individuals.Add(newGuy);
                }
            }
        }

        public override string ToString()
        {
            string str = "";
            int i = 0;

            foreach(Individual guy in Individuals)
            {
                str += "Guy " + i.ToString() + ": \n" +
                    "=====================\n" + 
                    "Species: " + guy.species.Name + "\n" +
                    guy.species.ToString();
                i++;
            }

            return str;
        }
    }
}
