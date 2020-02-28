using System;

namespace OSDetection
{
    class Program
    {
        static void Main(string[] args)
        {

            string OSPlatform = "";

            if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux))
            {
                OSPlatform = "Linux";
            }
            else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
            {
                OSPlatform = "Windows";
            } 
            else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
            {
                OSPlatform = "OSX";
            }
            else
            {
                OSPlatform = "Other";
            }

            Console.WriteLine($"OS Platform: {OSPlatform}");
            Console.WriteLine($"OS Description: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
            Console.WriteLine($"Path directory seperator: {System.IO.Path.DirectorySeparatorChar}");
            Console.WriteLine($"OS/Process Architecture: {System.Runtime.InteropServices.RuntimeInformation.OSArchitecture}/{System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture}");
            Console.WriteLine($"Framework Description: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");

        }
    }
}
