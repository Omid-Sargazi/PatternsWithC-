// See https://aka.ms/new-console-template for more information
using LeetCode02.MaxSubArray;

Console.WriteLine("Hello, World!");
var solution = new Solution();
int[] array = [-2, 1, -3, 4, -1, 2, 1, -5, 4];
int result = solution.MaxSubArray(array);
Console.WriteLine(result); // Output: 6