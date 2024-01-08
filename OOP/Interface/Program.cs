// Interface is a contract that a class can implement

IAnimal dog = new Dog();
IAnimal cat = new Cat();

Console.WriteLine(dog.GetAnimalType());
Console.WriteLine(cat.GetAge());

public interface IAnimal
{
    string GetAnimalType();
    int GetAge();
}

public class Dog : IAnimal
{
    public string GetAnimalType()
    {
        return "Dog";
    }

    public int GetAge()
    {
        return 10;
    }
}

public class Cat : IAnimal
{
    public string GetAnimalType()
    {
        return "Cat";
    }

    public int GetAge()
    {
        return 5;
    }
}