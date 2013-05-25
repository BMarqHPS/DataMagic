namespace OrderProcessingLibrary.Utilities
{
    using System;

    public class ProgressBarEventArgs : EventArgs
    {
        private readonly int value;
        private readonly int maxValue;

        public ProgressBarEventArgs() {}

        public ProgressBarEventArgs(int value, int maxValue)
        {
            this.value = value;
            this.maxValue = value;
        }

        public int Value { get { return value; } }

        public int MaxValue { get { return maxValue; } }
    }
}
