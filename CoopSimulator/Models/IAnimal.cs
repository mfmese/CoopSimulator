using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCoopSimulation.Models
{
    public interface IAnimal
    {
        string Name { get; set; }
        Gender Gender { get; set; }
        int Age { get; set; }
        IAnimal Parent { get; set; }
        int BirthCycle { get; set; }
    }
}
