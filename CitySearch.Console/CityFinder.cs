namespace CitySearch
{
    public class CityFinder : ICityFinder 
    {
        private readonly ICollection<string> _cities;

        private readonly CacheNode _cache = new CacheNode();
        public CityFinder(ICollection<string> cities)
        {
            _cities = cities; 
            Intitialise();
        }

        private void Intitialise()
        {
            foreach (var city in _cities)
            {
                var currentNode = _cache;
                var cityFormatted = city.ToUpperInvariant();

                for (int index = 0; index < city.Length; index++)
                {
                    var letter = cityFormatted[index];
                    if (!currentNode.Children.ContainsKey(letter))
                    {
                        currentNode.Children[letter] = new CacheNode();
                    }

                    currentNode = currentNode.Children[letter];
                    currentNode.Result.NextCities.Add(city);

                    // If this is not final letter in the city name, add the next letter to the list for this node
                    if (index < city.Length - 1)
                    {
                        currentNode.Result.NextLetters.Add(cityFormatted[index + 1].ToString());
                    }
                }
            }
        }

        public ICityResult Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return new CityResult();
            }

            var currentNode = _cache;

            foreach ( var letter in searchString.ToUpperInvariant())
            {
                if (!currentNode.Children.ContainsKey(letter))
                {
                    return new CityResult();
                }

                currentNode = currentNode.Children[letter];
            }

            return currentNode.Result;
        }
    }
}