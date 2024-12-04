
using Advent2024.Common;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
public class Day4 : IDay {
    private int[][] directions = [
        [0, 1], // right
        [0, -1], // left
        [-1, 0], // up
        [1, 0], // down
        [1, 1], // diagonal down right 4
        [-1, -1], // diagonal up left
        [1, -1], // diagonal down left 6
        [-1, 1], // diagonal up right
    ];
    private Dictionary<char, char> expectedChar = new() {
        {'X', 'M'},
        {'M', 'A'},
        {'A', 'S'},
    };
    private Dictionary<char, char> expectedCharLeft = new() {
        { 'M', 'A'},
        {'A', 'S'},
    };
    private Dictionary<char, char> expectedCharRight = new() {
        {'S', 'A' },
        {'A', 'M'},
    };
    private List<char[]> puzzle = [];

    private void SolvePartOne() {
        int result = 0;
        void dfs(int rowId, int colId, int directionRow, int directionCol, char prevChar, int count) {
            if (count == 4) { // XMAS
                ++result;
                return;
            }
            if (rowId < puzzle.Count && colId < puzzle[0].Length && rowId >= 0 && colId >= 0) {
                if (expectedChar.TryGetValue(prevChar, out char value) && value == puzzle[rowId][colId]) {
                    dfs(rowId + directionRow, colId + directionCol, directionRow, directionCol, puzzle[rowId][colId], count + 1);
                }
            }
        }
        for (int rowId = 0; rowId < puzzle.Count; rowId++) {
            for (int colId = 0; colId < puzzle[rowId].Length; colId++) {
                if (puzzle[rowId][colId] == 'X') {
                    foreach (int[] direction in directions) {
                        dfs(rowId + direction[0], colId + direction[1], direction[0], direction[1], 'X', 1);
                    }
                }
            }
        }
        Console.WriteLine($"Part one - {result}");
    }
    private void SolvePartTwo() {
        int result = 0;
        for (int i = 0; i < puzzle.Count; ++i) {
            for (int j = 0; j < puzzle[0].Length; ++j) {
                if (i + 2 < puzzle.Count && j + 2 < puzzle[0].Length) {
                    string str1 = "", str2 = "";
                    int startLeftRow = i, startLeftCol = j, startRightRow = i, startRightCol = j + 2;
                    for (int times = 0; times < 3; ++times) {
                        str1 += puzzle[startLeftRow][startLeftCol];
                        str2 += puzzle[startRightRow][startRightCol];
                        startLeftRow += directions[4][0]; startLeftCol += directions[4][1];
                        startRightRow += directions[6][0]; startRightCol += directions[6][1];
                    }
                    if((str1 == "MAS" || str1 == "SAM") && (str2 == "MAS" || str2 == "SAM")) {
                        ++result;
                    }
                }
            }
        }
        Console.WriteLine($"Part two - {result}");
    }
    public Day4() {
        ReadInput();
        //foreach(char[] row in puzzle) {
        //    Console.WriteLine(row);
        //}
        Solve();
    }
    public void ReadInput() {

        File.ReadLines("E:\\Advent\\Advent2024\\Advent2024\\Input\\Day4.txt").ToList().ForEach(line => {
            line = line.Trim();
            puzzle.Add(line.ToCharArray());
        });
    }
    public void Solve() {
        SolvePartOne();
        SolvePartTwo();
    }
}