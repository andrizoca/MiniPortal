using MiniPortal.Models;

namespace MiniPortal.Data
{
    public class ChamadoData : IChamadoData
    {
        private static readonly List<Chamado> _chamados = new()
        {
            new Chamado
            {
                Id = 1,
                Titulo = "Erro ao acessar o portal",
                Descricao = "O usuário recebe uma mensagem de acesso negado.",
                Status = "Aberto",
                DataCriacao = DateTime.Now
            },
            new Chamado
            {
                Id = 2,
                Titulo = "Relatório não carrega",
                Descricao = "A tela permanece carregando ao abrir o relatório.",
                Status = "Em andamento",
                DataCriacao = DateTime.Now
            }
        };

        public List<Chamado> ObterTodos()
        {
            return _chamados;
        }

        public void Adicionar(Chamado chamado)
        {
            chamado.Id = _chamados.Count + 1;
            chamado.DataCriacao = DateTime.Now;
            _chamados.Add(chamado);
        }
    }
}

