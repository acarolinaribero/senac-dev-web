using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Entities
{
    public class Categoria : Entidade
    {
        public Guid UsuarioId { get; private set; }
        public string Nome { get;  private set; }
        public string? Descricao { get;private set; }
        public string? Cor { get; private set; }
        public string? Icone { get; private set; }
        public bool Ativo { get; private set; }
        public TipoTransacao TipoDaTransacao { get; private set; }



        public void AtualizarInformacoes(string nome, string? descricao, string? cor, string? icone, bool ativo, TipoTransacao tipoDaTransacao)
        {
            Nome = nome;
            Descricao = descricao;
            Cor = cor;
            Icone = icone;
            Ativo = ativo;
            TipoDaTransacao = tipoDaTransacao;
            AtualizarDataMoficacao();
        }

        public void Ativar()
        {
            Ativo = true;
            AtualizarDataMoficacao();
        }
        public void Inativar()
        {
            Ativo = false;
            AtualizarDataMoficacao();
        }
    }
}