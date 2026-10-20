using System.Runtime.CompilerServices;

namespace NativeTerminal.Internal.Factory
{
    internal interface ITerminalCoreFactory
    {
        ITerminalCore ConstructCoreTerminal();
    }
}