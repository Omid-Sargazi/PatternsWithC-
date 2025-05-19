// See https://aka.ms/new-console-template for more information
using SolvingProblems.Problems;

Console.WriteLine("Hello, World!");
var problems = new Problems();

var nums = new int[] { 2, 7, 41, 52 };
var target = 9;
var result = problems.TwoSum(nums, target);
foreach (var num in result)
{
    Console.WriteLine(num);
}


NumberOf1Bits bits = new NumberOf1Bits();
Console.WriteLine(bits.NumberOfoneBit(120));


Console.WriteLine($"{12/2}");