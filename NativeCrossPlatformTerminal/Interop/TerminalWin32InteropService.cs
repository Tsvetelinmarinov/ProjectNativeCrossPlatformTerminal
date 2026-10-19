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

        #endregion
    }
}