// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Text;

Console.WriteLine("=== Investment-Rechner ===\n");

decimal startAmount = ReadDecimal("Geben Sie den Startbetrag (in CHF, EUR, USD etc) als Zahl ein: ");
decimal percentInput = ReadDecimal("Vorraussichtliche Rendite pro Jahr in % eingeben: ");

decimal annualRate = percentInput / 100m;

Console.WriteLine("Es wird ohne Zinseszins und ohne Gebühren und Steuern gerechnet.");

Console.WriteLine("\nErgebnisse:");
Console.WriteLine("------------------------------------------");

decimal value3M = startAmount + (startAmount * annualRate * 0.25m);
Console.WriteLine($"Nach 3 Monaten: {value3M:C2}");

decimal value6M = startAmount + (startAmount * annualRate * 0.5m);
Console.WriteLine($"Nach 6 Monaten: {value6M:C2}");

decimal value1Y = startAmount + (startAmount * annualRate * 1m);
Console.WriteLine($"Nach 1 Jahr: {value1Y:C2}");

decimal value2Y = startAmount + (startAmount * annualRate * 2m);
Console.WriteLine($"Nach 2 Jahren: {value2Y:C2}");

decimal value3Y = startAmount + (startAmount * annualRate * 3m);
Console.WriteLine($"Nach 3 Jahren: {value3Y:C2}");


static decimal ReadDecimal(string message)
{
    while (true)
    {
        Console.Write(message);
        string? input = Console.ReadLine();

        if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
        {
            if (value >= 0)
                return value;
        }

        Console.WriteLine("Ungültige Eingabe. Bitte positive Zahl eingeben.\n");
    }
}