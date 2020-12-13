using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCoopSimulation.Models
{
    public class Coop: ICoop
    {
        public int MaxPopulationLimit { get; set; }

        List<IAnimal> animals = new List<IAnimal>();

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
        }
        public void AddRangeAnimal(List<IAnimal> animals)
        {
            this.animals.AddRange(animals);
        }

        public IAnimal GetAnimal(int index)
        {
            return animals[index];
        }

        public List<IAnimal> GetAllAnimals()
        {
            return animals;
        }
    }
}
