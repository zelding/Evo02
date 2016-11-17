using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo01.Models
{
    class Individual : Contracts.IIndividual
    {
        public readonly Species Species;

        protected double Fittness;
        protected double Energy;
        protected double Age;
        protected List<Chromosome> Chromosomes;
        protected Random Rnd;
        protected Individual[] Parents;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="species" type="Evo01.Models.Species">Species it belongs to</param>
        /// <param name="rnd" type="Random">Random seeder that the population uses</param>
        public Individual(Species species, Random rnd = null)
        {
            Species = species;
            Age = 0.0;
            Energy = 1000.0;
            Fittness = 0.0;
            Chromosomes = new List<Chromosome>();
            Rnd = rnd ?? new Random();
            Parents = new Individual[2];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="father">Parent 1</param>
        /// <param name="mother">Parent 2</param>
        public Individual createIndividual(Individual father = null, Individual mother = null)
        {
            Chromosomes = Species.GetChromosomes();

            if (father != null && mother != null)
            {
                if( father.Species.Name == mother.Species.Name )
                {
                    Parents[0] = father;
                    Parents[1] = mother;
                }
            }
            else if(father != null)
            {
                int i = 0, j = 0;
                List<Chromosome> fatherChromosomes = father.getChromosomes();

                foreach (Chromosome chr in Chromosomes)
                {
                    j = 0;
                    foreach (Gene gene in chr.GetGenes())
                    {
                        double baseValue = fatherChromosomes[i].GetGenes()[j].getValue();
                        double min = baseValue * (1.0 - Population.BASE_MUTATION_RATE);
                        double max = baseValue * (1.0 + Population.BASE_MUTATION_RATE);

                        ///On miracle, the values only can increase
                        if ( Population.IneedaMiracle(Rnd) )
                        {
                            min = baseValue * (1.0 + Population.BASE_MUTATION_RATE);
                            max = baseValue * (1.0 + Population.BASE_MUTATION_RATE * 3);
                        }

                        gene.setValue(Rnd.NextDouble() * (max - min) + min);
                        j++;
                    }
                    i++;
                }

                Parents[0] = father;
            }
            else
            {
                foreach( Chromosome chr in Chromosomes )
                {
                    foreach(Gene gene in chr.GetGenes())
                    {
                        gene.setValue(Rnd.NextDouble());
                    }
                }
            }

            return this;
        }

        public double getFittness()
        {
            throw new NotImplementedException();
        }

        public List<Chromosome> getChromosomes()
        {
            return Chromosomes;
        }

        public string ToString(int n = 0)
        {
            string str = "";
            string tabs = new string('\t', n);
            string lines = new string('=', n);

            str +=
                  tabs + "Species: " + Species.Name + "\n"
                + tabs + "Fittness: " + Fittness.ToString() + "\n"
                + tabs + "Energy: " + Energy.ToString() + "\n"
                + tabs + "Age: " + Age.ToString() + "\n"
                + tabs + Species.ToString(n + 1) + "\n"
                + lines + "=====================\n";

            if (Parents[0] != null)
            {
                str += tabs + "Parents: \n";
                str += tabs + Parents[0].ToString(n + 1) + "\n";

                if ( Parents[1] != null)
                {
                    str += tabs + Parents[1].ToString(n + 1) + "\n";
                    //this is why i did it.
                }
            }
            return str;
        }
    }
}
