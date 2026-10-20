using System;

namespace NativeTerminal.PAL
{
    // Exist for IoC and code security.
    internal interface ITerminalPlatformAbstraction
    {
        int WritePAL(string? text);
    }
}