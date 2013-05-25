namespace OrderProcessingLibrary.Exceptions
{
    public class MissingFileException : CustomBaseException
    {
        public MissingFileException(string fileName)
            : base("File '" + fileName + "' not found.")
        { }
    }
}
