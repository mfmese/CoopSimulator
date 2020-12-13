using RabbitCoopSimulation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitCoopSimulation.Business
{
    public class SimulatePopulation
    {
        private readonly ICoop _coop;
        private readonly int _simulationCycle;
        public SimulatePopulation(ICoop coop, int simulationCycle)
        {
            _coop = coop;
            _simulationCycle = simulationCycle;
        }

        public SimulatePopulation()
        {
            var config = AppConfiguration.GetConfig();

            _coop = PopulationState.GetInitialCoopState(config);

            _simulationCycle = config.CyclePeriodAtMonth;
        }
   
        public void Simulate()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < _simulationCycle; i++)
            {
                GiveBirthAnimal(_coop, i);
            }

            sw.Stop();
            string log = $"Simulation Finished in : {sw.Elapsed.TotalSeconds} seconds";
            Logger.Log(log);

            Display(_coop);
        }

        private void Display(ICoop coop)
        {
            var animals = coop.GetAllAnimals();
            string log;

            List<string> animalTypes = animals.Select(x => x.Name).Distinct().ToList();
            foreach (var animalType in animalTypes)
            {
                int maleCount = animals.Count(x => x.Name == animalType && x.Gender == Gender.Male); ;
                int femaleCount = animals.Count(x => x.Name == animalType &&  x.Gender == Gender.Female);

                log = $"Name: {animalType}, Male: {maleCount}, Female:{femaleCount}";
                Logger.Log(log);
            }

            int totalCycle = animals.Max(x => x.BirthCycle);
            log = $"Total Cycle: {totalCycle}";
            Logger.Log(log);

            Logger.Log("-------------------------------------------");

            foreach (var animal in animals)
            {
                log = $"Cycle: {animal.BirthCycle} Name: {animal.Name}, Gender: {animal.Gender}, Age: {animal.Age}";
                Logger.Log(log);
            }
            Logger.Log("Simulation Finished");
        }

        private void GiveBirthAnimal(ICoop coop, int cycle)
        {
            var newBirthAnimals = new List<IAnimal>();

            for (int i = 0; i < coop.GetAllAnimals().Count; i++)
            {
                IAnimal animal = coop.GetAnimal(i);
                animal.Age++;

                if (CanGiveBirth(animal))
                {
                    var newBirth = CreateNewBirths((FemaleAnimal)animal, cycle);
                    newBirthAnimals.AddRange(newBirth);
                }
            }

            coop.AddRangeAnimal(newBirthAnimals);
        }

        private bool CanGiveBirth(IAnimal animal)
        {
            if (animal.Gender == Gender.Male)
                return false;

            int birthAtMonth = ((FemaleAnimal)animal).BirthAtMonth;
            int birthLimitAgeAtMonth = ((FemaleAnimal)animal).BirthLimitAgeAtMonth;

            return animal.Age >= birthAtMonth && animal.Age <= birthLimitAgeAtMonth;
        }

        private List<IAnimal> CreateNewBirths(FemaleAnimal parentAnimal, int cycle)
        {
            var newBirthAnimals = new List<IAnimal>();

            Parallel.For(0, parentAnimal.NumberOfBirth, i =>
            {
                var animal = parentAnimal.NewBirthAnimal();

                animal.BirthCycle = cycle + 1;

                newBirthAnimals.Add(animal);
            });

            return newBirthAnimals;
        }

    }
}
