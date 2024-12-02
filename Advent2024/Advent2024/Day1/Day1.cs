// Day 1

using Advent2024.Common;

public class Day1 : IDay {
    private List<int> leftInput = [];
    private List<int> rightInput = [];

    private void SolvePartOne() {
        OptimalMinHeap leftHeap = new(leftInput);
        OptimalMinHeap rightHeap = new(rightInput);

        int counter = leftInput.Count;
        int result = 0;
        while (counter > 0) {
            result += Math.Abs(leftHeap.ExtractMin() - rightHeap.ExtractMin());
            --counter;
        }
        Console.WriteLine(result);
    }
    private void SolvePartTwo() {
        Dictionary<int, int> rightAppearance = new();
        rightInput.ForEach(num => {
            if (rightAppearance.TryGetValue(num, out int value)) {
                rightAppearance[num] = ++value;
            }
            else {
                rightAppearance[num] = 1;
            }
        });
        int result = 0; // similarity score
        foreach(int num in leftInput) {
            int times = rightAppearance.GetValueOrDefault(num, 0);
            result += num * times;
        }
        Console.WriteLine(result);
    }
    public Day1() {
        ReadInput();
        Solve();
    }
    public void ReadInput() {
        File.ReadLines("E:\\Advent\\Advent2024\\Advent2024\\Input\\Day1.txt").ToList().ForEach(line => {
            string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            leftInput.Add(int.Parse(parts[0]));
            rightInput.Add(int.Parse(parts[1]));
        });
    }
    public void Solve() {
        SolvePartOne(); // 1765812
        SolvePartTwo();
    }
}