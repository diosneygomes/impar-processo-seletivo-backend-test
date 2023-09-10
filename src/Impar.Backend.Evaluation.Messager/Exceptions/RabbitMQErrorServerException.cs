namespace Impar.Backend.Evaluation.Messager.Exceptions
{
    public class RabbitMQErrorServerException : Exception
    {
        public RabbitMQErrorServerException()
        {
        }

        public RabbitMQErrorServerException(string message)
            : base(message)
        {
        }

        public RabbitMQErrorServerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
