using NativeTerminal.PAL;

namespace NativeTerminal.Internal
{
    /// <summary>
    ///  Defines terminal core.
    ///  Provides base functionality of a cross-platform terminal.
    /// </summary>
    internal class TerminalCore : ITerminalCore
    {
        // PAL class for core functionality.
        private readonly ITerminalPlatformAbstraction _terminalPal;


        // Internal constructor.
        internal TerminalCore()
        {
            this._terminalPal = TerminalPALFactory.ConstructTerminalCore();
        }


        /// <summary>
        ///  Writes the text to the standard output stream.
        /// </summary>
        /// <param name="text">
        ///  The text to be written.
        /// </param>
        /// <returns>
        ///  The count of the written characters.
        /// </returns>
        public int WriteCore(string? text)
            => this._terminalPal.WritePAL(text);
    }
}