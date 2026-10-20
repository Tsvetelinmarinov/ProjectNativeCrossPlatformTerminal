using System.Runtime.CompilerServices;

namespace NativeTerminal.Internal.Factory
{
    /// <summary>
    ///  Creates ITerminalCore objects.
    /// </summary>
    internal class TerminalCoreFactory : ITerminalCoreFactory
    {
        // Creates core terminal.
        public ITerminalCore ConstructCoreTerminal()
            => new TerminalCore();
    }
}