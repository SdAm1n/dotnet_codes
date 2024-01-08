Person person = new Person();
Person student = new Student();
// or Student student = new Student(); both are same
Person teacher = new Teacher();
// or Teacher teacher = new Teacher();

person.greeting();
student.greeting();
teacher.greeting();

public class Person
{
    public virtual void greeting ()
    {
        Console.WriteLine("Hello, I'm a person");
    }
} 

public class Student : Person
{
    public override void greeting ()
    {
        Console.WriteLine("Hello, I'm a student");
    }
}

public class Teacher : Person
{
    public override void greeting ()
    {
        Console.WriteLine("Hello, I'm a teacher");
    }
}