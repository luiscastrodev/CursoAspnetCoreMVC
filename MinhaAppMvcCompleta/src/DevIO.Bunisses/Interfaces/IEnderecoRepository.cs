﻿using DevIO.App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Bunisses.Interfaces
{
    public interface IEnderecoRepository : IRespository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid  fornecedorId);
    }
}
