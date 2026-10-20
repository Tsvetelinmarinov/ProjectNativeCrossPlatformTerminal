namespace NativeTerminal.PAL
{
    /// <summary>
    ///  Creates <see cref="TerminalPAL"/> instances and returns them as <see cref="ITerminalPlatformAbstraction"/>.
    /// </summary>
    internal static class TerminalPALFactory
    {
        internal static ITerminalPlatformAbstraction ConstructTerminalCore()
            => new TerminalPAL();
    }
}