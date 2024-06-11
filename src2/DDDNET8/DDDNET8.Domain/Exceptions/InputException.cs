namespace DDDNET8.Domain.Exceptions
{
    public sealed class InputException : ExceptionBase
    {
        public override ExceptionKind Kind => ExceptionKind.Information;

        public InputException(string message) : base(message) { }
    }
}
