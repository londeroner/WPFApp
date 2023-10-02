using System;

namespace WPFApp.Helpers
{
    public class ErrorEventArgs : EventArgs
    {
        public ErrorModel Error { get; }
        public ErrorEventArgs(ErrorModel error)
        {
            Error = error;
        }
    }
}
