using System;

namespace NativeTerminal.PAL
{
    // Exist for IoC and code security.
    internal interface ITerminalPlatformAbstraction
    {
        // Gets pointer to the standard input or output streams.
        IntPtr GetPointerToStandardStream(int standardStreamCode);
    }
}