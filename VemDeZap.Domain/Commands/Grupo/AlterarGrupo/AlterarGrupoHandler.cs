using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Factorys.Entities;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Grupo.AlterarGrupo
{
    public class AlterarGrupoHandler : Notifiable, IRequestHandler<AlterarGrupoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGrupo _repositoryGrupo;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AlterarGrupoHandler(IMediator mediator, IRepositoryGrupo repositoryGrupo, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryGrupo = repositoryGrupo;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AlterarGrupoRequest request, CancellationToken cancellationToken)
        {
            if (!RequestEhValido(request))
            {
                return new Response(this);
            };

            Entities.Grupo grupo = CriarInstaciaGrupo(request);

            //Se possui notificações, esta invalido.
            if (IsInvalid())
            {
                return new Response(this);
            }

            grupo.AlterarGrupo(request.Nome, request.Nicho);

            grupo = _repositoryGrupo.Editar(grupo);


            //Notificações para o grupo não foram implementadas no curso
            //await CriarEPublicarNotificacao(grupo);

            return await RetornarObjetoResponse(grupo);
        }

        private async Task<Response> RetornarObjetoResponse(Entities.Grupo grupo)
        {
            var result = new { id = grupo.Id, Nome = grupo.Nome, Nicho = grupo.Nicho };
            var response = new Response(this, result);
            return await Task.FromResult(response);
        }

        private Entities.Grupo CriarInstaciaGrupo(AlterarGrupoRequest request)
        {
            var usuario = RetornaUsuario(request);

            Entities.Grupo grupo = RetornarGrupo(request);
            
            return grupo;
        }

        private Entities.Grupo RetornarGrupo(AlterarGrupoRequest request)
        {
            Entities.Grupo grupo = _repositoryGrupo.ObterPorId(request.Id);

            if (grupo == null)
            {
                AddNotification("Grupo", Strings.Strings.GrupoNaoInformado);
            }

            return grupo;
        }

        private Entities.Usuario RetornaUsuario(AlterarGrupoRequest request)
        {
            var usuario = _repositoryUsuario.ObterPorId(request.IdUsuario.Value);

            if (usuario == null)
            {
                AddNotification("Usuario", Strings.Strings.UsuarioNaoInformado);
            }

            return usuario;
        }


        private bool RequestEhValido(AlterarGrupoRequest request)
        {
            if (!RequestEstaPreenchido(request))
            {
                AddNotification("Request", Strings.Strings.InformeOsDadosDoGrupo);
                return false;
            }

            return true;
        }


        private static bool RequestEstaPreenchido(AlterarGrupoRequest request)
        {
            return !(request == null);
        }
    }
}
