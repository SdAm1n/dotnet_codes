// 1. Data source
var numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9 };

// 2. Query creation
var evenNumbers = numbers.Where(n => n%2 == 0);

// 3. Query execution
foreach (int evenNumber in evenNumbers)
{
    Console.WriteLine(evenNumber);
}