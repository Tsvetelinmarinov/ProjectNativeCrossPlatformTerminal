namespace NativeTerminal.Internal.Factory
{
    internal interface ITerminalCoreFactory
    {
        TerminalCore GetRawCoreTerminal();
        ITerminalCore Abstract();
    }
}