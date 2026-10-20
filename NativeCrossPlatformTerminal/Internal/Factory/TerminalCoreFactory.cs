namespace NativeTerminal.Internal.Factory
{
    /// <summary>
    ///  Creates ITerminalCore objects.
    /// </summary>
    internal static class TerminalCoreFactory 
    {
        // Creates core terminal.
        internal static ITerminalCore ConstructCoreTerminal()
            => new TerminalCore();
    }
}