using Advent2024.Common;
using System.Runtime.CompilerServices;
public class Day3 : IDay {

    //private string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    //private string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
    private string input = "";
    public Day3() {
        ReadInput();
        Solve();
    }
    public void ReadInput() {
        input = File.ReadAllText("E:\\Advent\\Advent2024\\Advent2024\\Input\\Day3.txt");
    }
    private void SolvePartOne() {
        int index = 0;
        long result = 0;
        while (index < input.Length && input.IndexOf("mul", index) != -1) {
            index = input.IndexOf("mul", index);
            if (index + 3 < input.Length && input[index + 3] == '(') {
                int start = index + 3;
                int end = input.IndexOf(")", start);
                if (start != -1 && end != -1 && end - start - 1 <= 7 && end - start - 1 >= 3) {
                    string[] parts = input.Substring(start + 1, end - start - 1).Split(',');
                    if (parts.Length == 2 &&
                        parts[0].Length <= 3 &&
                        parts[0].Length > 0 &&
                        parts[1].Length > 0 &&
                        parts[1].Length <= 3 &&
                        int.TryParse(parts[0], out int num1) &&
                        int.TryParse(parts[1], out int num2)) {
                        result += num1 * num2;
                        index = end + 1;
                        continue;
                    }
                }
            }
            index += 3;
        }
        Console.WriteLine($"Part one - result: {result}");
    }
    private void SolvePartTwo() {
        int index = 0;
        long result = 0;
        while (index < input.Length) {
            int doIndex = input.IndexOf("do()", index);
            int dontIndex = input.IndexOf("don't()", index);
            int start = input.IndexOf("mul", index);

            if (start == -1)
                break;

            if (dontIndex < start && (doIndex > start || doIndex == -1 || doIndex < dontIndex)) {
                if (doIndex != -1) {
                    index = doIndex + 4;
                    continue;
                }
                break;
            }
            // mul(...)dont()do()
            // mul(...)do() mul() dont()
            if (start + 3 < input.Length && input[start + 3] == '(') {
                int innerStart = start + 3;
                int innerEnd = input.IndexOf(')', innerStart);
                if (innerEnd != -1 && innerEnd - innerStart - 1 <= 7 && innerEnd - innerStart - 1 >= 3) {
                    string[] parts = input.Substring(innerStart + 1, innerEnd - innerStart - 1).Split(',');
                    if (parts.Length == 2 &&
                        parts[0].Length <= 3 &&
                        parts[0].Length > 0 &&
                        parts[1].Length > 0 &&
                        parts[1].Length <= 3 &&
                        int.TryParse(parts[0], out int num1) &&
                        int.TryParse(parts[1], out int num2)) {
                        result += num1 * num2;
                        index = innerEnd + 1;
                        continue;
                    }
                }

            }
            index += 3;
        }
        Console.WriteLine($"Part two - result: {result}");
    }
    public void Solve() {
        SolvePartOne(); // 187825547
        SolvePartTwo();
    }
}

