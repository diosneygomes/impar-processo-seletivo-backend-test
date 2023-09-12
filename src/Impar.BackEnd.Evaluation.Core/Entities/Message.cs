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

        public int Id { get; set; }

        public string Subject { get; set; }

        public string MessageContent { get; set; }

        public DateTime SentAt { get; set; }

        public int UserId { get; set; }

        //public virtual User User { get; set; }
    }
}
