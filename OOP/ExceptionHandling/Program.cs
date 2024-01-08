string file = "";
try
{
    file = File.ReadAllText("file.txt");
    Console.WriteLine("File read successfully");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"{ex.FileName} could not be found");
}
finally
{
    Console.WriteLine($"The content length: {file.Length}");
    Console.WriteLine(file);
}