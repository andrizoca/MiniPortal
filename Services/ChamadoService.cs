using MiniPortal.Data;
using MiniPortal.Models;

namespace MiniPortal.Services
{
    public class ChamadoService
    {
        private readonly IChamadoData _chamadoData;

        public ChamadoService(IChamadoData chamadoData)
        {
            _chamadoData = chamadoData;
        }

        public List<Chamado> ObterTodos()
        {
            return _chamadoData.ObterTodos();
        }

        public void Adicionar(Chamado chamado)
        {
            chamado.Status = "Novo";
            chamado.DataCriacao = DateTime.Now;

            _chamadoData.Adicionar(chamado);
        }
    }
}
