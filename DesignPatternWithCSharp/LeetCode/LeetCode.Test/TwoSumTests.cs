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
}
