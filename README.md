# InvestmentCalculator

A C# console application that estimates how much money an investment 
will be worth over time, based on a starting amount and an expected 
annual return rate.

## Features

- Input: starting amount (for example CHF, EUR, USD) and expected annual 
  return in %
- Output: projected value after 3 months, 6 months, 1, 2, 3, 5, 10, 15 and 20 years
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
### With simple interest
```
Dieser Investment-Rechner ist für jede beliebige Währung geeignet. Geben Sie den Startbetrag (z.B. in CHF, EUR, USD) als Zahl ein: 1000
Vorraussichtliche Rendite pro Jahr in % eingeben: 9
Berechnungsart wählen (1 = einfache Verzinsung, 2 = Zinseszins): 1
Es wird ohne Zinseszins und ohne Gebühren und Steuern gerechnet.

Ergebnisse:
------------------------------------------
Nach 3 Monaten: 1'022.50
Nach 6 Monaten: 1'045.00
Nach 1 Jahr: 1'090.00
Nach 2 Jahren: 1'180.00
Nach 3 Jahren: 1'270.00
Nach 5 Jahren: 1'450.00
Nach 10 Jahren: 1'900.00
Nach 15 Jahren: 2'350.00
Nach 20 Jahren: 2'800.00
```
### With compound interest
```
Dieser Investment-Rechner ist für jede beliebige Währung geeignet. Geben Sie den Startbetrag (z.B. in CHF, EUR, USD) als Zahl ein: 1000
Vorraussichtliche Rendite pro Jahr in % eingeben: 9
Berechnungsart wählen (1 = einfache Verzinsung, 2 = Zinseszins): 2
Es wird mit Zinseszins, aber ohne Gebühren und Steuern gerechnet.

Ergebnisse:
------------------------------------------
Nach 3 Monaten: 1'021.78
Nach 6 Monaten: 1'044.03
Nach 1 Jahr: 1'090.00
Nach 2 Jahren: 1'188.10
Nach 3 Jahren: 1'295.03
Nach 5 Jahren: 1'538.62
Nach 10 Jahren: 2'367.36
Nach 15 Jahren: 3'642.48
Nach 20 Jahren: 5'604.41
```

## Challenges & Learnings

### The time horizon was too short
The first version only projected up to 3 years. I extended it with longer projections, up to 20 years. A longer horizon should have been
part of the idea from the start, because an investment calculator is mostly about long-term growth.

### Extending the code meant copying code
Each new time period needed its own copy of the same calculation and output block, and changing the formula would have meant changing it in
every block. I refactored this into a list of periods (label and years), a loop that goes through it, and a separate method for the calculation.
Adding a period is now a single line. I should have solved it this way from the beginning instead of copying code.

### Simple interest became a problem with longer periods
With the longer projections, the limitation of simple interest became obvious: at 1000 with 9% return it gives 2,800.00 after 20 years, 
while compound interest gives 5,604.41. I then added a mode to choose between both. Because of the refactoring, this was easy: only the 
calculation method differs, and the loop picks the right one. If I had planned the compound interest mode from the beginning, I would have 
saved myself the later rework.