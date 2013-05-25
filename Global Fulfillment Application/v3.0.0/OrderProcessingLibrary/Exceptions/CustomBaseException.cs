namespace OrderProcessingLibrary.Exceptions
{
    using System;
    using System.Text;

    public abstract class CustomBaseException : Exception
    {

        protected CustomBaseException(string message, Exception ex)
            : base(message, ex)
        {
        }

        protected CustomBaseException(string message)
            : base(message)
        {
        }


        private string BuildExceptionMessage()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("\n\n{0}\n", Message);
            if (InnerException != null)
            {
                sb.AppendFormat("\nInner Exception : \n   {0}\n", InnerException.Message);
                sb.AppendFormat("\nStack Trace :\n   {0}\n", InnerException.StackTrace);
            }

            return sb.ToString();
        }


        public string ExceptionLogMessage
        {
            get { return BuildExceptionMessage(); }
        }

    }
}
