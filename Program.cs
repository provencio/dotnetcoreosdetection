using OSDetection;

var info = PlatformInfo.Detect();

Console.WriteLine($"OS Platform: {info.Platform}");
Console.WriteLine($"OS Description: {info.OSDescription}");
Console.WriteLine($"OS Version: {info.OSVersion}");
Console.WriteLine($"Path directory separator: {info.DirectorySeparator}");
Console.WriteLine($"OS/Process Architecture: {info.OSArchitecture}/{info.ProcessArchitecture}");
Console.WriteLine($"Runtime Identifier: {info.RuntimeIdentifier}");
Console.WriteLine($"Framework Description: {info.FrameworkDescription}");
