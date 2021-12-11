public class Day2Answer {
    public string[] Lines {get; set;}
    public Day2Answer()
    {
        Lines = System.IO.File.ReadAllLines(@"./Day2/input.txt");
    }
    public void RunPartA() {
        var sumForward = 0;
        var sumDown = 0;
        var sumUp = 0;

        for (int i = 0; i < Lines.Length; i++)
        {
            if(Lines[i].Contains("up")){
                sumUp = sumUp + int.Parse(Lines[i].Split(' ')[1].Trim());
            }
            else if(Lines[i].Contains("down")){
                sumDown = sumDown + int.Parse(Lines[i].Split(' ')[1].Trim());
            }
            else if(Lines[i].Contains("forward")){
                sumForward = sumForward + int.Parse(Lines[i].Split(' ')[1].Trim());
            }
        }

        Console.WriteLine($"Final Horizontal: {sumForward}");
        Console.WriteLine($"Final Depth: {sumDown - sumUp}");
        Console.WriteLine($"{sumForward} x {sumDown - sumUp} = {sumForward * (sumDown - sumUp)}");
    }

    public void RunPartB() {
        var sumForward = 0;
        var depth = 0;
        var aim = 0;

        for (int i = 0; i < Lines.Length; i++)
        {
            if(Lines[i].Contains("up")){
                var up = int.Parse(Lines[i].Split(' ')[1].Trim());
                aim = aim - up;
            }
            else if(Lines[i].Contains("down")){
                var down = int.Parse(Lines[i].Split(' ')[1].Trim());
                aim = aim + down;
            }
            else if(Lines[i].Contains("forward")){
                var forward = int.Parse(Lines[i].Split(' ')[1].Trim());
                sumForward = sumForward + forward;
                depth = depth + (aim * forward);
            }
        }

        Console.WriteLine($"Final Horizontal: {sumForward}");
        Console.WriteLine($"Final Depth: {depth}");
        Console.WriteLine($"{sumForward} x {depth} = {sumForward * depth}");
    }
}
