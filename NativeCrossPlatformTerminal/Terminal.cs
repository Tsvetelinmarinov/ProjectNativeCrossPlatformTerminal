using NativeTerminal.Internal;
using NativeTerminal.Internal.Factory;

namespace NativeTerminal
{
    /// <summary>
    ///  Provides standard I/O operations.
    /// </summary>
    public static class Terminal
    {
        #region Private 
        // Core terminal
        private static readonly ITerminalCore s_terminalCore;


        // Static ctor.
        static Terminal()
        {
            s_terminalCore = TerminalCoreFactory.ConstructCoreTerminal();
        }

        #endregion
        #region Functionality

        /// <summary>
        ///  Writes the text to the standard output stream.
        /// </summary>
        /// <param name="text">
        ///  The text to be written.
        /// </param>
        /// <returns>
        ///  The count of the written characters.
        /// </returns>
        public static void Write(string? text)
            => s_terminalCore.WriteCore(text);

        #endregion
    }
}