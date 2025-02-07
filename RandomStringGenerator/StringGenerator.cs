namespace RandomStringGenerator;


/// <summary>
/// This class generates a random strings.
/// </summary>
public static class StringGenerator
{
    private static char[] CharSet { get; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
    private static int CharSetLength => CharSet.Length;
    private static int OneHundredMillion => 100000000;

    /// <summary>
    /// Generates a random string of a given length.
    /// </summary>
    /// <param name="length">Length of string to generate</param>
    /// <returns>Random string</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when length is less than 0 or greater than 1,000,000,000</exception></exception>
    public static string GenerateRandomString(int length)
    {
        if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");
        if (length >= OneHundredMillion) throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be greater than to 100,000,000.");

        // Leveraging Span<T> can minimize heap allocations and improve performance, especially with large strings.
        Span<char> result = length <= 1024 ? stackalloc char[length] : new char[length];
        Span<byte> randomBytes = length <= 1024 ? stackalloc byte[length] : new byte[length];

        Random.Shared.NextBytes(randomBytes);
        for (var i = 0; i < length; i++)
            result[i] = CharSet[randomBytes[i] % CharSetLength];

        return new string(result);
    }
}