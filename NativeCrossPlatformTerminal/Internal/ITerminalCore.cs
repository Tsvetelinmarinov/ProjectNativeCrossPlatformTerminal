namespace NativeTerminal.Internal
{
    /// <summary>
    ///  Defines core terminal.
    /// </summary>
    internal interface ITerminalCore
    {
        int WriteCore(string? text);
    }
}