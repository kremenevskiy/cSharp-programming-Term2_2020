namespace Lab8
{
    public interface IScorer
    { 
        bool IsScored(); 
        int ChanceToScore();
        
        string Name { get; }
        string Surname { get; }
        string CountryFrom { get; }
    }
}