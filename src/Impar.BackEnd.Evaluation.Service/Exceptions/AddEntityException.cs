namespace Impar.BackEnd.Evaluation.Service.Exceptions
{
    public class AddEntityException : Exception
    {
        public AddEntityException()
        {
        }

        public AddEntityException(string message)
            : base(message)
        {
        }

        public AddEntityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
