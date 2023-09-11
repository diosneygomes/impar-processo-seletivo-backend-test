namespace Impar.BackEnd.Evaluation.Core.Entities
{
    public class Message
    {
        public Message(
            string subject,
            string messageContent,
            int userId)
        {
            this.Subject = subject;
            this.MessageContent = messageContent;
            this.UserId = userId;
            this.SentAt = DateTime.UtcNow;
        }

        public int Id { get; private set; }

        public string Subject { get; private set; }

        public string MessageContent { get; private set; }

        public DateTime SentAt { get; private set; }

        public int UserId { get; private set; }

        //public virtual User User { get; set; }
    }
}
