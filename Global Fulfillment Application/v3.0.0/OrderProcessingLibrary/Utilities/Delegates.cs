namespace OrderProcessingLibrary.Utilities
{
    public class Delegates
    {
        public delegate void ProgressBar(object sender, ProgressBarEventArgs e);

        public delegate void StatusBar(object sender, StatusBarEventArgs e);
    }
}
