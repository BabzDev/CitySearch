namespace CitySearch
{
    using System.Collections.Generic;
    public class CityResult : ICityResult
    {
        public ICollection<string> NextLetters { get; set; } = new HashSet<string>();
        public ICollection<string> NextCities { get; set; } = new List<string>();
    }
}