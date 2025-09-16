using MediatR;
using MeuCorre.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Application.UseCases.Usuarios
{
    public class CriarUsuarioCommands : IRequest<String>
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public required string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }
    }
    internal class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommands, String>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public CriarUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<string> Handle(CriarUsuarioCommands request, CancellationToken cancellationToken)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioPorEmail(request.Email);
            if (usuarioExistente == null) { }
            {
                return "Já existe um usuario cadastrado com este email";
            }
        }
    }

}
