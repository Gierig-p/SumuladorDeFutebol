using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoC_.Common.models
{
    public class Jogador
    {
        public string Nome { get; set; }
        public string Posicao { get; set; }
        public int NivelDeJogabilidade { get; set; }
        
        public Jogador(string nome, string posicao, int nivelDeJogabilidade)
        {
            Nome = nome;
            Posicao = posicao;
            NivelDeJogabilidade = nivelDeJogabilidade;
        }
        public override string ToString()
        {
            return $"{Nome} - {Posicao} (Nível: {NivelDeJogabilidade})";
        }
    }
}   