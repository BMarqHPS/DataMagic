namespace OrderProcessingLibrary.Utilities
{
    using System;

    public class StatusBarEventArgs : EventArgs
    {
        private readonly string statusText;

        public StatusBarEventArgs(string text)
        {
            statusText = text;
        }

        public string StatusText { get { return statusText; } }
    }
}
