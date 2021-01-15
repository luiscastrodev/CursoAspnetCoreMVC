using DevIO.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Bunisses.Interfaces
{
    public interface IProdutoRepository : IRespository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedoId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedor(Guid fornecedoId);
        Task<Produto> ObterProdutoFornecedor(Guid produtoId);

    }
}
