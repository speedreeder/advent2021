public class Day1Answer {
    public string[] Lines {get; set;}
    public Day1Answer()
    {
        Lines = System.IO.File.ReadAllLines(@"./Day1/input.txt");
    }
    public void RunPartA() {
        var numIncreased = 0;
        var numDecreased = 0;
        var numEqual = 0;

        for (int i = 0; i < Lines.Length; i++)
        {
            var currentValue = int.Parse(Lines[i]);

            if(i == 0) {
                Console.WriteLine(currentValue + " (N/A - no previous measurement)");
                continue;
            }
            
            var lastValue = int.Parse(Lines[i-1]);

            if (lastValue > currentValue) {
                Console.WriteLine(currentValue + " (decreased)");
                numDecreased++;
                continue;
            }

            if (lastValue == currentValue) {
                Console.WriteLine(currentValue + " (no change)");
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
        Console.WriteLine($"Total No Change: {numEqual}");
    }

    public void RunPartB() {
        var numIncreased = 0;
        var numDecreased = 0;
        var numEqual = 0;
        var groupColNum = 1;

        for (int i = 0; i < Lines.Length - 2; i++)
        {
            var n0 = int.Parse(Lines[i]);
            var n1 = int.Parse(Lines[i+1]);
            var n2 = int.Parse(Lines[i+2]);
            var currentSum = n0 + n1 + n2;

            if (i == 0) {
                Console.WriteLine($"{StringUtil.GetColNameFromIndex(groupColNum)}: + (N/A - no previous measurement)");
                groupColNum++;
                continue;
            }

            var m0 = int.Parse(Lines[i]);
            var m1 = int.Parse(Lines[i+1]);
            var m2 = int.Parse(Lines[i-1]);
            var priorSum = m0 + m1 + m2;
            
            if (priorSum > currentSum) {
                Console.WriteLine($"{StringUtil.GetColNameFromIndex(groupColNum)}: Current Sum [{currentSum} = {n0} + {n1} + {n2}] < Prior Sum [{priorSum} = {m0} + {m1} + {m2}] (decreased)");
                numDecreased++;
                groupColNum++;
                continue;
            }

            if (priorSum == currentSum) {
                Console.WriteLine($"{StringUtil.GetColNameFromIndex(groupColNum)}: Current Sum [{currentSum} = {n0} + {n1} + {n2}] == Prior Sum [{priorSum} = {m0} + {m1} + {m2}] (no change)");
                numEqual++;
                groupColNum++;
                continue;
            }

            if (priorSum < currentSum) {
                Console.WriteLine($"{StringUtil.GetColNameFromIndex(groupColNum)}: Current Sum [{currentSum} = {n0} + {n1} + {n2}] > Prior Sum [{priorSum} = {m0} + {m1} + {m2}] (increased)");
                numIncreased++;
                groupColNum++;
                continue;
            }
        }

        Console.WriteLine($"Total Increased: {numIncreased}");
        Console.WriteLine($"Total Decreased: {numDecreased}");
        Console.WriteLine($"Total No Change: {numEqual}");
    }
}
