namespace Impar.BackEnd.Evaluation.Service.Exceptions
{
    public class GetEntityException : Exception
    {
        public GetEntityException()
        {
        }

        public GetEntityException(string message)
            : base(message)
        {
        }

        public GetEntityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
