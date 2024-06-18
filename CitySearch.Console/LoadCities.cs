namespace CitySearch
{
    public static class LoadCities 
    {
        public static List<string> LoadFromCSV(string path)
        {
            var cities = new List<string>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    cities.Add(line);
                }
            }
            return cities;
        }

        public static List<string> LoadSample()
        {
            return new List<string> { "Bandung", "Bangalore", "Bangkok", "Bangui", "La Paz", "La Plata", "Lagos", "Leeds", "Zaria", "Zhughai", "Zibo" };
        }
    }
}