namespace DDDNET8.Domain.Exceptions
{
    public sealed class InputException : ExceptionBase
    {
        public InputException(string message) : base(message) { }

        public override ExceptionKind Kind => ExceptionKind.Information;
    }
}
