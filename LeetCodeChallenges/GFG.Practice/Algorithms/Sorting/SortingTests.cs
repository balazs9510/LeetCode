
using LeetCodeChallenges.Utils;
using Xunit;

namespace GFG.Practice.Algorithms.Sorting;

public class SortingTests
{

    [Theory]
    [MemberData(nameof(SortingTestData))]
    public void BubbleSortTests(int[] nums, int[] expected)
    {
        // Arrange
        var sorter = new BubbleSort();

        // Act
        var result = sorter.Sort(nums);

        // Assert
        AssertUtils.AssertTwoArraysIsEqual(expected, result);
    }


    [Theory]
    [MemberData(nameof(SortingTestData))]
    public void SelectionSortTests(int[] nums, int[] expected)
    {
        // Arrange
        var sorter = new SelectionSort();

        // Act
        var result = sorter.Sort(nums);

        // Assert
        AssertUtils.AssertTwoArraysIsEqual(expected, result);
    }

    [Theory]
    [MemberData(nameof(SortingTestData))]
    public void InsertionSortTests(int[] nums, int[] expected)
    {
        // Arrange
        var sorter = new InsertionSort();

        // Act
        var result = sorter.Sort(nums);

        // Assert
        AssertUtils.AssertTwoArraysIsEqual(expected, result);
    }


    //public static List<Type> SortingStrategies = new List<Type> { typeof(BubbleSort),  typeof(SelectionSort) };

    //public static IEnumerable<object[]> ComplexTestData => SortingStrategies.SelectMany()

    public static IEnumerable<object[]> SortingTestData => new List<object[]>
    {
        new object[] {new int[] { 4, 2, 6, 12, 35, 3 }, new int[] { 2, 3, 4, 6, 12, 35 } },
        new object[] {new int[] { 1, 2 }, new int[] { 1, 2 } },
        new object[] {new int[] { 0 }, new int[] { 0 } },
        new object[] {new int[] { int.MaxValue, 2, 3, int.MinValue }, new int[] { int.MinValue, 2, 3, int.MaxValue} },
    };
}
