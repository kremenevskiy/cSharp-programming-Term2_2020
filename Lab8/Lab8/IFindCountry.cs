namespace Lab6
{
    public interface IFindCountry
    {
        void SelectCountry(Country country);
        
        string CountryFrom { get; set; }
        
        enum Country
        {
            Belarus,
            Spain,
            // Portugal,
            Russia
            // Jamaica,
            // USA,
            // France,
            // Canada
        }
    }
}