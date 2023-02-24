// See https://aka.ms/new-console-template for more information
using LeetCodeChallenges.Hard;

var sol = new Solution();
Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 10, 30, 50, 70, 90 }, new int[] { 0, 20, 40, 60, 80, 100, 120 }));
Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 0, 1 }, new int[] { 2, 3, }));
Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 0, 1 }, new int[] { 2, 3, 10 }));
Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 1,3 }, new int[] { 2 }));
Console.WriteLine(sol.FindMedianSortedArrays(new int[] { 0,1,2,3,4,5 }, new int[] { 8,10,20,21,52,100 }));