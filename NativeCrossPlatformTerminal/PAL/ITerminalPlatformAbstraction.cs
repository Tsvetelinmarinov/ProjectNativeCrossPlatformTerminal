namespace NativeTerminal.PAL
{
    // Exist for IoC and code security.
    internal unsafe interface ITerminalPlatformAbstraction
    {
        // Gets pointer to the standard input or output streams.
        void* GetPointerToStandardStream(int standardStreamCode);
    }
}