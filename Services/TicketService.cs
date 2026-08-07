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
            NewTicketAdd(ticket);

            _ticketData.Add(ticket);
        }

        public void Delete(Guid id)
        {
            var ticket = GetById(id);
            _ticketData.Delete(ticket);
        }

        public void Update(Ticket ticket)
        {
            GetById(ticket.Id);
            _ticketData.Update(ticket);
        }

        public Ticket GetById(Guid id)
        {
            ValidateIfTicketIdIsEmpty(id);

            var ticket = _ticketData.GetById(id);

            ValidateIfTicketIsNotNull(ticket, id);

            return ticket;
        }

        private static void ValidateIfTicketIdIsEmpty(Guid id)
        {
            if (id == Guid.Empty)
                throw new TicketNotFoundException(id);
        }

        private static void ValidateIfTicketIsNotNull([NotNull] Ticket? ticket, Guid id)
        {
            if (ticket == null)
                throw new TicketNotFoundException(id);
        }

        private static void NewTicketAdd(Ticket ticket)
        {
            ticket.Status = "New";
            ticket.CreatedAt = DateTime.Now;
        }

    }
}
