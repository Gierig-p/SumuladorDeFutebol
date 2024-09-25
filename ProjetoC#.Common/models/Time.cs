using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoC_.Common.models
{
    public class Time
    {
        public string NomeTime { get; set; }
        public List<Jogador> Jogadores { get; set; }

        public Time(string nomeTime)
        {
            NomeTime = nomeTime;
            Jogadores = new List<Jogador>();
        }
        public void AdicionarJogador(Jogador jogador)
        {
            Jogadores.Add(jogador);
        }
        public int SomarJogabilidade()
        {
            return Jogadores.Sum(j => j.NivelDeJogabilidade);
        }
        
        public void MostrarJogadores()
        {
            Console.WriteLine($"Jogadores do {NomeTime}");
            foreach (var jogador in Jogadores)
            {
                Console.WriteLine(jogador);
            }
        }
    }
}