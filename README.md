# InvestmentCalculator

Mit dieser Konsolen-Applikation in C# im .NET-Framework kann man herausfinden, wie viel Geld ein Investment in der Zukunft bringen wird. Dabei muss man die erwartete Rendite in Prozent eingeben und dann sieht man die Menge Geld, die man in der Zukunft haben wird.

# InvestmentCalculator

A C# console application that estimates how much money an investment 
will be worth over time, based on a starting amount and an expected 
annual return rate.

## Features

- Input: starting amount (CHF, EUR, USD, etc.) and expected annual 
  return in %
- Output: projected value after 3 months, 6 months, 1, 2, and 3 years
- Uses simple interest (no compounding, no fees, no taxes)
- Input validation: rejects negative numbers and invalid formats

## Prerequisites

You need .NET 9.0.

## How to Run

```bash
git clone https://github.com/Marko12234/InvestmentCalculator.git
cd InvestmentCalculator
dotnet run
```

## Example Output
Geben Sie den Startbetrag (in CHF, EUR, USD etc) als Zahl ein: 1000
Vorraussichtliche Rendite pro Jahr in % eingeben: 9
Es wird ohne Zinseszins und ohne Gebühren und Steuern gerechnet.
```
Ergebnisse:
------------------------------------------
Nach 3 Monaten: CHF 1’022.50
Nach 6 Monaten: CHF 1’045.00
Nach 1 Jahr: CHF 1’090.00
Nach 2 Jahren: CHF 1’180.00
Nach 3 Jahren: CHF 1’270.00
```
