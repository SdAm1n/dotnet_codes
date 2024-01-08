// classes, fields, properties, constructors, methods, static, method overloading

Person p1 = new Person();
Person p2 = new Person();

Console.WriteLine(p1.Name);

p2.Name = "Sadikul Amin";
Console.WriteLine(p2.Name);

User u1 = new User("Sadikul Amin Sadman");
Console.WriteLine(u1.Name);
u1.Greet();

Console.WriteLine(Math.Sum(10, 20));
Console.WriteLine(Math.PI);

decimal x = 1000;

Account acc1 = new Account("Sadman");
Account acc2 = new Account("Sadman",ref x);

Console.WriteLine(acc1.Balance);
Console.WriteLine(acc2.Balance);

class Person
{
    // by default private

    private string _name;

    public Person()
    {
        _name = "sadman";
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

}

class User
{
    public User(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public void Greet()
    {
        Console.WriteLine($"Hello {Name}");
    }
}

// static class cannot be instantiated
// static class cannot have instance members
// static class can only have static members
public static class Math
{
    public static double PI
    {
        get { return 3.1415d; }
    }
    public static int Sum(int a, int b)
    {
        return a + b;
    }
}

// Method Overloading

public class Account
{
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public Account(string owner)
    {
        Owner = owner;
        Balance = 0;
    }

    // ref keyword is used to pass a variable by reference
    public Account(string owner, ref decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

}