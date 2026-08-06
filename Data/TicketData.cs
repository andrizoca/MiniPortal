using MiniPortal.Models;

namespace MiniPortal.Data
{
    public class TicketData : ITicketData
    {
        private static readonly List<Ticket> _tickets = new()
        {
            new Ticket
            {
                Id = 1,
                Title = "Error accessing portal",
                Description = "User receives an access denied message.",
                Status = "Open",
                CreatedAt = DateTime.Now
            },
            new Ticket
            {
                Id = 2,
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
            ticket.Id = _tickets.Count + 1;
            ticket.CreatedAt = DateTime.Now;
            _tickets.Add(ticket);
        }

        public Ticket? GetById(int id)
        {
            return _tickets.FirstOrDefault(t => t.Id == id);
        }
    }
}
