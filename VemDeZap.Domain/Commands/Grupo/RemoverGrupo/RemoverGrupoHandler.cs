﻿using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Grupo.RemoverGrupo
{
    public class RemoverGrupoHandler : Notifiable, IRequestHandler<RemoverGrupoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGrupo _repositoryGrupo;

        public RemoverGrupoHandler(IMediator mediator, IRepositoryGrupo repositoryGrupo)
        {
            _mediator = mediator;
            _repositoryGrupo = repositoryGrupo;
        }

        public async Task<Response> Handle(RemoverGrupoRequest request, CancellationToken cancellationToken)
        {
            //Valida se o objeto request esta nulo
            if (request == null)
            {
                AddNotification("Request", "Request é obrigatório");
                return new Response(this);
            }

            Entities.Grupo grupo = _repositoryGrupo.ObterPorId(request.Id);

            if (grupo == null)
            {
                AddNotification("Request", "Grupo é Obrigatório");
                return new Response(this);
            }

            _repositoryGrupo.Remover(grupo);

            var result = new { Id = grupo.Id };

            //Cria objeto de resposta
            var response = new Response(this, result);

            //Cria e Dispara notificação
            RemoverGrupoNotification removerGrupoNotification = new RemoverGrupoNotification(grupo);
            await _mediator.Publish(removerGrupoNotification);

            ////Retorna o resultado
            return await Task.FromResult(response);
        }
    }
}
