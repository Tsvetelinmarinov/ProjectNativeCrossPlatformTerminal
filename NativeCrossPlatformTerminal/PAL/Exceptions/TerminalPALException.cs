using System;

namespace NativeTerminal.PAL.Exceptions
{
    /// <summary>
    ///  Special exception that is throws from the 
    ///  Platform Adaptation Layer types.
    /// </summary>
    internal class TerminalPALException(string error) : Exception(error)
    {
        /// <summary>
        ///  Throws TerminalPALException with the <paramref name="errorMessage"/>.
        /// </summary>
        /// <param name="errorMessage">
        ///  The error message to be shown.
        /// </param>
        internal static void Throw(string error)
            => throw new TerminalPALException(error);
    }
}