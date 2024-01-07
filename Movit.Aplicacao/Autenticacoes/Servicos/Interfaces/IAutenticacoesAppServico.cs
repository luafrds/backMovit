using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movit.DataTransfer.Autenticacoes.Request;
using Movit.DataTransfer.Autenticacoes.Response;

namespace Movit.Aplicacao.Autenticacoes.Servicos.Interfaces
{
    public interface IAutenticacoesAppServico
    {
        Task<LoginResponse> LogarAsync(LoginRequest loginRequest);
        Task<CadastroResponse> CadastrarAsync(CadastroRequest cadastroRequest);
    }
}