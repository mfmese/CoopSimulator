using System.Collections.Generic;

namespace RabbitCoopSimulation.Models
{
    public interface ICoop
    {
        int MaxPopulationLimit { get; set; }

        void AddAnimal(IAnimal animal);

        void AddRangeAnimal(List<IAnimal> animals);

        IAnimal GetAnimal(int index);

        List<IAnimal> GetAllAnimals();
    }
}