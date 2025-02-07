using RandomStringGenerator;

/// <summary>
/// A simple console application that generates a random string of a given length. - Mark Turchik
/// </summary>
Console.WriteLine("Random String Generator");
Console.WriteLine("Enter 'x' to exit.");

var timeout = new Timer((object? state) =>
{
    Console.WriteLine();
    Console.WriteLine("Timeout. Exiting...");
    Environment.Exit(0);
}, new { }, TimeSpan.FromMinutes(3), Timeout.InfiniteTimeSpan);

string? input;
do
{
    timeout.Change(TimeSpan.FromMinutes(3), Timeout.InfiniteTimeSpan);

    Console.WriteLine();
    Console.Write("Enter the length of the string you want to generate: ");
    input = Console.ReadLine();
    if (int.TryParse(input, out var length))
    {
        Console.WriteLine("Generating... ");
        string randomStr;
        try
        {
            randomStr = StringGenerator.GenerateRandomString(length);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        var randomStrDisplay = randomStr.Length > 100 ? randomStr[..100] + $" (+ {randomStr.Length - 100} chars)" : randomStr;
        Console.WriteLine(randomStrDisplay);

        Console.Write("Copy to Clipboard? [Y/N]: ");
        var copy = Console.ReadLine();
        if (copy?.ToLower() == "y")
        {
            TextCopy.ClipboardService.SetText(randomStr);
            Console.WriteLine("Copied to clipboard.");
        }
        else Console.WriteLine("Skipping clipboard copy.");

    }
    else Console.WriteLine("Invalid input. Please enter a valid number.");

} while (input?.ToLower() != "x");
