
using MeuCorre.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.Domain.Entities
{
    public class Conta : Entidade
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public decimal Saldo { get; private set; }
        public Guid UsuarioId { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }

       
        public decimal? Limite { get; private set; }
        public int? DiaFechamento { get; private set; }
        public int? DiaVencimento { get; private set; }
        public string? Cor { get; private set; }
        public string? Icone { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public TipoLimite? TipoLimite { get; private set; }



        public virtual Usuario Usuario { get; private set; }

        protected Conta() { }

        public Conta(Guid id, string nome, string tipo, decimal saldo, Guid usuarioId)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
            Saldo = saldo;
            UsuarioId = usuarioId;
            Ativo = true;
            DataCriacao = DateTime.UtcNow;
        }


        public void AtualizarNome(string nome)
        {
            Nome = nome;
            AtualizarData();
        }

        public void AtualizarTipo(string tipo)
        {
            Tipo = tipo;
            AtualizarData();
        }

        public void AtualizarSaldo(decimal novoSaldo)
        {
            Saldo = novoSaldo;
            AtualizarData();
        }

        public void AtualizarLimite(decimal? limite)
        {
            Limite = limite;
            AtualizarData();
        }

        public void AtualizarFechamentoEVencimento(int? fechamento, int? vencimento)
        {
            DiaFechamento = fechamento;
            DiaVencimento = vencimento;
            AtualizarData();
        }

        public void AtualizarVisual(string? cor, string? icone)
        {
            Cor = cor;
            Icone = icone;
            AtualizarData();
        }

        public void Desativar()
        {
            Ativo = false;
            AtualizarData();
        }

        private void AtualizarData()
        {
            DataAtualizacao = DateTime.UtcNow;
        }

        public void DefinirTipoLimite(TipoLimite? tipoLimite)
        {
            TipoLimite = tipoLimite;
            AtualizarData();
        }

    }
}

