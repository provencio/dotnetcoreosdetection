# OSDetection

A small .NET console app that reports what operating system and runtime it is running on.
It started as an experiment in how to do OS detection in .NET, so the detection logic is kept
in a single reusable file.

## Output

```
OS Platform: macOS
OS Description: macOS 27.0.0
OS Version: 27.0.0
Path directory separator: /
OS/Process Architecture: Arm64/Arm64
Runtime Identifier: osx-arm64
Framework Description: .NET 10.0.12
```

Platform is one of Linux, Windows, macOS, FreeBSD, or Other.

## Building a standalone executable

Publishing for a specific platform produces a single executable with the .NET runtime bundled in,
so it runs on machines that don't have .NET installed. You can build every platform from one machine
(requires the [.NET 10 SDK](https://dotnet.microsoft.com/download)):

```sh
for rid in win-x64 win-arm64 linux-x64 linux-arm64 linux-musl-x64 osx-x64 osx-arm64; do
  dotnet publish -c Release -r $rid -o publish/$rid
done
```

Each executable is roughly 35–40 MB. It runs on any OS version that
[.NET 10 supports](https://github.com/dotnet/core/blob/main/release-notes/10.0/supported-os.md).
Because the runtime is bundled, "Framework Description" reports that bundled runtime, not anything
installed on the machine.

During development, `dotnet run` works as usual.

## Using the detection code in another app

`PlatformInfo.cs` has no dependencies. Copy it into your project (change the namespace if you like) and call:

```csharp
var info = PlatformInfo.Detect();

if (info.Platform == "Linux") { /* ... */ }
```

If you only need a single check, call `OperatingSystem.IsLinux()`, `IsWindows()`, or `IsMacOS()` directly.
