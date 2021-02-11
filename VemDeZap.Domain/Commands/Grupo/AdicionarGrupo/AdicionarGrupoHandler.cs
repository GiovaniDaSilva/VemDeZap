using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Factorys.Entities;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Grupo.AdicionarGrupo
{
    public class AdicionarGrupoHandler : Notifiable, IRequestHandler<AdicionarGrupoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGrupo _repositoryGrupo;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarGrupoHandler(IMediator mediator, IRepositoryGrupo repositoryGrupo, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryGrupo = repositoryGrupo;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AdicionarGrupoRequest request, CancellationToken cancellationToken)
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

            grupo = _repositoryGrupo.Adicionar(grupo);

            //Notificações para o grupo não foram implementadas no curso
            //await CriarEPublicarNotificacao(grupo);

            return await RetornarObjetoResponse(grupo);
        }

        private async Task<Response> RetornarObjetoResponse(Entities.Grupo grupo)
        {
            var response = new Response(this, grupo);
            return await Task.FromResult(response);
        }

        private Entities.Grupo CriarInstaciaGrupo(AdicionarGrupoRequest request)
        {
            var usuario = RetornaUsuario(request);

            //Criar a instacia do Usuario. O usuario possui sua propria validação, que carrega as notificações consigo.
            Entities.Grupo grupo = GrupoFactory.CreateInstace(request.Nome, request.Nicho, usuario);

            //Adiciona as notificações que estao dentro do usuario
            AddNotifications(grupo);
            return grupo;
        }

        private Entities.Usuario RetornaUsuario(AdicionarGrupoRequest request)
        {
            var usuario = _repositoryUsuario.ObterPorId(request.IdUsuario);

            if (usuario == null)
            {
                AddNotification("Usuario", Strings.Strings.UsuarioNaoInformado);
            }

            return usuario;
        }


        private bool RequestEhValido(AdicionarGrupoRequest request)
        {
            if (!RequestEstaPreenchido(request))
            {
                AddNotification("Request", Strings.Strings.InformeOsDadosDoGrupo);
                return false;
            }

            return true;
        }

        
        private static bool RequestEstaPreenchido(AdicionarGrupoRequest request)
        {
            return !(request == null);
        }

    }

}
