using RabbitCoopSimulation.Configuration.ConfiguraitonMapping;
using RabbitCoopSimulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitCoopSimulation.Business
{
    public class PopulationState
    {
        public static Coop GetInitialCoopState(AppConfig config)
        {
            var simulationCycle = config.CyclePeriodAtMonth;

            var initialStates = config.Coop.InitialStates;

            var animalsConfig = config.Animals;

            var coop = new Coop() { MaxPopulationLimit = config.Coop.MaxPopulation };

            foreach (var initialState in initialStates)
            {
                var animalConfig = animalsConfig.FirstOrDefault(x => x.Name == initialState.AnimalName);
                for (int i = 0; initialState.Females != null && i < initialState.Females.Count; i++)
                {
                    var newAnimal = new FemaleAnimal()
                    {
                        Name = animalConfig.Name,
                        BirthLimitAgeAtMonth = animalConfig.FemaleBirthAgeAtMonth,
                        BirthAtMonth = animalConfig.FemaleBirthAtMonth,
                        NumberOfBirth = animalConfig.FemaleNumberOfBirth,
                        Gender = Gender.Female,
                        Age = initialState.Females[i].Age
                    };
                    coop.AddAnimal(newAnimal);
                }

                for (int i = 0; i < initialState.Males.Count; i++)
                {
                    var newAnimal = new MaleAnimal()
                    {
                        Name = animalConfig.Name,
                        Age = initialState.Males[i].Age
                    };

                    coop.AddAnimal(newAnimal);
                }
            }

            return coop;
        }
    }
}
