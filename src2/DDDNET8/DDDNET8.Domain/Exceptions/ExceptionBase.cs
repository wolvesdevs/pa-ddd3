namespace DDDNET8.Domain.Exceptions;
public abstract class ExceptionBase : Exception
{
    public abstract ExceptionKind Kind { get; }

    public enum ExceptionKind
    {
        Information,
        Warning,
        Error,
    }

    protected ExceptionBase(string message) : base(message) { }
    protected ExceptionBase(string message, Exception exception) : base(message, exception) { }
}
