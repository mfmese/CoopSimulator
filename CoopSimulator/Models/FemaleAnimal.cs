using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCoopSimulation.Models
{
    public class FemaleAnimal: Animal
    {
        public int BirthAtMonth { get; set; }
        public int BirthLimitAgeAtMonth { get; set; }
        public int NumberOfBirth { get; set; }
        public FemaleAnimal()
        {
            this.Gender = Gender.Female;
        }

        public IAnimal NewBirthAnimal()
        {
            var randomBirth = new Random();

            var gender = (Gender)randomBirth.Next(0, 2);

            IAnimal animal;
    
            if (gender == Gender.Male)
            {
                animal = new MaleAnimal() { Name = this.Name };
            }                
            else
            {
                animal = (FemaleAnimal)this.MemberwiseClone();             
            }

            animal.Age = 0;
            animal.Parent = this;

            return animal;

        }
    }
}
