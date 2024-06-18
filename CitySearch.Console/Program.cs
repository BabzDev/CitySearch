// See https://aka.ms/new-console-template for more information
using CitySearch;

List<string> cities = new List<string>();

var citySelection = string.Empty;


while (citySelection != "1" && citySelection != "2" && citySelection != "exit")
{
    Console.WriteLine("Choose which city data set would you prefer to work with.");
    Console.WriteLine("1. List of 1 million + cities");
    Console.WriteLine("2. Example list: Bandung, Bangui, Bangkok, Bangalore, La Paz, La Plata, Lagos, Leeds, Zaria, Zhughai, Zibo");
    Console.WriteLine("Please enter 1 or 2, or type 'exit' to close the application: ");
    citySelection = Console.ReadLine();
    if (citySelection == "1")
    {
        Console.WriteLine("Loading 1 million + cities data set...");
        cities = LoadCities.LoadFromCSV("worldcities1m.csv");
    }
    else if (citySelection == "2")
    {
        Console.WriteLine("Loading example list of cities...");
        cities = LoadCities.LoadSample();
    }
    else if (citySelection == "exit")
    {
        return;
    }
    else
    {
        Console.WriteLine("Invalid selection.");
        Console.WriteLine();
    }
}

Console.WriteLine("Cities loaded successfully.");
Console.WriteLine("Initialising city search cache...");
var cityFinder = new CityFinder(cities);

Console.WriteLine("City search cache initialised successfully.");
Console.WriteLine();

while (true)
{
    
    Console.WriteLine("Enter city prefix to search (or 'exit' to quit):");
    string input = Console.ReadLine();
    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    var result = cityFinder.Search(input.ToUpper());
    Console.WriteLine("Next Cities: " + string.Join(", ", result.NextCities));
    Console.WriteLine("Next Letters: " + string.Join(", ", result.NextLetters));
    Console.WriteLine();
}