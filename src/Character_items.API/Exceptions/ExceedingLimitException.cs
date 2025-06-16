namespace pazio_test2.API.Exceptions;

public class ExceedingLimitException : Exception
{
    public ExceedingLimitException(string msg) : base(msg)
    {
    }
}