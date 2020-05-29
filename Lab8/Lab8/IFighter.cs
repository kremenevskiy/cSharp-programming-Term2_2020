namespace Lab8
{
    public interface IFighter<T>
    {
        float Hit();
        float FightCoefficient { get; set; }
        bool FightAgainst(T opponent);
        
        string CountryFrom { get; }
        string Name { get; }
        string Surname { get; }
    }
}