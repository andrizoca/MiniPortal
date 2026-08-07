using MiniPortal.Models;

namespace MiniPortal.Data
{
    public interface ITicketData
    {
        List<Ticket> GetAll();
        void Add(Ticket ticket);
        Ticket? GetById(Guid id);
        void Delete(Ticket ticket);
        void Update(Ticket ticket);
    }
}
