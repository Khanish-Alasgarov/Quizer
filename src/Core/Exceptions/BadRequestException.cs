using System.Runtime.Serialization;

namespace Core.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException() : base()
    {
    }
    public BadRequestException(string message) : base(message)
    {

    }
    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {

    }
    public BadRequestException(SerializationInfo info, StreamingContext context)
    : base(info, context)
    {

    }
}
