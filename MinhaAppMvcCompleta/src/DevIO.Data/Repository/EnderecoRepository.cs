using DevIO.App.Models;
using DevIO.Bunisses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {

        public Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            throw new NotImplementedException();
        }

    }
}
