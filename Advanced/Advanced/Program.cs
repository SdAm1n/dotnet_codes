// Generic Types


var cities = new RandomItems<string>();
cities.Add("London");
cities.Add("Paris");
cities.Add("New York");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(cities.GetRandom());
}

var numbers = new RandomItems<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(numbers.GetRandom());
}

public class RandomItems<T>
{
    private readonly List<T> _items = new List<T>();
    private readonly Random _random = new Random();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public T GetRandom()
    {
        return _items[_random.Next(_items.Count)];
    }
}