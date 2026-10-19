using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NativeTerminal.Interop.Common.NativeLibraries;

namespace NativeTerminal.Interop
{
    /// <summary>
    ///  Windows interoperability service for kernel32 Win API.
    ///  Provides core functionality for terminal I/O operations.
    /// </summary>
    internal static partial class TerminalWin32InteropService
    {
        #region Internal P/Invoke Declarations Wrappers

        // Wraps the private unmanaged C function Unmanaged_GetStdHandle.
        internal static unsafe void* GetStdHandle(int terminalIoCode)
            => Unmanaged__GetStdHandle(terminalIoCode);

        // Wraps the private unmanaged C function Unmanaged_WriteConsoleW.
        internal static unsafe bool WriteConsoleW(
            void* outputStreamPointer,
            char* dataBufferPointer,
            uint numberOfCharsToWrite,
            out uint numberOfCharsWritten
        ) {
            return Unmanaged__WriteConsoleW(
                outputStreamPointer,
                dataBufferPointer,
                numberOfCharsToWrite,
                out numberOfCharsWritten,
                null
            );
        }

        #endregion
        #region Private P/Invoke Declarations

        #region GetStdHandle P/Invoke Logic

        // Gets pointer to the specified(input or output) system stream.
        // TerminalIOCode.STDIN specifies the standard input stream and
        // TerminalIOCode.STDOUT specifies the standard output stream.
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
            CLibraries.Kernel32Win,
            EntryPoint = "GetStdHandle",
            SetLastError = true,
            StringMarshalling = StringMarshalling.Utf16
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        private static unsafe partial void* Unmanaged__GetStdHandle(int terminalIoCode);

        #endregion
        #region WriteConsoleW P/Invoke Logic

        // Writes the specified buffer with text(bufferPointer) to the console output stream.
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [LibraryImport(
          CLibraries.Kernel32Win,
            EntryPoint = "WriteConsoleW",
            StringMarshalling = StringMarshalling.Utf16,
            SetLastError = true
        )]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static unsafe partial bool Unmanaged__WriteConsoleW(
            void* systemIoStreamPointer, // Pointer to the system input/output stream.
            char* dataBufferPointer, // Pointer to the string/char[] with the text to write.
            uint numberOfCharsToWrite, // How much chars from the buffer to be written.
            out uint numberOfCharsWritten, // Number of successfully written chars.
            void* optionalControlPointer // Additional control pointer: in our cases(read/write) - always null.
        );

        #endregion

        #endregion
    }
}