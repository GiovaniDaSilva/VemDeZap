using MediatR;
using prmToolkit.NotificationPattern;
using System;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Factorys.Entities;
using VemDeZap.Domain.Interfaces.Repositories;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioHandler : Notifiable, IRequestHandler<AdicionarUsuarioRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AdicionarUsuarioHandler(IMediator mediator, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AdicionarUsuarioRequest request, CancellationToken cancellationToken)
        {
            if (!RequestEhValido(request))
            {
                return new Response(this);
            };

            Entities.Usuario usuario = CriarInstaciaUsuario(request);

            //Se possui notificações, esta invalido.
            if (IsInvalid()) { 
                return new Response(this); 
            }

            usuario = _repositoryUsuario.Adicionar(usuario);

            await CriarEPublicarNotificacao(usuario);

            return await RetornarObjetoResponse(usuario);
        }

        private async Task<Response> RetornarObjetoResponse(Entities.Usuario usuario)
        {
            var response = new Response(this, usuario);
            return await Task.FromResult(response);
        }

        private Entities.Usuario CriarInstaciaUsuario(AdicionarUsuarioRequest request)
        {
            //Criar a instacia do Usuario. O usuario possui sua propria validação, que carrega as notificações consigo.
            Entities.Usuario usuario = UsuarioFactory.CreateInstace(request.PrimeiroNome, request.PrimeiroNome, request.Email, request.Senha);

            //Adiciona as notificações que estao dentro do usuario
            AddNotifications(usuario);
            return usuario;
        }
         

        private async Task CriarEPublicarNotificacao(Entities.Usuario usuario)
        {
            AdicionarUsuarioNotification addUsuarioNotification = new AdicionarUsuarioNotification(usuario);

            await _mediator.Publish(addUsuarioNotification);
        }
               

        private bool RequestEhValido(AdicionarUsuarioRequest request)
        {
            if (!RequestEstaPreenchido(request))
            {
                AddNotification("Request", Strings.Strings.InformeOsDadosDoUsuario);
                return false;
            }

            if (UsuarioJaExiste(request))
            {
                AddNotification("Request", Strings.Strings.EmailJaCadastradoNoSistema);
                return false;
            }

            return true;
        }

        private bool UsuarioJaExiste(AdicionarUsuarioRequest request)
        {
            return (_repositoryUsuario.Existe(x => x.Email == request.Email));
        }

        private static bool RequestEstaPreenchido(AdicionarUsuarioRequest request)
        {
            return !(request == null);
        }
    }
}
