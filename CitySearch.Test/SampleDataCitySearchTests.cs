namespace CitySearch.Test
{
    using CitySearch;

    [TestClass]
    public class SampleDataCitySearchTests
    {
        private ICollection<string> _cities;

        [TestInitialize]
        public void TestInitialize()
        {
            _cities = LoadCities.LoadSample();
        }

        [TestMethod]
        public void WhenEmptySearchStringProvidedAnEmptyCityResultIsReturned()
        {
            CityResult expected = new CityResult();

            var stringSearch = string.Empty;
            var cityFinder = new CityFinder(_cities);

            var actual = cityFinder.Search(stringSearch);

            Assert.IsTrue(expected.NextCities.SequenceEqual(actual.NextCities));
            Assert.AreEqual(0, expected.NextCities.Count);
            Assert.IsTrue(expected.NextLetters.SequenceEqual(actual.NextLetters));
            Assert.AreEqual(0, expected.NextLetters.Count);
        }

        [TestMethod]
        public void WhenLowerCaseBanSearchStringIsProvidedCitiesAreStillProvided()
        {
            CityResult expected = new CityResult()
            {
                NextCities = new List<string> { "Bandung", "Bangalore", "Bangkok", "Bangui"},
                NextLetters = new List<string> { "D", "G" }
            };

            var stringSearch = "ban";
            var cityFinder = new CityFinder(_cities);

            var actual = cityFinder.Search(stringSearch);

            Assert.IsTrue(expected.NextCities.SequenceEqual(actual.NextCities));
            Assert.IsTrue(expected.NextLetters.SequenceEqual(actual.NextLetters));
        }

        [TestMethod]
        public void WhenUpperCaseBanSearchStringIsProvidedCitiesAreStillProvided()
        {
            CityResult expected = new CityResult()
            {
                NextCities = new List<string> { "Bandung", "Bangalore", "Bangkok", "Bangui"},
                NextLetters = new List<string> { "D", "G" }
            };

            var stringSearch = "BAN";
            var cityFinder = new CityFinder(_cities);

            var actual = cityFinder.Search(stringSearch);

            Assert.IsTrue(expected.NextCities.SequenceEqual(actual.NextCities));
            Assert.IsTrue(expected.NextLetters.SequenceEqual(actual.NextLetters));
        }

        [TestMethod]
        public void WhenBangSearchStringIsProvidedCorrectCitiesAreReturned()
        {
            CityResult expected = new CityResult()
            {
                NextCities = new List<string> { "Bangalore", "Bangkok", "Bangui"},
                NextLetters = new List<string> { "A", "K", "U" }
            };

            var stringSearch = "BANG";
            var cityFinder = new CityFinder(_cities);

            var actual = cityFinder.Search(stringSearch);

            Assert.IsTrue(expected.NextCities.SequenceEqual(actual.NextCities));
            Assert.IsTrue(expected.NextLetters.SequenceEqual(actual.NextLetters));
        }

        [TestMethod]
        public void WhenZeSearchStringIsProvidedCorrectCitiesAreReturned()
        {
            CityResult expected = new CityResult();

            var stringSearch = "Ze";
            var cityFinder = new CityFinder(_cities);

            var actual = cityFinder.Search(stringSearch);

            Assert.IsTrue(expected.NextCities.SequenceEqual(actual.NextCities));
            Assert.AreEqual(0, expected.NextCities.Count);
            Assert.IsTrue(expected.NextLetters.SequenceEqual(actual.NextLetters));
            Assert.AreEqual(0, expected.NextLetters.Count);
        }

        
        [TestMethod]
        public void WhenLaSearchStringIsProvidedCorrectLettersAreReturnedIncludingSpace()
        {
            CityResult expected = new CityResult()
            {
                NextCities = new List<string> { "La Paz", "La Plata", "Lagos"},
                NextLetters = new List<string> { " ", "G" }
            };

            var stringSearch = "la";
            var cityFinder = new CityFinder(_cities);

            var actual = cityFinder.Search(stringSearch);

            Assert.IsTrue(expected.NextCities.SequenceEqual(actual.NextCities));
            Assert.IsTrue(expected.NextLetters.SequenceEqual(actual.NextLetters));
        }

        [TestMethod]
        public void WhenSpaceIsPartOfSearchStringCorrectLettersAreReturned()
        {
            CityResult expected = new CityResult()
            {
                NextCities = new List<string> { "La Paz", "La Plata"},
                NextLetters = new List<string> { "P" }
            };

            var stringSearch = "la ";
            var cityFinder = new CityFinder(_cities);

            var actual = cityFinder.Search(stringSearch);

            Assert.IsTrue(expected.NextCities.SequenceEqual(actual.NextCities));
            Assert.IsTrue(expected.NextLetters.SequenceEqual(actual.NextLetters));
        }
    }
}

