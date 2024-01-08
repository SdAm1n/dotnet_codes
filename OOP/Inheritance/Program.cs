Person per = new Person("Sadman");
Worker wor = new Worker("Sadman", "Developer");

Console.WriteLine($"{per.Name}: {per.GetId()}");
Console.WriteLine($"{wor.Name}:- Role: {wor.Role}, Id: {wor.GetId()}, Salary: {wor.GetSalary()}");

public interface ISalary
{
    decimal GetSalary();
}

public class Person
{
    public string Name { get; set;}

    public Person(string name)
    {
        Name = name;
    }

    public virtual string GetId()
    {
        return Name.ToLower();
    }
}

public class Worker : Person, ISalary
{
    public string Role { get; set; }
    public Worker(string name, string role) : base(name)
    {
        Role = role;
    }

    public override string GetId()
    {
        return $"Worker";
    }

    public decimal GetSalary()
    {
        return 2000;
    }
}

// to make a class not inheritable, use sealed keyword
public sealed class  Student
{
    
}