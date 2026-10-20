using System;

namespace NativeTerminal.PAL
{
    /// <summary>
    ///  Platform Adaptation Layer class for the Terminal.
    ///  Communicates with the interoperability service and
    ///  converts high-level C# data types to low-level C data types.
    ///  Abstracts the operating system.
    /// </summary>
    internal sealed class TerminalPAL : ITerminalPlatformAbstraction
    {
        /// <summary>
        /// Gets pointer to the standard input or output streams.
        /// </summary>
        /// <param name="standardStreamCode">
        ///  The code of the standard stream: 
        ///  STDIN = -10, STDOUT = -11.
        /// </param>
        /// <returns>
        ///  Pointer to the specified stream.
        /// </returns>
        public IntPtr GetPointerToStandardStream(int standardStreamCode)
        {
            // Check the OS - only Windows supports that!
            if (OperatingSystem.IsWindows() is false)
            {

            }
        }
    }
}