using System.Text.Json;
using MiniPortal.Models;

namespace MiniPortal.Data
{
    public class TicketData : ITicketData
    {
        private readonly string _filePath;
        private static readonly object _fileLock = new();

        public TicketData()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "tickets.json");
        }

        private List<Ticket> LoadTicketsFromFile()
        {
            lock (_fileLock)
            {
                if (!File.Exists(_filePath))
                {
                    SaveTicketsToFileUnsafe(new List<Ticket>());
                    return new List<Ticket>();
                }

                var json = File.ReadAllText(_filePath);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Ticket>();
                }

                try
                {
                    return JsonSerializer.Deserialize<List<Ticket>>(json) ?? new List<Ticket>();
                }
                catch
                {
                    return new List<Ticket>();
                }
            }
        }

        private void SaveTicketsToFile(List<Ticket> tickets)
        {
            lock (_fileLock)
            {
                SaveTicketsToFileUnsafe(tickets);
            }
        }

        private void SaveTicketsToFileUnsafe(List<Ticket> tickets)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(tickets, options);

            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(_filePath, json);
        }

        public List<Ticket> GetAll()
        {
            return LoadTicketsFromFile();
        }

        public Ticket? GetById(Guid id)
        {
            return LoadTicketsFromFile().FirstOrDefault(t => t.Id == id);
        }

        public void Add(Ticket ticket)
        {
            if (ticket.Id == Guid.Empty)
            {
                ticket.Id = Guid.NewGuid();
            }

            if (ticket.CreatedAt == default)
            {
                ticket.CreatedAt = DateTime.Now;
            }

            var tickets = LoadTicketsFromFile();
            tickets.Add(ticket);
            SaveTicketsToFile(tickets);
        }

        public void Update(Ticket ticket)
        {
            var tickets = LoadTicketsFromFile();
            var existingTicket = tickets.FirstOrDefault(t => t.Id == ticket.Id);
            if (existingTicket != null)
            {
                existingTicket.Title = ticket.Title;
                existingTicket.Description = ticket.Description;
                existingTicket.Status = ticket.Status;
                SaveTicketsToFile(tickets);
            }
        }

        public void Delete(Ticket ticket)
        {
            var tickets = LoadTicketsFromFile();
            tickets.RemoveAll(t => t.Id == ticket.Id);
            SaveTicketsToFile(tickets);
        }
    }
}

