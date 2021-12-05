var lines = System.IO.File.ReadAllLines(@"./1a.txt");

var numIncreased = 0;
var numDecreased = 0;
var numEqual = 0;

for (int i = 0; i < lines.Length; i++)
{
    var currentValue = int.Parse(lines[i]);

    if(i == 0) {
        Console.WriteLine(currentValue + " (N/A - no previous measurement)");
        continue;
    }
    
    var lastValue = int.Parse(lines[i-1]);

    if (lastValue > currentValue) {
        Console.WriteLine(currentValue + " (decreased)");
        numDecreased++;
        continue;
    }

    if (lastValue == currentValue) {
        Console.WriteLine(currentValue + " (equal)");
        numEqual++;
        continue;
    }

    if (lastValue < currentValue) {
        Console.WriteLine(currentValue + " (increased)");
        numIncreased++;
        continue;
    }
}

Console.WriteLine($"Total Increased: {numIncreased}");
Console.WriteLine($"Total Decreased: {numDecreased}");
Console.WriteLine($"Total Equals: {numEqual}");