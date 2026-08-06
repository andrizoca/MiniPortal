namespace MiniPortal.Exceptions
{
    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException(int id)
            : base($"Ticket com o ID {id} não foi encontrado.")
        {
        }
    }
}
