using System;

namespace Student.Achieve.WebApi.Services.ImportSheet
{
    public class InvalidCellValueException : Exception
    {
        public InvalidCellValueException()
        {
        }

        public InvalidCellValueException(string message) : base(message)
        {
        }

        public InvalidCellValueException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
