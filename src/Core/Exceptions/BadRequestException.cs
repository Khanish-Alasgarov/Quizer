using System.Runtime.Serialization;

namespace Core.Exceptions;

public class BadRequestException : Exception
{
    public Dictionary<string, string[]> Errors;
    public BadRequestException() : base()
    {
    }
    public BadRequestException(string message) : base(message)
    {

    }
    public BadRequestException(string message, Dictionary<string, string[]> errors) : base(message)
    {
        this.Errors = errors;
    }
    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {

    }
    public BadRequestException(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {

    }
}
