using System.Collections.Generic;

namespace CitySearch
{
    public class CacheNode  
    {
        public Dictionary<char, CacheNode> Children { get; set; } = new Dictionary<char, CacheNode>();
        public ICityResult Result { get; set; } = new CityResult();
    }
}