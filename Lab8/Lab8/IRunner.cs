using System;

namespace Lab6
{
    public interface IRunner : IComparable<IRunner>
    { 
        float Run(float distance);
        string CountryFrom { get; }
        
        static float Record = float.MaxValue;
        static double GetTime(double distance, double speed) => distance / speed;
        
        string Name { get; }
        string Surname { get; }
        float PersonTime { get; }
    }
}