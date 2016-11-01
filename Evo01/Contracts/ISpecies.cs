using System.Collections.Generic;
using Evo01.Models;

namespace Evo01.Contracts
{
    interface ISpecies
    {
        List<Chromosome> GetChromosomes();
    }
}
