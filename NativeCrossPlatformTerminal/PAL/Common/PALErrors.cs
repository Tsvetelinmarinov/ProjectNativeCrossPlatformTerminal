namespace NativeTerminal.PAL.Common
{
    /// <summary>
    ///  Provides common constant error messages for the 
    ///  Platform Adaptation Layer types.
    /// </summary>
    internal static class PALErrors
    {
        internal const string OnlyWin32 = "PAL: Only Windows OS supports that functionality! Operation canceled!";
        internal const string StdStreamPtrError = "Unable to get pointer to the specified stream. Internal error!";
        internal const string ErrorWritingToStdOut = "Error while writing the data to the standard output stream!";
    }
}