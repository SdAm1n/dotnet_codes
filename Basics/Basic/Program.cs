// Console

//Console.Write("Enter your name: ");
//string? name = Console.ReadLine();

//Console.WriteLine($"Hello {name}");


// Data Type

bool isTrue = true;
Console.WriteLine(isTrue);

char c1 = 'a';
Console.WriteLine(c1);

int a = 10;
Console.WriteLine(a);

float f1 = 10.2f;
double d1 = 10.2d;
decimal d2 = 10.2m;

Console.WriteLine($"{f1} {d1} {d2}");

// Nullable value type
int? i1 = null;
bool? b1 = null;

Console.WriteLine($"int?: {i1}, bool?: {b1}");

// Type conversion
// implicit

int age = 31;
long age2 = age;

// Explicit or Casting
int age3 = (int)age2;

// String
string s1 = "Hello";
Console.WriteLine(s1);

// Empty string
string s2 = string.Empty;
Console.WriteLine(s2);

string filepath = @"c:\path\";
Console.WriteLine(filepath);
Console.WriteLine(filepath.Length);

// String interpolation and concationation
string firstname = "John";
string lastname = "Doe";

string fullname = firstname + " " + lastname;
Console.WriteLine(fullname);

// substring
Console.WriteLine(fullname.Substring(0, 6));

// String Parsing
string snum = "1234";
int parsed_num = int.Parse(snum);
Console.WriteLine(parsed_num);

Console.WriteLine(double.Parse("30.7"));

//Console.ReadKey();  // used in debugging

// Data and Time

DateTime dt = new DateTime(2021, 1, 3);
Console.WriteLine(dt);
Console.WriteLine(dt.DayOfWeek);

// computed values
Console.WriteLine($"Today: {DateTime.Today}, Now: {DateTime.Now}");

// Operators
// Five Operators: Arithmetic, Comparison, Logical, Bitwise, Assignment

int a = 10;
int b = a++;
