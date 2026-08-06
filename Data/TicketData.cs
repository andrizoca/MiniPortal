using MiniPortal.Models;

namespace MiniPortal.Data
{
    public class TicketData : ITicketData
    {
        private static readonly List<Ticket> _tickets = new()
        {
            new Ticket
            {
                Id = Guid.NewGuid(),
                Title = "Error accessing portal",
                Description = "User receives an access denied message.",
                Status = "Open",
                CreatedAt = DateTime.Now
            },
            new Ticket
            {
                Id = Guid.NewGuid(),
                Title = "Report not loading",
                Description = "Screen keeps loading indefinitely when opening report.",
                Status = "In Progress",
                CreatedAt = DateTime.Now
            }
        };

        public List<Ticket> GetAll()
        {
            return _tickets;
        }

        public void Add(Ticket ticket)
        {
            ticket.Id = Guid.NewGuid();
            ticket.CreatedAt = DateTime.Now;
            _tickets.Add(ticket);
        }

        public Ticket? GetById(Guid id)
        {
            return _tickets.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(Ticket ticket)
        {
            _tickets.Remove(ticket);
        }
    }
}
