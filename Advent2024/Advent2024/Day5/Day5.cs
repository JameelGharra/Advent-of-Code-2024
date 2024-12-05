using Advent2024.Common;
using System.Text.RegularExpressions;

public class Day5 : IDay {


    private List<Tuple<int, int>> rules = new();
    private List<List<int>> updates = new();

    private Tuple<bool, int> IsGoodUpdate(List<int> update) {
        Dictionary<int, int> mapOrder = new();
        for (int i = 0; i < update.Count; ++i) {
            mapOrder.Add(update[i], i);
        }
        foreach (var rule in rules) {
            if (mapOrder.TryGetValue(rule.Item1, out int value) &&
                mapOrder.TryGetValue(rule.Item2, out int value2) &&
                value > value2)
                    return new Tuple<bool, int>(false, -1);

        }
        return new(true, update[update.Count / 2]);
    }

    private void SolvePartOne() {
        long result = 0;
        foreach (var update in updates) {
            var resultTuple = IsGoodUpdate(update);
            if (resultTuple.Item1) {
                result += resultTuple.Item2;
            }
        }
        Console.WriteLine($"Part one: {result}");
    }
    public Day5() {
        ReadInput();
        Solve();
    }
    public void ReadInput() {
        string pattern = @"^(\d+)\|(\d+)$";
        StreamReader fileReader = new("E:\\Advent\\Advent2024\\Advent2024\\Input\\Day5.txt");
        string? line;
        Regex regex = new(pattern);
        Match match;
        bool isOrder = true;
        while ((line = fileReader.ReadLine()) != null) {
            if (line == "") {
                isOrder = false;
                continue;
            }
            if (isOrder) {
                match = regex.Match(line);

                int leftNumber = int.Parse(match.Groups[1].Value);
                int rightNumber = int.Parse(match.Groups[2].Value);
                rules.Add(new Tuple<int, int>(leftNumber, rightNumber));

            }
            else {
                updates.Add(line.Split(',').ToList().Select(x => int.Parse(x)).ToList());
            }
        }
    }
    public void Solve() {
        SolvePartOne();
    }
}
