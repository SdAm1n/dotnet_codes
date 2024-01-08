var temp = new Temperature(TempUnit.Celsius, 11);
Console.WriteLine(temp.ValueInCelsius);

enum TempUnit
{
    Celsius,
    Fahrenheit,
    Kelvin,
    Test
}

class Temperature
{
    public Temperature(TempUnit unit, decimal value)
    {
        Unit = unit;
        Value = value;
    }

    public TempUnit Unit { get; set; }
    public decimal Value { get; set; }

    public decimal ValueInCelsius {
        get
        {
            //if (Unit == TempUnit.Celsius)
            //    return Value;
            //else if (Unit == TempUnit.Fahrenheit)
            //    return (Value - 32) * 5 / 9;
            //else
            //    return Value - 273.15m;

            // or 

            // switch expression
            return Unit switch
            {
                // guard clause
                TempUnit.Celsius when Value > 100 => Math.Round(Value, 0),
                TempUnit.Celsius => Value,
                TempUnit.Fahrenheit => (Value - 32) * 5 / 9,
                TempUnit.Kelvin => Value - 273.15m,
                _ => 0
            };

        }
    }
}