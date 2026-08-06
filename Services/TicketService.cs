using MiniPortal.Data;
using MiniPortal.Exceptions;
using MiniPortal.Models;
using System.Diagnostics.CodeAnalysis; 

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

        public Ticket GetById(int id)
        {
            ValidateIfTicketIdIsZero(id);

            var ticket = _ticketData.GetById(id);

            ValidateIfTicketIsNotNull(ticket, id);

            return ticket;
        }

        private static void ValidateIfTicketIdIsZero(int id)
        {
            if (id == 0)
                throw new TicketNotFoundException(id);
        }

        private static void ValidateIfTicketIsNotNull([NotNull] Ticket? ticket, int id)
        {
            if (ticket == null)
                throw new TicketNotFoundException(id);
        }

    }
}
