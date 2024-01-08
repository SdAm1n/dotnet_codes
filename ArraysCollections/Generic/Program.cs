
// Generic List

var numbers = new List<int>();

numbers.Add(13);
numbers.Add(4);

foreach (var number in numbers)
{
Console.WriteLine(number);
}

var persons = new List<Person>();
var person1 = new Person("John");
persons.Add(person1);

foreach (var person in persons)
{
Console.WriteLine(person.Name);
}

public class Person
{
    public Person(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}

// Stack

//var countries = new Stack<string>();
//countries.Push("India");
//countries.Push("USA");
//countries.Push("UK");
//countries.Push("Canada");

//foreach(var country in countries)
//{
//    Console.WriteLine(country);
//}

//Console.WriteLine("Popped country: " + countries.Pop());
//Console.WriteLine("Peek country: " + countries.Peek());

//foreach (var country in countries)
//{
//    Console.WriteLine(country);
//}