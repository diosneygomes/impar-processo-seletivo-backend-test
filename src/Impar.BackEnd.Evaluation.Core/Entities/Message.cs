namespace Impar.BackEnd.Evaluation.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string MessageContent { get; set; }

        public DateTime SentAt { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
