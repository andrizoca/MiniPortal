namespace MiniPortal.Exceptions
{
    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException(Guid id)
            : base($"Ticket com o ID {id} não foi encontrado.")
        {
        }
    }
}
