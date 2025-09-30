using MeuCorre.Domain.Enums;
using System;

namespace MeuCorre.Domain.Entities
{
    public class Conta : Entidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
        public Guid UsuarioId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }

        public decimal? Limite { get; set; }
        public int? DiaFechamento { get; set; }
        public int? DiaVencimento { get; set; }
        public string? Cor { get; set; }
        public string? Icone { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public TipoLimite? TipoLimite { get; set; }

        public virtual Usuario Usuario { get; set; }

    
        
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

        public void DefinirTipoLimite(TipoLimite? tipoLimite)
        {
            TipoLimite = tipoLimite;
            AtualizarData();
        }

        private void AtualizarData()
        {
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
