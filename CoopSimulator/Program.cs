using RabbitCoopSimulation.Business;
using System;

namespace RabbitCoopSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            new SimulatePopulation().Simulate();
            Console.Read();
        }        
    }
}
