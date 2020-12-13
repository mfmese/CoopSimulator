using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCoopSimulation.Configuration.ConfiguraitonMapping
{
    public class AppConfig
    {
        public List<AnimalConfig> Animals { get; set; }
        public CoopConfig Coop { get; set; }
        public int CyclePeriodAtMonth { get; set; }
    }
    public class AnimalConfig
    {
        public string Name { get; set; }
        public int FemaleBirthAtMonth { get; set; }
        public int FemaleBirthAgeAtMonth { get; set; }
        public int FemaleNumberOfBirth { get; set; }
    }

    public class CoopConfig
    {
        public List<InitialState> InitialStates { get; set; }
        public int MaxPopulation { get; set; }
    }

    public class InitialState
    {
        public string AnimalName { get; set; }
        public List<Animal> Females { get; set; }
        public List<Animal> Males { get; set; }
    }

    public class Animal
    {
        public int Age { get; set; }
    }

}
