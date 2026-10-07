// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Text;

Console.WriteLine("=== Investment-Rechner ===\n");

decimal startAmount = ReadDecimal("Dieser Investment-Rechner ist für jede beliebige Währung geeignet. Geben Sie den Startbetrag (z.B. in CHF, EUR, USD) als Zahl ein: ");
decimal percentInput = ReadDecimal("Vorraussichtliche Rendite pro Jahr in % eingeben: ");

bool useCompound = ReadCalculationMode();

decimal annualRate = percentInput / 100m;

Console.WriteLine(useCompound
    ? "Es wird mit Zinseszins, aber ohne Gebühren und Steuern gerechnet."
    : "Es wird ohne Zinseszins und ohne Gebühren und Steuern gerechnet.");

Console.WriteLine("\nErgebnisse:");
Console.WriteLine("------------------------------------------");

(string Label, decimal Years)[] periods =
{
    ("3 Monaten", 0.25m),
    ("6 Monaten", 0.5m),
    ("1 Jahr", 1m),
    ("2 Jahren", 2m),
    ("3 Jahren", 3m),
    ("5 Jahren", 5m),
    ("10 Jahren", 10m),
    ("15 Jahren", 15m),
    ("20 Jahren", 20m)
};

foreach (var (label, years) in periods)
{
    decimal value = useCompound
    ? CalculateCompoundInterest(startAmount, annualRate, years)
    : CalculateSimpleInterest(startAmount, annualRate, years);
    Console.WriteLine($"Nach {label}: {value:N2}");
}

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

static decimal CalculateSimpleInterest(decimal start, decimal rate, decimal years)
{
    return start + (start * rate * years);
}

static decimal CalculateCompoundInterest(decimal start, decimal rate, decimal years)
{
    return start * (decimal)Math.Pow((double)(1 + rate), (double)years);
}

static bool ReadCalculationMode()
{
    while (true)
    {
        Console.Write("Berechnungsart wählen (1 = einfache Verzinsung, 2 = Zinseszins): ");
        string? input = Console.ReadLine()?.Trim();

        if (input == "1") return false;
        if (input == "2") return true;

        Console.WriteLine("Ungültige Eingabe. Bitte \"1\" oder \"2\" eingeben.\n");
    }
}