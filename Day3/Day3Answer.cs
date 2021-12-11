public class Day3Answer {
    public string[] Lines {get; set;}
    public Day3Answer()
    {
        Lines = System.IO.File.ReadAllLines(@"./Day3/input.txt");
    }
    public void RunPartA() {
        var gammaRateBinary = "";
        var episilonRateBinary = "";

        var columns = new string[12];

        for (int i = 0; i < Lines.Length; i++)
        {
            for(int j = 0; j < 12; j++){
                columns[j] = columns[j] + Lines[i][j];
            }
        }

        foreach(var column in columns) {
            if(column.Count(f => f == '1') > column.Count(f => f == '0')) {
                gammaRateBinary = gammaRateBinary + "1";
                episilonRateBinary = episilonRateBinary + "0";
            } 
            else {
                gammaRateBinary = gammaRateBinary + "0";
                episilonRateBinary = episilonRateBinary + "1";
            }
        }

        Console.WriteLine($"Final Gamma: {gammaRateBinary} = {Convert.ToInt32(gammaRateBinary, 2)}");
        Console.WriteLine($"Final Episilon: {episilonRateBinary} = {Convert.ToInt32(episilonRateBinary, 2)}");
        Console.WriteLine($"{Convert.ToInt32(gammaRateBinary, 2)} x {Convert.ToInt32(episilonRateBinary, 2)} = {Convert.ToInt32(gammaRateBinary, 2) * Convert.ToInt32(episilonRateBinary, 2)}"); 
    }

    public void RunPartB() {
        var oxygenBinary = "";
        var co2Binary = "";
        var columns = GetColumns(Lines.ToList());

        // for (int i = 0; i < Lines.Length; i++)
        // {
        //     for(int j = 0; j < 12; j++){
        //         columns[j] = columns[j] + Lines[i][j];
        //     }
        // }

        

        var oxygenLines = Lines.ToList();
        var colCount = 0;
        do {
            if(columns[colCount].Count(f => f == '1') >= columns[colCount].Count(f => f == '0')){
                oxygenLines = oxygenLines.Where(k => k[colCount] == '1').ToList();
                columns = GetColumns(oxygenLines);
            }
            else {
                oxygenLines = oxygenLines.Where(k => k[colCount] == '0').ToList();
                columns = GetColumns(oxygenLines);
            }
            colCount++;
        } while (colCount < 12 && oxygenLines.Count != 1);


        var co2Lines = Lines.ToList();
        colCount = 0;
        do {
            var x = 1;
            if(columns[colCount].Count(f => f == '1') <= columns[colCount].Count(f => f == '0')){
                co2Lines = co2Lines.Where(k => k[colCount] == '1').ToList();
                columns = GetColumns(co2Lines);
            }
            else {
                co2Lines = co2Lines.Where(k => k[colCount] == '0').ToList();
                columns = GetColumns(co2Lines);
            }
            colCount++;
        } while (colCount < 12 && co2Lines.Count != 1);


        Console.WriteLine($"Final Oxygen Generator Rating: {oxygenLines[0]} = {Convert.ToInt32(oxygenLines[0], 2)}");
        Console.WriteLine($"Final C02 Scrubber Rating: {co2Lines[0]} = {Convert.ToInt32(co2Lines[0], 2)}");
        // Console.WriteLine($"{Convert.ToInt32(oxygenBinary, 2)} x {Convert.ToInt32(co2Binary, 2)} = {Convert.ToInt32(oxygenBinary, 2) * Convert.ToInt32(co2Binary, 2)}"); 
    
    }

    private string[] GetColumns(List<string> lines){
        var columns = new List<string>();
        for (int i = 0; i < lines.Count; i++)
        {
            for(int j = 0; j < lines[i].Length; j++){
                if(columns.ElementAtOrDefault(j) == default){
                    columns.Add("" + lines[i][j]);
                }
                else {
                    columns[j] = columns[j] + Lines[i][j];
                }
            }
        }

        return columns.ToArray();
    }
}
