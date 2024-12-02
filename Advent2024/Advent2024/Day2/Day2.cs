using Advent2024.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Day2 : IDay {
    private List<List<int>> reports = [];

    private bool isSafeReport(List<int> report) {
        if(report.Count < 2) {
            return true;
        }
        bool decrease = (report[0] > report[1]); // either decrease/increase
        for (int index = 1; index < report.Count; ++index) {
            if (
                (decrease && report[index - 1] <= report[index]) ||
                (!decrease && report[index - 1] >= report[index] ||
                (Math.Abs(report[index - 1] - report[index]) > 3))
               ) {
                return false;
            }
        }

        return true;
    }
    private void SolvePartOne() {
        int result = 0;
        foreach(var report in reports) {
            if(isSafeReport(report)) {
                ++result;
            }
        }
        Console.WriteLine($"Part one - safe reports: {result}");
    }
    private void SolvePartTwo() {
        int result = 0;
        void consider(int index, List<int> report, ref bool isOk) {
            var newReport = new List<int>(report);
            newReport.RemoveAt(index);
            if (isSafeReport(newReport)) {
                isOk = true;
            }
        }
        foreach (var report in reports) {
            bool isOk = false;
            if(isSafeReport(report)) {
                isOk = true;
                ++result;
                continue;
            }
            //consider(0, report, ref isOk);
            for(int i = 0; i < report.Count-1; i++) {
                int diff = report[i] - report[i + 1];
                if (Math.Abs(diff) == 0 || Math.Abs(diff) > 3) {
                    consider(i, report, ref isOk);
                    consider(i + 1, report, ref isOk);
                    break;
                }
                // 5 8 4 OR 10 9 11
                if(i+2 < report.Count) {
                    int aheadDiff = report[i + 1] - report[i + 2];
                    if(Math.Sign(diff) != Math.Sign(aheadDiff)) {
                        consider(i, report, ref isOk);
                        consider(i + 1, report, ref isOk);
                        consider(i + 2, report, ref isOk);
                        break;
                    }
                }
            }
            if(isOk) {
                ++result;
            }
        }
        Console.WriteLine($"Part two - safe reports: {result}");
    }
    public Day2() {
        ReadInput();
        Solve();
    }
    public void ReadInput() {
        File.ReadLines("E:\\Advent\\Advent2024\\Advent2024\\Input\\Day2.txt").ToList().ForEach(line => {
            reports.Add(line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
        });
    }
    public void Solve() {
        SolvePartOne();
        SolvePartTwo();
    }
}
