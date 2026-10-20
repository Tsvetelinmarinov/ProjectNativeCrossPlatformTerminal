namespace NativeTerminal.Interop.Common.IOCodes
{
    /// <summary>
    ///  Specifies terminal input/output stream in C function GetStdHandle(int terminalIOCode).
    /// </summary>
    internal enum TerminalIOCode : int
    {
        /// <summary>
        ///  Specifies the standard input stream.
        /// </summary>
        STDIN = -10,

        /// <summary>
        ///  Specifies the standard output stream.
        /// </summary>
        STDOUT = -11
    }
}