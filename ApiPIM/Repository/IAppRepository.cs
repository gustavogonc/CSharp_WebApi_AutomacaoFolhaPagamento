﻿using ApiPIM.Models;
using iText.Layout.Element;

namespace ApiPIM.Repository
{
    public interface IAppRepository
    {
        Task<IEnumerable<object>> RetornaMesesFuncionario(int id);
        Task<IEnumerable<object>> RetornaDetalhesMeses(DetalhesPagamentoFuncionario model);
    }
}
