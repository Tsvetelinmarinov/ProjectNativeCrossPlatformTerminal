namespace NativeTerminal.PAL
{
    /// <summary>
    ///  Creates <see cref="TerminalPAL"/> instances and returns them as <see cref="ITerminalPlatformAbstraction"/>.
    /// </summary>
    internal static class TerminalFactory
    {
        internal static ITerminalPlatformAbstraction ConstructTerminalCore()
            => new TerminalPAL();
    }
}