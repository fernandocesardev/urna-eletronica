﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Controllers.Commands;
using UrnaEletronica.Controllers.Commands.Outputs;
using UrnaEletronica.Model;

namespace UrnaEletronica.DAL.Repositories.Interfaces
{
    public interface IVotoRepositorio : IRepositorioEF<Voto>
    {
        IEnumerable<VotosResultado> ObterVotosPorCandidatos();
        IEnumerable<Voto> ObterTodosPorCandidato(int? legenda);
        void ApagarTodosVotosCandidato(int idCandidato);
    }
}
