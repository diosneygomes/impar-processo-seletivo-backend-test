namespace Impar.BackEnd.Evaluation.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual IEnumerable<Message> Messages { get; set; }
    }
}
