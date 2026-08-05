namespace MiniPortal.Models
{
    public class Chamado
    {
        // CADA OBJETO CRIADO A PARTIR DESTA CLASSE É UM CHAMADO
        public int Id { get; set; } 
        public string Titulo { get; set; } = string.Empty;
        public string Descricao {  get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }

    }
}
