# Advent-of-Code-2024
Me attempting advent of codes for the first time, here in 2024 while learning C#


# Day 1: Distances & Similarity
  ## Part One 
  First glance approach would be sorting both left and right lists and then calculating the distances, that would result to be an **O(N log N)** approach where N is size of left/right lists.
  a good note, choosing an algorithm like quick-sort that does the sorting in-place to avoid extra space usage.
  
  Another approach which I used in my solution, is implementing a min-heap that is constructed using heapify-down (that would result in building the heap in linear time) and then building
  two heaps from both lists, extracting the minimum each time then calculating the needed. This approach would also result in an **O(N log N)**, noting N to be as above.

  ## Part Two:
  Constructing a hashmap to have the frequencies of each element in right list, then iterating over the left list calculating the similarity score, in total** O(N) time** and **O(N) space** 
  where N is size of left/right lists (both have same size).

# Day 2: Reports Containing Levels
Let the number of reports be **'T'** and the length of each report is **'N'** in average.

  ## Part One:
  Taking care of the cases where a report contains < 2 levels. Checking the constraints of 1 <= level-difference <= 3 for adjacent levels.
  Nothing special, with **O(T * N)** operations in average.

  ## Part Two:
  For each report, check if it is safe by using the method done previously, if so, then break, if not, consider the following cases:  
      * Difference between adjacent elements with indices i & i+1 is greater than 3 or less than 1, if so consider removing i, then consider removing i+1.  
      * Check if we have a pyramid/valley case, for e.g.: 5, 8, 3 or 7, 3, 9 - if so, then consider removing i, i+1, i+2.  
  When considering, remove the element and check if the report is safe now.
  We have made T * N * 3 on average, then we kept the **O(T * N)** same as first part.


# Day 3: Mul the do() and the don't()

  ## Part One:
  Do a while loop where you find "mul" from the starting index (this is important to process the characters only once), make checks using substring (constant time knowing
  the maximum length of mul arguments every time). We process only once, then it is **O(N) time and O(1) space**.
  
  ## Part Two:
  The time complexity here is the same as above, same tricks, just adding a flag to know whether we are adding the multiplication result or not.

# Day 4: Search for XMAS and an X shaped MAS & their reverse versions

  ## Part One:
  It is a simple DFS (obviously can be done without any recursion), where we process each element inside the board 8 times tops, meaning we still at  **O(M * N)** where M is rows, 
  N amount of columns.

  ## Part Two:
  Here we have actually less operations, approx. 3 * M * N iterations total, and the reason is because we only check per element the bottom-right diagonal and
  left bottom diagonal for the second element on the current element's right (X Y Z - referring to Z as second), **O(M * N)**.
  
