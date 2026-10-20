using NativeTerminal.Interop;
using NativeTerminal.Interop.Common.IOCodes;
using NativeTerminal.PAL.Common;
using NativeTerminal.PAL.Exceptions;
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
        // Internal constructor.
        internal TerminalPAL()
        {
        }


        /// <summary>
        ///  Writes the text to the standard output.
        /// </summary>
        /// <param name="text">
        ///  The text to be written.
        /// </param>
        /// <returns>
        ///  The count of the written characters.
        /// </returns>
        public int WritePAL(string? text)
        {
            // If the text is null - empty string.
            text ??= string.Empty;

            // The count of the written characters
            // This is the return value.
            uint writtenChars = default;

            unsafe //=> Go unsafe to convert high-level to low-level data types
                  //=> and to call unmanaged C functions ...
            {
                // Get pointer to the standard output stream.
                void* outputStreamPointer =
                    TerminalWin32InteropService.GetStdHandle((int)TerminalIOCode.STDOUT);

                if (outputStreamPointer is null)
                {
                    TerminalPALException.Throw(PALErrors.StdStreamPtrError);
                }

                // The result of the printing operation.
                bool successPrint = default;

                // Fixing the char* here in the memory, because the GC 
                // may reclaim it in that exact moment, when the control
                // is in the Windows core not here. So in that case 
                // WriteConsoleW will try to write in not accessible anymore
                // memory that will result is AccessVolitionException.
                fixed (char* textPointer = text)
                {
                    // Try write and check for success.
                    if (OperatingSystem.IsWindows())
                    {
                        successPrint = TerminalWin32InteropService.WriteConsoleW(
                            outputStreamPointer,
                            textPointer,
                            (uint)text.Length,
                            out writtenChars
                        );

                        if (successPrint is false)
                        {
                            TerminalPALException.Throw(PALErrors.ErrorWritingToStdOut);
                        }

                        return (int)writtenChars;
                    }
                    else if (OperatingSystem.IsLinux())
                    {
                        throw new TerminalPALException("Linux is not supported for now.");
                    }
                    else if (OperatingSystem.IsMacOS())
                    {
                        throw new TerminalPALException("MacOS is not supported for now.");
                    }
                    else
                    {
                        throw new TerminalPALException(PALErrors.UnknownOS);
                    }
                }
            }
        }
    }
}