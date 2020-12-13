using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCoopSimulation.Models
{
    public class Animal: IAnimal
    { 
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public IAnimal Parent { get; set; }
        public int BirthCycle { get; set; }
    }
}
