using System.Collections;

// Array

int[] array1 = new int[5];
int[] array2 = new int[] {1, 3, 5, 7, 9 };
int[] array3 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

foreach (int i in array3)
{
    Console.WriteLine(i);
}

Person[] person = new Person[2];
person[0] = new Person("John");
person[1] = new Person("Mary");

Console.WriteLine(person);

foreach (Person p in person)
{
    Console.WriteLine(p.Name);
}

public class Person
{
    public Person(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}

// ArrayList : Considered Outdated and used for Backward Compatibility

//var arrayList = new ArrayList();
//var d = 12;
//arrayList.Add(d);
