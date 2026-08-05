using MiniPortal.Models;

namespace MiniPortal.Data
{
    public interface IChamadoData
    {
        List<Chamado> ObterTodos();
        void Adicionar(Chamado chamado);
    }
}
