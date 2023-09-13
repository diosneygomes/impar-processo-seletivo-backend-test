using Impar.BackEnd.Evaluation.Core.Exceptions;

namespace Impar.BackEnd.Evaluation.Core.Entities
{
    public class User
    {
        public User(
            int id,
            string name,
            string email,
            string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;

            this.Validate();
        }


        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public virtual IEnumerable<Message> Messages { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new DomainException("User without name!");
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                throw new DomainException("User without e-mail!");
            }

            if (string.IsNullOrEmpty(this.Phone))
            {
                throw new DomainException("User without phone!");
            }
        }
    }
}
