using MiniPortal.Data;
using MiniPortal.Models;

namespace MiniPortal.Services
{
    public class TicketService
    {
        private readonly ITicketData _ticketData;

        public TicketService(ITicketData ticketData)
        {
            _ticketData = ticketData;
        }

        public List<Ticket> GetAll()
        {
            return _ticketData.GetAll();
        }

        public void Add(Ticket ticket)
        {
            ticket.Status = "New";
            ticket.CreatedAt = DateTime.Now;

            _ticketData.Add(ticket);
        }

        public Ticket? GetById(int id)
        {
            return _ticketData.GetById(id);
        }
    }
}
