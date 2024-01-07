// Conditionals
int num = 10;

if (num % 2 == 0)
{
    Console.WriteLine("Even");
}
else if (num % 2 != 0)
{
    Console.WriteLine("Odd");
}
else
{
    Console.WriteLine("Neither Even nor Odd");
}

// Ternary Operator
string re = num == 10 ? "ten" : "not ten";
Console.WriteLine(re);

// Switch
switch (num)
{
    case 10:
        Console.WriteLine("Ten");
        break;
    case 20:
        Console.WriteLine("Twenty");
        break;
    default:
        Console.WriteLine("Neither Ten nor Twenty");
        break;
}

// Loops

int a = 1;
while (a < 5)
{
    Console.WriteLine(a);
    a++;
}

// do while and for loop is same as c and c++

