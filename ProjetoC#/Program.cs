using System.ComponentModel;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Net.Mail;
using ProjetoC_.Common.models;

class Program
{
    static List<Jogador> jogadoresDisponiveis = new List<Jogador>
    {
        new Jogador("Alisson Becker", "Goleiro", 90),
        new Jogador("Ederson", "Goleiro", 88),
        new Jogador("Gianluigi Donnarumma", "Goleiro", 89),
        new Jogador("Manuel Neuer", "Goleiro", 87),
        new Jogador("Virgil van Dijk", "Zagueiro", 91),
        new Jogador("Sergio Ramos", "Zagueiro", 88),
        new Jogador("Marquinhos", "Zagueiro", 87),
        new Jogador("Kalidou Koulibaly", "Zagueiro", 85),
        new Jogador("Jordi Alba", "Lateral Esquerdo", 86),
        new Jogador("Andrew Robertson", "Lateral Esquerdo", 87),
        new Jogador("Theo Hernández", "Lateral Esquerdo", 85),
        new Jogador("Alex Sandro", "Lateral Esquerdo", 84),
        new Jogador("Trent Alexander-Arnold", "Lateral Direito", 87),
        new Jogador("Dani Carvajal", "Lateral Direito", 85),
        new Jogador("João Cancelo", "Lateral Direito", 88),
        new Jogador("Kyle Walker", "Lateral Direito", 86),
        new Jogador("Kevin De Bruyne", "Meio-Campo", 91),
        new Jogador("Luka Modric", "Meio-Campo", 88),
        new Jogador("Toni Kroos", "Meio-Campo", 87),
        new Jogador("N'Golo Kanté", "Meio-Campo", 89),
        new Jogador("Lionel Messi", "Atacante", 93),
        new Jogador("Cristiano Ronaldo", "Atacante", 92),
        new Jogador("Kylian Mbappé", "Atacante", 91),
        new Jogador("Robert Lewandowski", "Atacante", 92)
    };
    static void Main(string[] args)
    {
        Console.WriteLine("Escolha seu Time!");

        ExibirLimites();

        Time time1 = EscolherTime("Time 1");

        Time time2 = CriarTimePredefinido("Time 2");

        time1.MostrarJogadores();
        time2.MostrarJogadores();

        Jogo jogo = new Jogo(time1, time2);
        jogo.simutlar();
    }
    static void ExibirLimites()
    {
        Console.WriteLine("Limites de cada posição:");
        Console.WriteLine("- 1 Goleiro");
        Console.WriteLine("- 2 Zagueiros");
        Console.WriteLine("- 1 Lateral Esquerdo");
        Console.WriteLine("- 1 Lateral Direito");
        Console.WriteLine("- 3 Meio-Campo");
        Console.WriteLine("- 3 Atacantes");
    }
    static Time EscolherTime(string nomeDoTime)
    {
        Time time = new Time(nomeDoTime);
        var jogadoresDisponiveisParaEscolha = new List<Jogador>(jogadoresDisponiveis);
        int goleiros = 0, zagueiros = 0, lateraisEsquerdo = 0, lateraisDireito = 0, meioCampo = 0, atacantes = 0;
        
        while (goleiros < 1 || zagueiros < 2 || lateraisEsquerdo < 1 || lateraisDireito < 1 || meioCampo < 3 || atacantes < 3 )
        {
            Console.WriteLine("\nEscolha um jogador para adicionar ao time (digite o número):");
            MostrarJogadoresDisponiveis(jogadoresDisponiveisParaEscolha);

            int numeroJogadorEscolhido;
            if (int.TryParse(Console.ReadLine(), out numeroJogadorEscolhido) && numeroJogadorEscolhido > 0 && numeroJogadorEscolhido <= jogadoresDisponiveisParaEscolha.Count)
            {
                Jogador jogadorEscolhido = jogadoresDisponiveisParaEscolha[numeroJogadorEscolhido - 1];

                    
                if (!time.Jogadores.Contains(jogadorEscolhido))
                {                   
                    bool posicaoValida = VerificarPosicao(jogadorEscolhido.Posicao, ref goleiros, ref zagueiros, ref lateraisEsquerdo, ref lateraisDireito, ref meioCampo, ref atacantes);
                    if (posicaoValida)
                    {
                        time.AdicionarJogador(jogadorEscolhido);
                        jogadoresDisponiveisParaEscolha.Remove(jogadorEscolhido);
                    }
                    else
                    {
                        Console.WriteLine("Número máximo de jogadores para essa posição já atingido.");
                    }
                }
                else
                {
                    Console.WriteLine("Jogador já foi selecionado. Escolha outro.");
                }
            }
            else
            {
                Console.WriteLine("Número inválido. Tente novamente.");
            }
                // Debug: Mostrar contagens atuais
            Console.WriteLine($"Contagem atual - Goleiros: {goleiros}, Zagueiros: {zagueiros}, Laterais Esquerdo: {lateraisEsquerdo}, Laterais Direito: {lateraisDireito}, Meio-Campo: {meioCampo}, Atacantes: {atacantes}");
        }
        return time;
    }

    static Time CriarTimePredefinido(string nomeDoTime)
    {
        Time time = new Time(nomeDoTime);
        time.AdicionarJogador(new Jogador("Tiago Cardoso", "Goleiro", 87));
        time.AdicionarJogador(new Jogador("Neris", "Zagueiro", 88));
        time.AdicionarJogador(new Jogador("Danny Morais", "Zagueiro", 85));
        time.AdicionarJogador(new Jogador("Mário Fernandes", "Lateral Esquerdo", 84));
        time.AdicionarJogador(new Jogador("Vítor", "Lateral Direito", 86));
        time.AdicionarJogador(new Jogador("André Santos", "Meio-Campo", 88));
        time.AdicionarJogador(new Jogador("Paulinho", "Meio-Campo", 87));
        time.AdicionarJogador(new Jogador("João Paulo", "Meio-Campo", 89));
        time.AdicionarJogador(new Jogador("Keno", "Atacante", 92));
        time.AdicionarJogador(new Jogador("Grafite", "Atacante", 91));
        time.AdicionarJogador(new Jogador("Flávio Caça-Rato", "Atacante", 92));

        return time;
    }

    static void MostrarJogadoresDisponiveis(List<Jogador> listaJogadires)
    {
        Console.WriteLine("\nJogadores disponíveis:");
        {
        for (int i = 0; i < listaJogadires.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {listaJogadires[i]}");
        }
        }
    }
    static bool VerificarPosicao(string Posicao, ref int goleiros, ref int zagueiros, ref int lateraisEsquerdo, ref int lateraisDireito, ref int meioCampo, ref int atacantes)
    {
        switch (Posicao)
        {
            case "Goleiro":
                if(goleiros < 1)
                {
                    goleiros++;
                    return true;
                }
                break;
            
            case "Zagueiro":
                if(zagueiros < 2)
                {
                    zagueiros++;
                    return true;
                }
                break;

            case "Lateral Esquerdo":
                if(lateraisEsquerdo < 1)
                {
                    lateraisEsquerdo++;
                    return true;
                }
                break;

            case "Lateral Direito":
                if(lateraisDireito < 1)
                {
                    lateraisDireito++;
                    return true;
                }
                break;

            case "Meio-Campo":
                if(meioCampo < 3)
                {
                    meioCampo++;
                    return true;
                }
                break;

            case "Atacante":
                if(atacantes < 3)
                {
                    atacantes++;
                    return true;
                }
                break;
        }
        return false;
    }
}
