using System.Runtime.InteropServices;

namespace OSDetection;

/// <summary>
/// A snapshot of the operating system and runtime the current process is running on.
/// Self-contained with no dependencies, so this file can be copied into another project as-is.
/// </summary>
public sealed record PlatformInfo(
    string Platform,
    string OSDescription,
    Version OSVersion,
    char DirectorySeparator,
    Architecture OSArchitecture,
    Architecture ProcessArchitecture,
    string RuntimeIdentifier,
    string FrameworkDescription)
{
    /// <summary>Detects the platform of the current process.</summary>
    public static PlatformInfo Detect() => new(
        Platform: DetectPlatform(),
        // Human-readable OS name and version, e.g. "Darwin 25.0.0" or "Microsoft Windows 10.0.26100".
        OSDescription: RuntimeInformation.OSDescription,
        // Kernel version on Linux/macOS, Windows build number on Windows.
        OSVersion: Environment.OSVersion.Version,
        DirectorySeparator: Path.DirectorySeparatorChar,
        // These differ when, for example, an x64 process runs under emulation on an Arm64 OS.
        OSArchitecture: RuntimeInformation.OSArchitecture,
        ProcessArchitecture: RuntimeInformation.ProcessArchitecture,
        // The platform this runtime was built for, e.g. "osx-arm64".
        RuntimeIdentifier: RuntimeInformation.RuntimeIdentifier,
        // The runtime executing this code. In a self-contained app this is the bundled
        // runtime, not whatever may be installed on the machine.
        FrameworkDescription: RuntimeInformation.FrameworkDescription);

    // OperatingSystem.Is*() (.NET 5+) is the simplest check. On older frameworks use
    // RuntimeInformation.IsOSPlatform(OSPlatform.Linux) and so on instead.
    private static string DetectPlatform() =>
        OperatingSystem.IsLinux()   ? "Linux"   :
        OperatingSystem.IsWindows() ? "Windows" :
        OperatingSystem.IsMacOS()   ? "macOS"   :
        OperatingSystem.IsFreeBSD() ? "FreeBSD" :
        "Other";
}
