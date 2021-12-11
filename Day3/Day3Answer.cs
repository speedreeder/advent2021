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
        
    }
}
