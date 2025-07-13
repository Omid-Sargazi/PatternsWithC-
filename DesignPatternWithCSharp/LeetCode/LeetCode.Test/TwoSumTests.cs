using LeetCode.Problem1;

namespace LeetCode.Test;

public class TwoSumTests
{
    [Fact]
    public void ReturnsCorrectIndices_ForSimpleInput()
    {
        var twoSum = new TwoSum();
        int[] result = twoSum.TwoSumRun(new int[] { 2, 7, 11, 15 }, 9);
        Assert.Equal(new int[] { 0, 1 }, result);
    }

    [Fact]
    public void HandlesDuplicateNumbers()
    {
        var twoSum = new TwoSum();
        int[] result = twoSum.TwoSumRun(new int[] { 3, 3 }, 6);
        Assert.Equal(new int[] { 0, 1 }, result);
    }

    [Fact]
    public void ReturnsEmptyArray_WhenNoSolution()
    {
        var solution = new TwoSum();
        int[] result = solution.TwoSumRun(new int[] { 1, 2, 3 }, 10);
        Assert.Equal(new int[] { }, result);
    }

}

public class CountUniqueTests
{
    [Fact]
    public void HandlesEmptyArray()
    {
        var countUniqeElemnts = new CountUniqueElements();
        var result = countUniqeElemnts.RunCountUniqueElements(new int[] { });
        Assert.Equal(0, result);
    }
}
