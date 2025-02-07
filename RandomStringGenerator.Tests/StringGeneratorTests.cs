namespace RandomStringGenerator.Tests;

[TestClass]
public sealed class StringGeneratorTests
{
    [DataTestMethod]
    [DataRow(10, DisplayName = "10")]
    [DataRow(20, DisplayName = "20")]
    [DataRow(30, DisplayName = "30")]
    [DataRow(4000, DisplayName = "4,000")]
    [DataRow(50000, DisplayName = "50,000")]
    [DataRow(600000, DisplayName = "600,000")]
    [DataRow(7000000, DisplayName = "7,000,000")]
    [DataRow(99999999, DisplayName = "99,999,999")]
    public void GenerateRandomString_ValidLength_ReturnsStringOfGivenLength(int length)
    {
        // Act
        var result = StringGenerator.GenerateRandomString(length);
        // Assert
        Assert.AreEqual(length, result.Length);
    }

    [DataTestMethod]
    [DataRow(-1, DisplayName = "-1")]
    [DataRow(100000000, DisplayName = "100,000,000")]
    public void GenerateRandomString_InvalidLength_ThrowsException(int length)
    {
        // Act
        static void Act(int length)
        {
            StringGenerator.GenerateRandomString(length);
        }
        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => Act(length));
    }

    [TestMethod]
    public void GenerateRandomString_ZeroLength_ReturnsEmptyString()
    {
        // Arrange
        const int length = 0;
        // Act
        var result = StringGenerator.GenerateRandomString(length);
        // Assert
        Assert.AreEqual(string.Empty, result);
    }
}
