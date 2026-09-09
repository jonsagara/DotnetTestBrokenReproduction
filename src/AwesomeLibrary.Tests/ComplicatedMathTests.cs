namespace AwesomeLibrary.Tests;

public class ComplicatedMathTests
{
    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 3, 5)]
    public void Add_ReturnsCorrectResult(int a, int b, int result)
    {
        Assert.Equal(expected: result, actual: ComplicatedMath.Add(a, b));
    }
}
