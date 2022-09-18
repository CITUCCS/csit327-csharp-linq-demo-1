internal class Program
{
    class Animal
    {
        public Animal(string name, string habitat, List<string> countries)
        {
            Name = name;
            Habitat = habitat;
            Countries = countries;
        }

        public string Name { get; set; }
        public string Habitat { get; set; }
        public List<string> Countries { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"{{Name: {Name}, Habitat: {Habitat}}}";
        }
    }

    class Kingdom
    {
        public string AnimalName { get; set; }
        public string AnimalHabitat { get; set; }
    }
    private static void Main(string[] args)
    {
        IEnumerable<Animal> animals = new List<Animal>
        {
            new Animal("Gold fish", "Sea", new List<string> {"PH", "CH", "SG"}),
            new Animal("Shark", "Sea", new List<string> {"US", "CA"}),
            new Animal("Starfish", "Sea", new List<string> {"JP"}),

            new Animal("Dog", "Land", new List<string> {"GE", "RU"}),
            new Animal("Human", "Land", new List<string> {"Everywhere"}),
            new Animal("Cat", "Land", new List<string> {"S-KR", "N-KR"}),

            new Animal("Eagle", "Air", new List<string> {"JP"}),
        };

        // Select
        var listOfHabitats = animals.Select(animal => animal.Habitat);
        var listOfKingdoms = animals.Select(animal =>
        {
            var kingdom = new Kingdom { AnimalName = animal.Name, AnimalHabitat = animal.Habitat };

            return kingdom;
        });

        foreach (var kingdom in listOfKingdoms)
        {
            Console.WriteLine("Kingdom Animal: " + kingdom.AnimalName);
            Console.WriteLine("Kingdom Habitat: " + kingdom.AnimalHabitat);
        }

        // GroupBy
        var animalsGroupedByHabitat = animals.GroupBy(a => a.Habitat);
        foreach (var habitatGroup in animalsGroupedByHabitat)
        {
            Console.WriteLine(habitatGroup.Key);
            foreach (var animal in habitatGroup)
            {
                Console.WriteLine(animal);
            }
        }

        //SelectMany
        foreach (var group in animalsGroupedByHabitat)
        {
            var listOfCountries = group.SelectMany(group => group.Countries);
            Console.WriteLine(group.Key);

            foreach (var country in listOfCountries)
            {
                Console.Write(country + ", ");
            }

            Console.WriteLine();
        }
    }
}